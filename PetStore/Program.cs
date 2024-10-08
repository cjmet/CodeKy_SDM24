﻿using PetStore.Interfaces;
using PetStore.Logic;
using PetStore.Products;
using PetStore.Utils;
using Microsoft.Extensions.DependencyInjection; // cjm - added for DI
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using FluentValidation;


namespace PetStore
{
    internal static class Program
    {
        // We haven't covered Reflection yet, so I'm going to use a list of products.
        private static List<IProduct> _productList = [new CatFood(), new DogLeash(), new FishFood(), new CatToys()];

        // MAIN
        static void Main(string[] args)
        {
            Console.WriteLine(Logo.GetLogo());
            Console.WriteLine("Welcome to the Pet Store!");

            if (true)
            {
                var x = mixleplic("PetStore.Products.CatFood");
                Console.WriteLine(x.GetType().ToString().Indent());
                Console.WriteLine(x.GetJson().Indent(2));
                Console.WriteLine(x.GetText().Indent(3));
                Console.WriteLine("\n\n");
            }


            IServiceProvider _serviceProvider = CreateServiceCollection();
            Debug.WriteLine($"Service Provider Created: [{_serviceProvider}]");

            //ProductLogic _productLogic = new ProductLogic();

            ProductLogic _productLogic = _serviceProvider.GetService<IProductLogic>() as ProductLogic;  // cjm ... as ProductLogic;
            Debug.WriteLine($"Product Logic Created: [{_productLogic}]");



            Program.AddTestData(_productLogic);

            // I had to declare these outside the loop for scope.
            string userInput;
            bool loop = true;
            int blankLine = 0;  // I want to exit if you hit enter twice.

            // User input Do-While loop
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. Search for a Product");
                Console.WriteLine("3. Get All Products");
                Console.WriteLine("4. Get In-Stock Product Names");
                Console.WriteLine("5. Get Out-of-Stock Product Names");
                Console.WriteLine("6. Get Total Inventory Value");
                Console.WriteLine("7. Read Json Input");
                Console.WriteLine("8. Get Generic Product By Name");
                Console.WriteLine("   ---");
                Console.WriteLine("0. Exit");

                // Null forgiving postfix operator "!"
                // Because I'm going to check for null in the next line.
                // But fix the null warnings below this *BEFORE* using the null forgiving operator.
                userInput = Console.ReadLine()!;
                Console.WriteLine();

                // Got rid of the null (input) string warning
                // However, we still have a null warning above, so we'll fix that after this.
                if (userInput == null)
                {
                    userInput = "";
                    continue;
                }

                // BLOCK: I want to exit if you hit enter twice.
                // use the block arrows on the left margin to collapse this block.
                {
                    if (userInput == "")
                    {
                        Console.WriteLine("Press <enter> again to exit.");
                        blankLine++;
                        if (blankLine > 1)
                        {
                            loop = false;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        blankLine = 0;
                    }
                }

                // Switch statement for user input
                switch (userInput.ToLower())
                {
                    case "a":
                    case "1":
                        {
                            IProduct? product = Program.ConsoleGetNewProduct();
                            if (product == null)
                            {
                                Console.WriteLine("Product not created.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Adding Product ...");
                                _productLogic.AddProduct(product);
                                Console.WriteLine("Product Added: " + product.GetJson());
                            }
                            break;
                        }
                    case "s":
                    case "2": // Get CatFood by EXACT Name, including case.
                        {
                            IProduct product = Program.ConsoleSearchForProduct(_productLogic);
                            if (product != null)
                            {
                                Console.WriteLine($"Product Found:");
                                Console.WriteLine(product.GetText());
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                            break;
                        }
                    case "g":
                    case "3":
                        {
                            List<IProduct> products = _productLogic.GetAllProducts();
                            if (products?.Count > 0)
                            {
                                Console.WriteLine("All Products:");
                                foreach (IProduct product in products)
                                {
                                    Console.WriteLine(product.GetJson());
                                }
                            }
                            else Console.WriteLine("Null or No Products.");
                            break;
                        }
                    case "i":
                    case "4":
                        {
                            List<String> productNames = _productLogic.GetInStockProductNames();
                            if (productNames?.Count > 0)
                            {
                                Console.WriteLine("In-Stock Products:");
                                foreach (String name in productNames)
                                {
                                    Console.WriteLine(name);
                                }
                            }
                            else Console.WriteLine("Null or No In-Stock Products.");
                            break;
                        }
                    case "o":
                    case "5":
                        {
                            List<String> productNames = _productLogic.GetOutOfStockProductNames();
                            if (productNames?.Count > 0)
                            {
                                Console.WriteLine("Out-of-Stock Products:");
                                foreach (String name in productNames)
                                {
                                    Console.WriteLine(name);
                                }
                            }
                            else Console.WriteLine("Null or No Out-of-Stock Products.");
                            break;
                        }
                    case "t":
                    case "6":
                        {
                            Decimal totalValue = _productLogic.GetTotalInventoryValue();
                            Console.WriteLine("Total Inventory Value: " + totalValue);
                            break;
                        }
                    case "j":
                    case "7":
                        {
                            Console.WriteLine("Reading Json Input ...");

                            IProduct? product = Program.ConsoleGetJsonProduct();
                            if (product == null)
                            {
                                Console.WriteLine("Product not created.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Adding Product ...");
                                _productLogic.AddProduct(product);
                                Console.WriteLine("Product Added: " + product.GetJson());
                            }
                            break;
                        }
                    case "8":
                        {
                            Console.WriteLine("Enter the name of the product:");
                            string name = Console.ReadLine()!;
                            IProduct product = _productLogic.GenericProductByName<IProduct>(name);
                            if (product != null)
                            {
                                Console.WriteLine($"Product Found:");
                                Console.WriteLine(product.GetText());
                            }
                            else
                            {
                                Console.WriteLine("Product not found.");
                            }
                            break;
                        }
                    case "0":
                    case "x":
                    case "e":
                    case "exit":
                        {
                            loop = false;
                            break;
                        }
                }
            } while (loop);
        }

        private static IProduct? ConsoleGetJsonProduct()
        {
            string productType = "";
            do
            {
                Console.WriteLine("Select a Product Type:");
                foreach (IProduct product in _productList)
                {
                    var verboseClassName = product.GetType().ToString();
                    var shortClassName = verboseClassName.Substring(verboseClassName.LastIndexOf('.') + 1);
                    Console.Write($"{shortClassName}, ");
                }
                Console.WriteLine();

                productType = Console.ReadLine()!;
                foreach (IProduct product in _productList)
                {
                    var verboseClassName = product.GetType().ToString();
                    var shortClassName = verboseClassName.Substring(verboseClassName.LastIndexOf('.') + 1);
                    if (productType == shortClassName)
                    {
                        IProduct? newProduct = null;

                        FluentValidation.Results.ValidationResult result;
                        var validator = new IProductValidator();
                        do
                        {
                            result = null;
                            Console.WriteLine($"\nEnter the JSON for the Product[{productType}]:");
                            String jsonText = Console.ReadLine()!;

                            if (jsonText.Trim() == "") break;

                            // NewFromJson needs to be improved and made into a single method if possible.
                            // use the constructor from the static list of products we created at the beginning of the program class.
                            try
                            {
                                newProduct = product.NewFromJson(jsonText);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                continue;
                            }

                            //validator.ValidateAndThrow(newProduct); // cjm2
                            result = validator.Validate(newProduct); // cjm2
                            if (result != null && !result.IsValid) Console.WriteLine("Validation Error: " + result.ToString());
                        } while (result == null || !result.IsValid);

                        return newProduct;
                    }
                }

                Console.WriteLine("Product Type not found.\n");
            } while (productType != "");

            return null;
        }
        private static void AddTestData(ProductLogic _productLogic)
        {
            _productLogic.AddProduct(new CatFood
            {
                Name = "Purina Cat Chow",
                Price = 12.99M,
                Description = "Cat food for adult cats",
                Quantity = 10,
                WeightPounds = 5.0,
                KittenFood = false
            });
            _productLogic.AddProduct(new DogLeash
            {
                Name = "FlexiDog Leash",
                Price = 19.99M,
                Description = "Retractable dog leash",
                Quantity = 5,
                LengthInches = 60,
                Material = "Nylon"
            });
            _productLogic.AddProduct(new FishFood
            {
                Name = "TetraMin FishFood",
                Price = 5.99M,
                Description = "Fish food for tropical fish",
                Quantity = 20,
                WeightOunces = 2.0,
                FlakeFood = true
            });
            _productLogic.AddProduct(new CatToys
            {
                Name = "Catnip Mouse Toy",
                Price = 2.99M,
                Description = "Cat toy filled with catnip",
                Quantity = 15,
            });
            _productLogic.AddProduct(new CatToys
            {
                Name = "Feather Wand (OoS)",
                Price = 4.99M,
                Description = "Cat toy with feathers",
                Quantity = 0,
            });
            _productLogic.AddProduct(new CatToys
            {
                Name = "Laser Pointer (OoS)",
                Price = 1.99M,
                Description = "Cat toy with laser",
                Quantity = 0,
            });
        }
        private static IProduct? ConsoleGetNewProduct()
        {
            Console.WriteLine("Select a Product Type:");
            foreach (IProduct product in _productList)
            {
                var verboseClassName = product.GetType().ToString();
                var shortClassName = verboseClassName.Substring(verboseClassName.LastIndexOf('.') + 1);
                Console.Write($"{shortClassName}, ");
            }
            Console.WriteLine();

            string productType = Console.ReadLine()!;
            foreach (IProduct product in _productList)
            {
                var verboseClassName = product.GetType().ToString();
                var shortClassName = verboseClassName.Substring(verboseClassName.LastIndexOf('.') + 1);
                if (productType == shortClassName)
                {
                    IProduct? newProduct = null;

                    // Grab a new instance via Reflection or a method
                    newProduct = NewIProductInstance(product);

                    if (newProduct == null)
                    {
                        Console.WriteLine("ERROR: Failed to get a new instace of product!");
                    }
                    else
                    {
                        newProduct.GetFromConsole();
                    }
                    return newProduct;
                }
            }

            Console.WriteLine("Product Type not found.");
            return null;
        }
        private static IProduct ConsoleSearchForProduct(ProductLogic _productLogic)
        {
            Console.WriteLine("Enter the name of the product:");
            string name = Console.ReadLine()!;
            Console.WriteLine();
            IProduct product = _productLogic.SearchForProduct(name);
            return product;
        }
        private static IProduct? NewIProductInstance(IProduct product)
        {
            if (product == null) return null;
            IProduct? newProduct = null;
            bool useReflection = false;
            // Grab a new instance via Reflection
            if (useReflection)
            {
                //WARNING: If this isn't an IProduct this is going to go sideways really fast.
                //  1) This is probably more Reflection? And we haven't covered that yet.
                //  2) We could use a Product.New() method in each IProduct? bypassing reflection.
                //  3) Or we could just long hand test each option with a switch.
                //Type type = obj.GetType();
                //return Activator.CreateInstance(type);
                var _type = product.GetType();
                newProduct = (IProduct?)Activator.CreateInstance(_type);
            }
            // Grab a new instance via a method
            else
            {
                newProduct = product.NewProduct();
            }
            return newProduct;
        }
        private static IServiceProvider CreateServiceCollection()
        {
            // Create a new ServiceCollection
            var services = new ServiceCollection();

            // Add the services to the collection
            services.AddTransient<IProductLogic, ProductLogic>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
        public static String Indent(this String S, Int32 I = 1)
        {
            for (int i = 0; i < I; i++) S = Regex.Replace(S, "^", "   ", RegexOptions.Multiline);
            return S;
        }

        // "mixleplic" because it's magic
        // "Mixleplic" is a method that uses Reflection to create an instance of a class.
        private static IProduct mixleplic(String T)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Console.WriteLine($"AssemblyName: {assemblyName}");
            IProduct results = null;

            try
            {
                results = (IProduct)Activator.CreateInstance(assemblyName, T).Unwrap();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

            return results;
        }
    }
}


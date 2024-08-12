namespace PetStore
{
    internal class Program
    {
        // We haven't covered Refleions yet, so I'm going to use a list of products.
        // We probably won't cover reflection enough to use it in this way.
        private static List<IProduct> _productList = [ new CatFood(), new DogLeash(), new FishFood() ];

        static void Main(string[] args)
        {
            Console.WriteLine(Logo.GetLogo());

            Console.WriteLine("Welcome to the Pet Store!");

            ProductLogic _productLogic = new ProductLogic();
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
                Console.WriteLine("   ---");
                Console.WriteLine("9. Get All Products");
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
                            IProduct product = Program.ConsoleGetNewProduct();
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
                    case "9":
                        {
                            List<IProduct> products = _productLogic.GetAllProducts();
                            foreach (IProduct product in products)
                            {
                                Console.WriteLine(product.GetJson());
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

        private static void AddTestData (ProductLogic _productLogic)
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
            _productLogic.AddProduct(new FishFood { 
                Name = "TetraMin FishFood",
                Price = 5.99M,
                Description = "Fish food for tropical fish",
                Quantity = 20,
                WeightOunces = 2.0,
                FlakeFood = true
            });
        }


        private static IProduct ConsoleGetNewProduct() { 
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
                    product.GetFromConsole();
                    return product;
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

    }
}


using System.Diagnostics;
using System.Text.Json;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Logo.GetLogo());

            Console.WriteLine("Welcome to the Pet Store!");

            var productLogic = new ProductLogic();

            // I had to declare these outside the loop for scope.
            string userInput;
            bool loop = true;
            int blankLine = 0;  // I want to exit if you hit enter twice.
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a Product");
                Console.WriteLine("2. Get CatFood by Name");
                Console.WriteLine("3. Search for CatFood");
                Console.WriteLine("   ---");
                Console.WriteLine("9. Add a Test Product");
                Console.WriteLine("0. Exit");

                // Null forgiving postfix operator "!"
                // Because I'm going to check for null in the next line.
                // But fix the null warnings below this *BEFORE* using the null forgiving operator.
                userInput = Console.ReadLine()!;

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

                switch (userInput.ToLower())
                {
                    case "a":
                    case "1":
                        {
                            CatFood product = null;
                            product = UserInput.ConsoleInputCatfood();
                            if (product == null)
                            {
                                Console.WriteLine("Product not added.");
                                break;
                            }
                            productLogic.AddProduct(product);
                            Console.WriteLine("Product Added!");
                            string jsonString = JsonSerializer.Serialize(product);
                            Debug.WriteLine($"Product Added: {jsonString}");
                            break;
                        }
                    case "G":
                    case "2":
                        {
                            Console.WriteLine("Enter the name of the CatFood you want to retrieve:");
                            string name = Console.ReadLine()!;
                            //CatFood catFood = productLogic.GetCatFoodByName(name);
                            // handles the issue more gracefully, but we are specifically wanting to
                            // throw an exception here, in order to demonstrate try/catch
                            CatFood catFood;
                            try
                            {
                                catFood = productLogic.GetCatFoodOrThrow(name);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"CatFood not found. {ex.Message}");
                                break;
                            }
                            if (catFood == null)
                            {
                                Console.WriteLine("CatFood not found.");
                                break;
                            }
                            Console.WriteLine($"Name: {catFood.Name}");
                            Console.WriteLine($"Price: {catFood.Price}");
                            Console.WriteLine($"Description: {catFood.Description}");
                            Console.WriteLine($"Quantity: {catFood.Quantity}");
                            Console.WriteLine($"Weight: {catFood.WeightPounds}");
                            Console.WriteLine($"Kitten Food: {catFood.KittenFood}");

                            string jsonString = JsonSerializer.Serialize(catFood);
                            Debug.WriteLine($"Product Found: {jsonString}");
                            break;
                        }
                    case "S":
                    case "3": // Get CatFood by Name
                        {
                            Console.WriteLine("Enter the name of the CatFood you want to search:");
                            string name = Console.ReadLine()!;
                            //CatFood catFood = productLogic.GetCatFoodByName(name);
                            //That only finds exact matches, so lets improve (a little) on that.
                            CatFood catFood = productLogic.SearchForCatFood(name);
                            if (catFood == null)
                            {
                                Console.WriteLine("CatFood not found.");
                                break;
                            }
                            Console.WriteLine($"Name: {catFood.Name}");
                            Console.WriteLine($"Price: {catFood.Price}");
                            Console.WriteLine($"Description: {catFood.Description}");
                            Console.WriteLine($"Quantity: {catFood.Quantity}");
                            Console.WriteLine($"Weight: {catFood.WeightPounds}");
                            Console.WriteLine($"Kitten Food: {catFood.KittenFood}");

                            string jsonString = JsonSerializer.Serialize(catFood);
                            Debug.WriteLine($"Product Found: {jsonString}");
                            break;
                        }
                    case "9":
                        {
                            CatFood product = new CatFood()
                            {
                                Name = "Cat Food",
                                Price = 10.99m,
                                Description = "A delicious meal for your cat",
                                Quantity = 5,
                                WeightPounds = 5.5,
                                KittenFood = false
                            };

                            productLogic.AddProduct(product);
                            Console.WriteLine("Product Added!");
                            string jsonString = JsonSerializer.Serialize(product);
                            Debug.WriteLine($"Product Added: {jsonString}");
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
    }
}


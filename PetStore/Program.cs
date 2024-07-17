using System.Text.Json;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // I can't help but add little things.
            Console.WriteLine(Logo.GetLogo());

            Console.WriteLine("Welcome to the Pet Store!");

            // I had to declare it outside the loop for scope.
            string userInput;   
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a product");

                // Yes I know, it asked for "Exit".  I did that, but I prefer the keypad.
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

                if (userInput == "1" || userInput.ToLower() == "a")
                {
                    // It did not say we had to input it from console, just create one and print it.
                    // KISS - Keep It Simple ... It's killing me not to add more. ;-p
                    CatFood catFood = new CatFood()
                    {
                        Name = "Cat Food",
                        Price = 10.99m,
                        Description = "A delicious meal for your cat",
                        Quantity = "5",
                        WeightPounds = 5.5,
                        KittenFood = false
                    };

                    // I can't help but add things.
                    Console.WriteLine("Product added!");
                    Console.WriteLine();
                    Console.WriteLine($"Product: {catFood.Name}");
                    Console.WriteLine($"Price: {catFood.Price}");
                    Console.WriteLine($"Description: {catFood.Description}");
                    Console.WriteLine($"Quantity: {catFood.Quantity}");
                    Console.WriteLine($"Weight: {catFood.WeightPounds} lbs");
                    Console.WriteLine($"Kitten Food: {catFood.KittenFood}");
                    Console.WriteLine();

                    // Here's what was actually asked for.
                    string jsonString = JsonSerializer.Serialize(catFood);
                    Console.WriteLine(jsonString);
                }
            } while (userInput.ToLower() != "x" && userInput.ToLower() != "e"
            && userInput != "0" && userInput.ToLower() != "exit");
        }
    }
}

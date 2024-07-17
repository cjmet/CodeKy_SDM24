using System.Text.Json;

namespace PetStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Logo.GetLogo());
            Console.WriteLine("Welcome to the Pet Store!");
            string userInput;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Add a product");
                Console.WriteLine("0. Exit");
                userInput = Console.ReadLine();
                if (userInput == "1" || userInput.ToLower() == "a")
                {
                    CatFood catFood = new CatFood()
                    {
                        Name = "Cat Food",
                        Price = 10.99m,
                        Description = "A delicious meal for your cat",
                        Quantity = "5",
                        WeightPounds = 5.5,
                        KittenFood = false
                    };
                    Console.WriteLine("Product added!");
                    Console.WriteLine();
                    Console.WriteLine($"Product: {catFood.Name}");
                    Console.WriteLine($"Price: {catFood.Price}");
                    Console.WriteLine($"Description: {catFood.Description}");
                    Console.WriteLine($"Quantity: {catFood.Quantity}");
                    Console.WriteLine($"Weight: {catFood.WeightPounds} lbs");
                    Console.WriteLine($"Kitten Food: {catFood.KittenFood}");
                    Console.WriteLine();

                    string jsonString = JsonSerializer.Serialize(catFood);
                    Console.WriteLine(jsonString);
                }
            } while (userInput.ToLower() != "x" && userInput.ToLower() != "e" && userInput.ToLower() != "0");
        }
    }
}

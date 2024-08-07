namespace PetStore
{
    public static class UserInput
    {

        // Write the method ConsoleInputCatfood();
        // This method will prompt the user for the properties of a CatFood object.
        public static CatFood ConsoleInputCatfood()
        {
            CatFood catFood = new CatFood();

            string name;
            do
            {
                Console.WriteLine("Enter the name of the CatFood:");
                name = Console.ReadLine()!;
            } while (name.Trim() == "");
            catFood.Name = name;

            decimal price;
            do
            {
                Console.WriteLine("Enter the price of the CatFood:");
                price = decimal.TryParse(Console.ReadLine()!, out price) ? price : -1;
            } while (price < 0);
            catFood.Price = price;

            string desc;
            do
            {
                Console.WriteLine("Enter the description of the CatFood:");
                desc = Console.ReadLine()!;
            } while (desc.Trim() == "");
            catFood.Description = desc;

            int quantity;
            do
            {
                Console.WriteLine("Enter the quantity of the CatFood:");
                quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : -1;
            } while (quantity < 0);
            catFood.Quantity = quantity;

            double weight;
            do
            {
                Console.WriteLine("Enter the weight of the CatFood:");
                weight = double.TryParse(Console.ReadLine()!, out weight) ? weight : -1;
            } while (weight < 0);
            catFood.WeightPounds = weight;

            bool kittenFood;
            string input;
            do
            {
                Console.WriteLine("Is this Kitten Food? (y/n)");
                input = Console.ReadLine()!.ToLower();
                input = input.Trim();
                kittenFood = input == "y" || input == "yes";
            } while (input != "y" && input != "yes" && input != "n" && input != "no");
            catFood.KittenFood = kittenFood;

            return catFood;
        }
    }
}

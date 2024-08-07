using System.Text.Json;

namespace PetStore
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        virtual public void GetFromConsole()
        {
            string name;
            do
            {
                Console.WriteLine("Enter the name of the Product:");
                name = Console.ReadLine()!;
            } while (name.Trim() == "");
            this.Name = name;

            decimal price;
            do
            {
                Console.WriteLine("Enter the price of the Product");
                price = decimal.TryParse(Console.ReadLine()!, out price) ? price : -1;
            } while (price < 0);
            this.Price = price;

            string desc;
            do
            {
                Console.WriteLine("Enter the description of the Product");
                desc = Console.ReadLine()!;
            } while (desc.Trim() == "");
            this.Description = desc;

            int quantity;
            do
            {
                Console.WriteLine("Enter the quantity of the Product");
                quantity = int.TryParse(Console.ReadLine()!, out quantity) ? quantity : -1;
            } while (quantity < 0);
            this.Quantity = quantity;
        }
        virtual public String DisplayText()
        {
            String _displayString = "";

            _displayString += ("Name: " + Name + "\n");
            _displayString += ("Price: " + Price + "\n");
            _displayString += ("Description: " + Description + "\n");
            _displayString += ("Quantity: " + Quantity);
            return _displayString;
        }

        virtual public String DisplayJson()
        {
            String jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

    }
}

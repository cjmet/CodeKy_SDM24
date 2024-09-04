using System.Text.Json;
using PetStore.Interfaces;

namespace PetStore.Products
{
    public class DogLeash : Product
    {
        public int LengthInches { get; set; }
        public string Material { get; set; }
        public override IProduct NewProduct() { return new DogLeash(); }
        public override void GetFromConsole()
        {
            base.GetFromConsole();
            int inches;
            do
            {
                Console.WriteLine("Enter the Length in inches of the Leash:");
                inches = int.TryParse(Console.ReadLine()!, out inches) ? inches : -1;
            } while (inches < 0);
            LengthInches = inches;

            string input;
            do
            {
                Console.WriteLine("What is this Leashe's Material?");
                input = Console.ReadLine().Trim()!;
            } while (input == null || input == "");
            Material = input;
        }
        public override string GetText()
        {
            string _displayString = base.GetText() + "\n";
            _displayString += "LengthInches: " + LengthInches + "\n";
            _displayString += "Material: " + Material;

            return _displayString;
        }
        public override string GetJson()
        {
            string jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }
        public override IProduct NewFromJson(string jsonText)
        {
            IProduct newcopy = JsonSerializer.Deserialize<DogLeash>(jsonText);
            return newcopy;
        }
    }
}

using System.Text.Json;

namespace PetStore
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
            this.LengthInches = inches;

            string input;
            do
            {
                Console.WriteLine("Is this Leashe's Material?");
                input = Console.ReadLine().Trim()!;
            } while (input == null || input == "");
            this.Material = input;
        }
        public override String GetText()
        {
            String _displayString = base.GetText() + "\n";
            _displayString += ("LengthInches: " + this.LengthInches + "\n");
            _displayString += ("Material: " + this.Material);

            return _displayString;
        }
        public override String GetJson()
        {
            String jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }


    }
}

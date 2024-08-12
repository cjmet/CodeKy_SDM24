using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetStore
{
    public class FishFood : Product, IProduct
    {
        public double WeightOunces { get; set; }
        public bool FlakeFood { get; set; }

        public override void GetFromConsole()
        {
            base.GetFromConsole();
            double weight;
            do
            {
                Console.WriteLine("Enter the weight of the FishFood in Ounces:");
                weight = double.TryParse(Console.ReadLine()!, out weight) ? weight : -1;
            } while (weight < 0);
            this.WeightOunces = weight;

            bool flakeFood;
            string input;
            do
            {
                Console.WriteLine("Is this Flake Food? (y/n)");
                input = Console.ReadLine()!.ToLower();
                input = input.Trim();
                flakeFood = input == "y" || input == "yes";
            } while (input != "y" && input != "yes" && input != "n" && input != "no");
            this.FlakeFood = flakeFood;
        }
        public override String GetText()
        {
            String _displayString = base.GetText() + "\n";
            _displayString += ("Ounces: " + WeightOunces + "\n");
            _displayString += ("Flake Food: " + FlakeFood);

            return _displayString;
        }
        public override String GetJson()
        {
            String jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }

    }
}

﻿using System.Text.Json;

namespace PetStore
{
    public class CatFood : Product
    {
        public double WeightPounds { get; set; }
        public bool KittenFood { get; set; }

        public override void GetFromConsole()
        {
            base.GetFromConsole();
            double weight;
            do
            {
                Console.WriteLine("Enter the weight of the CatFood:");
                weight = double.TryParse(Console.ReadLine()!, out weight) ? weight : -1;
            } while (weight < 0);
            this.WeightPounds = weight;

            bool kittenFood;
            string input;
            do
            {
                Console.WriteLine("Is this Kitten Food? (y/n)");
                input = Console.ReadLine()!.ToLower();
                input = input.Trim();
                kittenFood = input == "y" || input == "yes";
            } while (input != "y" && input != "yes" && input != "n" && input != "no");
            this.KittenFood = kittenFood;
        }
        public override String DisplayText()
        {
            String _displayString = base.DisplayText();
            _displayString += ("Weight: " + WeightPounds + "\n");
            _displayString += ("Kitten Food: " + KittenFood + "\n");

            return _displayString;
        }
        public override String DisplayJson()
        {
            // We do NOT want to call base.DisplayJson(); this time.
            String jsonString = JsonSerializer.Serialize(this);
            return jsonString;
        }
    }
}

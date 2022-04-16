namespace FoodLibrary
#nullable disable
{
    public static class Common
    {
        public static int ReadUserInt(string prompt)
        {
            int parsedOption;
            bool validFormat = int.TryParse(prompt, out parsedOption);

            while (!validFormat)
            {
                Console.WriteLine("Please enter a Valid value");
                prompt = Console.ReadLine();
                validFormat = int.TryParse(prompt, out parsedOption);
            }
            parsedOption = int.Parse(prompt);
            return parsedOption;
        }

        public static double CheckValidStorageTemp(string inputString)
        {
            double storageTemp;
            bool validFormat = double.TryParse(inputString, out storageTemp);

            while (!validFormat)
            {
                Console.WriteLine("Please enter a Valid storage temp");
                inputString = Console.ReadLine();
                validFormat = double.TryParse(inputString, out storageTemp);
            }

            storageTemp = double.Parse(inputString);
            return storageTemp;
        }

        public static double CheckValidweight(string inputString)
        {
            double weight;
            bool validFormat = double.TryParse(inputString, out weight);
            // Check for correct format
            while (!validFormat)
            {
                Console.WriteLine("Please enter a Valid weight (numbers only)");
                inputString = Console.ReadLine();
                validFormat = double.TryParse(inputString, out weight);
            }
            weight = double.Parse(inputString);

            // Check for correct weight range
            if (weight < 0.2 || weight > 5.0)
            {
                Console.WriteLine("Please enter a Valid weight between 0.2 and 5.0");
                inputString = Console.ReadLine();
                CheckValidweight(inputString);
            }

            // return weight in correct range
            return weight;
        }

        public static int CheckValidNumberOfpieces(string inputString)
        {
            int pieces;
            bool validFormat = int.TryParse(inputString, out pieces);
            // Check for correct format
            while (!validFormat)
            {
                Console.WriteLine("Please enter a number");
                inputString = Console.ReadLine();
                validFormat = int.TryParse(inputString, out pieces);
            }
            pieces = int.Parse(inputString);

            // Check for correct weight range
            if (pieces < 1 || pieces > 20)
            {
                Console.WriteLine("Please enter a Valid number of pieces between 1 and 20");
                inputString = Console.ReadLine();
                CheckValidNumberOfpieces(inputString);
            }

            // return weight in correct range
            return pieces;
        }
        public static string CheckNotEmpty(string inputString)
        {
            while (inputString == String.Empty)
            {
                Console.WriteLine("Please enter a value");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
        
        public static DateTime CheckValidDate(string inputString) // "YYYY-MM-DD"
        {
            DateTime dDate;
            bool validFormat = DateTime.TryParse(inputString, out dDate);
            // Check for correct format
            while (!validFormat)
            {
                Console.WriteLine("Please enter a Valid date YYYY-MM-DD");
                inputString = Console.ReadLine();
                validFormat = DateTime.TryParse(inputString, out dDate);
            }
            dDate = DateTime.Parse(inputString);

            // Check for date not in the past
            if (dDate < DateTime.Now)
            {
                Console.WriteLine("Please enter a date not in the past");
                inputString = Console.ReadLine();
                CheckValidDate(inputString);
            }

            // return date that is in the correct format and not in the past
            return dDate;
        }    
        public static string PrintFood(Food FoodItem)
        {
            if (FoodItem is VeganMeat) 
            {
                VeganMeat veganMeat = (VeganMeat)FoodItem; // casting the item to vegan meat
                string veganMeatString = $"{veganMeat.name}, {veganMeat.cut}, {veganMeat.weight}, {veganMeat.storageTemperature}, {veganMeat.useByDate}, {veganMeat.packaging}";
                return veganMeatString;
            } 
            else if (FoodItem is Grain)
            {
                Grain grain = (Grain)FoodItem;
                string grainString = $"{grain.name}, {grain.type}, {grain.volume}, {grain.storageTemperature}, {grain.bestBeforeDate}, {grain.packaging}";
                return grainString;
            }
            else if (FoodItem is Fruit)
            {
                Fruit fruit = (Fruit)FoodItem;
                string fruitString = $"{fruit.name}, {fruit.type}, {fruit.numberOfPieces}, {fruit.storageTemperature}, {fruit.useByDate}, {fruit.packaging}";
                return fruitString;                
            }
            else if (FoodItem is Vegetable)
            {
                Vegetable vegetable = (Vegetable)FoodItem;
                string vegetableString = $"{vegetable.name}, {vegetable.weight}, {vegetable.storageTemperature}, {vegetable.bestBeforeDate}, {vegetable.packaging}";
                return vegetableString;      
            }
            string defaultString = "N/A";
            return defaultString;

        }  
    }
}
namespace FoodLibrary
#nullable disable
{
    public static class FileIO
    {
        public static List<string> ReadInFile(string input)
        {
            while(!File.Exists(input))
            {
                Console.WriteLine("File does not exist. Please enter a valid file path.");
                input = Console.ReadLine();
            }
            List<string> lines = File.ReadAllLines(input).ToList();
            Console.WriteLine("File has been read.");
            return lines;
        }
    
        public static Dictionary<string, int> PareseFileStorage(List<string> lines)
        {
            try
            {
                Dictionary<string, int> capacityDict = new Dictionary<string, int>();
                for (int i = 0; i < 3; i++)
                {
                    string[] Data = lines[i].Split(',');
                    if (Data[0] == "Freezer")
                    {
                        capacityDict.Add("Freezer", int.Parse(Data[1]));
                    }
                    else if (Data[0] == "Fridge")
                    {
                        capacityDict.Add("Fridge", int.Parse(Data[1]));
                    }
                    else if (Data[0] == "Pantry")
                    {
                        capacityDict.Add("Pantry", int.Parse(Data[1]));
                    }
                }
                return capacityDict;

            }
            catch (Exception)
            {
                Console.WriteLine("Storage facility invalid, storage will not be constructed from this file.");
                Console.WriteLine("Provide storage file with valid storage formatting");
                string input = Console.ReadLine();
                FileIO.ReadInFile(input);
                return null;
            }
        }
        public static List<Food> ParseFileData(List<string> lines)
        {
            Food food = null;
            List<Food> foodList = new List<Food>();
            
            for (int i = 3; i > 2 && i < lines.Count; i++)
            {
                try
                {
                    string[] foodDataArray = lines[i].Split(',');
                    if (foodDataArray[0] == "Meat")
                    {
                        string meatName = foodDataArray[1].Trim();
                        string meatCut = foodDataArray[2].Trim();
                        double meatWeight = double.Parse(foodDataArray[3]);
                        double meatStorageTemperature = double.Parse(foodDataArray[4]);
                        DateTime meatUseByDate = DateTime.Parse(foodDataArray[5]);
                        string meatPackaging = foodDataArray[6].Trim();

                        if (meatWeight < 0.2 || meatWeight > 5.0 || meatUseByDate < DateTime.Now)
                        {
                            Console.WriteLine("Items weight or date is invalid. Item will not be added to storage.");
                        }
                        else
                        {
                            food = new VeganMeat(meatName, meatCut, meatWeight, meatStorageTemperature, meatUseByDate, meatPackaging);
                            foodList.Add(food);
                        }
                    }
                    else if (foodDataArray[0] == "Grain")
                    {
                        string grainName = foodDataArray[1].Trim();
                        string grainType = foodDataArray[2].Trim();
                        double grainVolume = double.Parse(foodDataArray[3]);
                        double grainStorageTemperature = double.Parse(foodDataArray[4]);
                        DateTime grainBestBeforeDate = DateTime.Parse(foodDataArray[5]);
                        string grainPackaging = foodDataArray[6].Trim();

                        if (grainVolume < 0.2 || grainVolume > 5.0 || grainBestBeforeDate < DateTime.Now)
                        {
                            Console.WriteLine("Items volume or date is invalid. Item will not be added to storage.");
                        }
                        else
                        {
                            food = new Grain(grainName, grainType, grainVolume, grainStorageTemperature, grainBestBeforeDate, grainPackaging);
                            foodList.Add(food);

                        }
                    }
                    else if (foodDataArray[0] == "Fruit")
                    {
                        string fruitName = foodDataArray[1].Trim();
                        string fruitType = foodDataArray[2].Trim();
                        int fruitNumberOfPieces = int.Parse(foodDataArray[3]);
                        double fruitStorageTemperature = double.Parse(foodDataArray[4]);
                        DateTime fruitUseByDate = DateTime.Parse(foodDataArray[5]);
                        string fruitPackaging = foodDataArray[6].Trim();

                        if (fruitNumberOfPieces < 1 || fruitNumberOfPieces > 20 || fruitUseByDate < DateTime.Now)
                        {
                            Console.WriteLine("Items number of pieces or date is invalid. Item will not be added to storage.");

                        }
                        else
                        {
                            food = new Fruit(fruitName, fruitType, fruitNumberOfPieces, fruitStorageTemperature, fruitUseByDate, fruitPackaging);
                            foodList.Add(food);                        
                        }
                    }
                    else if (foodDataArray[0] == "Vegetable")
                    {
                        string vegetableName = foodDataArray[1].Trim();
                        double vegetableWeight= double.Parse(foodDataArray[2]);
                        double vegetableStorageTemperature = double.Parse(foodDataArray[3]);
                        DateTime vegetableBestBeforeDate = DateTime.Parse(foodDataArray[4]);
                        string vegetablePackaging = foodDataArray[5].Trim();

                        if (vegetableWeight < 0.2 || vegetableWeight > 5.0 || vegetableBestBeforeDate < DateTime.Now)
                        {
                            Console.WriteLine("Items weight or date is invalid. Item will not be added to storage.");
                        }
                        else
                        {
                            food = new Vegetable(vegetableName, vegetableWeight, vegetableStorageTemperature, vegetableBestBeforeDate, vegetablePackaging);
                            foodList.Add(food);                        
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Item {0} is invalid. Item will not be added to storage.", i-4);
                }
            }
        return foodList;
        }
    
    public static void WriteToFile(Storage storage) 
        {
            Console.WriteLine("Enter file save location directory: ");
            string FileDirectory = Console.ReadLine();
            while(!Directory.Exists(FileDirectory))
            {
                Console.WriteLine(@"File directory incorrect. Enter a valid file directory, e.g. C:\Users\Lillyt\Desktop\GIT\OOAssignment\IntroUI\Files\");
                FileDirectory = Console.ReadLine();
            }

            Console.WriteLine("Enter file name: ");
            string FileName = Console.ReadLine();
            List<string> output = new List<string>();
            
            output.Add("Pantry, " + (storage.pantryMaximumCapacity - storage.storageSection[2].count));
            output.Add("Freezer, " + (storage.freezerMaximumCapacity - storage.storageSection[0].count));
            output.Add("Fridge, " + (storage.fridgeMaximumCapacity - storage.storageSection[1].count));

            for (int i = 0; i < 3; i++)
            {
                for (int containerSection = 0; containerSection < storage.storageSection[i].count; containerSection++)
                {
                    output.Add(Common.PrintFood(storage.storageSection[i].container[containerSection]));
                }
            }
            
            File.WriteAllLines(FileDirectory + FileName, output);
        }
    }
}

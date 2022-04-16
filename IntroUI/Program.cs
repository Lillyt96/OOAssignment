#nullable disable
using System;
using System.Configuration;
using FoodLibrary;
using System.IO;

namespace IntroUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file to read in");
            string input = Console.ReadLine();
            List<string> lines = FileIO.ReadInFile(input);
            Dictionary<string, int> capacityDict = FileIO.PareseFileStorage(lines);
            Storage storage = new Storage(capacityDict["Freezer"], capacityDict["Fridge"], capacityDict["Pantry"]);
            List<Food> foodList = FileIO.ParseFileData(lines); //return food array
            for (int i = 0; i < foodList.Count; i++) //add elements of food array
            {
                storage.add(foodList[i]);
            }

            bool mainMenu = true;

            while(mainMenu)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1 - Add food");
                Console.WriteLine("2 - Remove food");
                Console.WriteLine("3 - Find expired");
                Console.WriteLine("4 - Display contents");
                Console.WriteLine("5 - Write out storage");
                Console.WriteLine("6 - Exit");
                Console.Write("\r\nSelect an option: ");

                string prompt = Console.ReadLine();
                bool validMenuInput = false;
                while (!validMenuInput)
                { 
                    switch(Common.ReadUserInt(prompt))
                    {
                        case 1:
                            validMenuInput = true;
                            Food foodItem = new Food();
                            storage.add(foodItem.GenerateFood());
                            break;
                        case 2:
                            validMenuInput = true;
                            storage.remove();

                            break;
                        case 3:
                            validMenuInput = true;
                            Console.WriteLine(storage.fridgeMaximumCapacity);
                            storage.DisplayExpired(storage);
                            break;
                        case 4:
                            validMenuInput = true;
                            storage.DisplayContents(storage);

                            break;
                        case 5:
                            validMenuInput = true;
                            FileIO.WriteToFile(storage);
                            break;
                        case 6:
                            validMenuInput = true;
                            Console.WriteLine("Application Exiting.");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Please enter a valid value");
                            prompt = Console.ReadLine();
                            break;
                    }
                }
            }
        }
    }
}



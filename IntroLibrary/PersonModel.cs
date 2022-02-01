namespace FoodLibrary
#nullable disable

{
    public class Food
    
    {
        public string Name;
        public double StorageTemperature;
        public string Packaging;
        public class VeganMeat : Food
        {
            public string Cut;
            public double Weight;
            public string UseByDate;

        }
        public class Grain : Food
        {
            public string Type;
            public double Volume;
            public string BestBeforeDate;

        }
        public class Fruit : Food
        {
            public string Type;
            public int NumberOfPieces;
            public string BestBeforeDate;

        }
        public class Vegetable : Food
        {
            public double Weight;
            public string BestBeforeDate;
        }

    }
    public class Counter
    {
            public int Pantry = 0; //change to read the counter in file 
            public int Freezer = 0; //change to read the counter in file 
            public int Fridge = 0;

    }

    public class Menu
    {
        public Counter counter;
        public Food[][] Storage;
        public Menu()
        {
            counter = new Counter();
            Storage = new Food[3][];
            Storage[0] = new Food[20]; //Freezer
            Storage[1] = new Food[50]; //Fridge
            Storage[2] = new Food[100]; //Pantry
        }
        public void MainMenu()
        {
            Console.WriteLine(Storage[0][0]?.Name);
            Console.WriteLine(Storage[0][1]?.Name);
            Console.WriteLine(Storage[1][0]?.Name);
            Console.WriteLine(Storage[2][0]?.Name);
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Add food");
            Console.WriteLine("2 - Display contents");
            Console.WriteLine("3 - Find expired");
            Console.WriteLine("4 - Read in storage");
            Console.WriteLine("5 - Write out storage");
            Console.WriteLine("6 - Exit");
            Console.Write("\r\nSelect an option: ");
            
            int option = int.Parse(Console.ReadLine());

            switch(option)
            {
                case 1: //Add Food
                    AddFoodMenu();
                break;
            }            
        }
        public void AddToLocation(Food FoodType)
        {
            if  (FoodType.StorageTemperature > -27.0 && FoodType.StorageTemperature <-5.0)
            {
                Storage[0][counter.Freezer] = FoodType;
                counter.Freezer++;
                Console.WriteLine("Item {0} added to the Freezer storage", FoodType.Name);
            }
            else if (FoodType.StorageTemperature >-2.0 && FoodType.StorageTemperature <6.0) // For Fridge
            {
                Storage[1][counter.Fridge] = FoodType;
                counter.Fridge++;
                Console.WriteLine("Item {0} added to the Fridge storage", FoodType.Name);
            } 
            else if (FoodType.StorageTemperature >8.0 && FoodType.StorageTemperature <25.0) // For Pantry
            {
                Storage[2][counter.Pantry] = FoodType;
                counter.Pantry++;
                Console.WriteLine("Item {0} added to the pantry storage", FoodType.Name);
            } 
            else
            {
                Console.WriteLine("Error Invalid - Food item out of the storage temperature range");
            }
        }
        public void AddFoodMenu()
        {
            Console.WriteLine("Choose a food item to add");
            Console.WriteLine("1 - Meat");
            Console.WriteLine("2 - Grain");
            Console.WriteLine("3 - Fruit");
            Console.WriteLine("4 - Vegetable");
            Console.Write("\r\nSelect an option: ");

            int AddFoodOption = int.Parse(Console.ReadLine());
            switch(AddFoodOption)
            {
                case 1:
                    //code for adding meat
                    Food.VeganMeat Meat = new Food.VeganMeat();
                    Console.Write("Enter meat name: ");
                    Meat.Name = Console.ReadLine();

                    Console.Write("Enter meat cut: ");
                    Meat.Cut = Console.ReadLine();

                    Console.Write("Enter meat weight (kgs): ");
                    Meat.Weight = float.Parse(Console.ReadLine());

                    Console.Write("Enter meat storage temp: ");
                    Meat.StorageTemperature = float.Parse(Console.ReadLine());

                    Console.Write("Enter meat useby date: "); //make consistent formating
                    Meat.UseByDate = Console.ReadLine();

                    Console.Write("Enter meat packaging: ");
                    Meat.Packaging = Console.ReadLine();

                    AddToLocation(Meat);
                    ReturnToMenu();
                    break;

                case 2:
                    Console.Write("add grain code");
                    break;
                
                case 3:
                    Console.Write("add fruit code");
                    break;
                case 4:
                    Console.Write("add vegetable code");
                    break;
            }
        }
        public void ReturnToMenu()
        {
            Console.WriteLine("Would you like to add another item? (Y/N)");
            string c = Console.ReadLine();
            if (c == "Y") 
            {
                AddFoodMenu();
            }
            else if (c == "N")
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Please enter Y or N");
                ReturnToMenu();
            }
        }
    }

}


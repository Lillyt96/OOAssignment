namespace FoodLibrary
#nullable disable

{
    public class Food
    {
        public string Name;
        public double StorageTemperature;
        public string Packaging;
    }
    public class VeganMeat : Food
    {
        public string Cut;
        public double Weight;
        public int UseByDate;
    }
    public class Grain : Food
    {
        public string Type;
        public double Volume;
        public int BestBeforeDate;
    }
    public class Fruit : Food
    {
        public string Type;
        public int NumberOfPieces;
        public int UseByDate;
    }
    public class Vegetable : Food
    {
        public double Weight;
        public int BestBeforeDate;
    }

    public class Counter
    {
            public int Pantry = 0; //change to read the counter in file 
            public int Freezer = 0; //change to read the counter in file 
            public int Fridge = 0;

    }
    public class DateToday
    {
        public int Date;
    }
    public class ReadFile
    {
        public List<string> File;
    }
    public class Functions
    {
        public Counter counter;
        public Food[][] Storage;
        public DateToday Today;
        public ReadFile Lines;
        public Functions()
        {   
           //creating an object for the file
            Lines = new ReadFile();
            string FilePath = @"C:\Users\KEBAB\Desktop\LearnC#\Input.txt";
            List<string> lines = File.ReadAllLines(FilePath).ToList();
            Lines.File = lines;

            //reading in the storage data 

            string[] PantryData = lines[0].Split(',');
            int PantryStorage = int.Parse(PantryData[1]);

            string[] FreezerData = lines[1].Split(',');
            int FreezerStorage = int.Parse(FreezerData[1]);

            string[] FridgeData = lines[2].Split(',');
            int FridgeStorage = int.Parse(FridgeData[1]);

            counter = new Counter();
            Storage = new Food[3][];
            Storage[0] = new Food[FreezerStorage]; //Freezer
            Storage[1] = new Food[FridgeStorage]; //Fridge
            Storage[2] = new Food[PantryStorage]; //Pantry
            Today = new DateToday();
            DateTime today = DateTime.Today;
            Today.Date = int.Parse(today.ToString("yyyyMMdd"));
        }
        public void ReadFile()
        {
           
            for (int i = 4; i > 3 && i < Lines.File.Count; i++)
            {
                string[] FoodDataArray = Lines.File[i].Split(',');

                if (FoodDataArray[0] == "Meat")
                {
                    AddToLocation(CreateVeganMeatItem(FoodDataArray[1], FoodDataArray[2], FoodDataArray[3], FoodDataArray[4], FoodDataArray[5], FoodDataArray[6]));
                }
            }
        }
        public void MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Add food");
            Console.WriteLine("2 - Remove food");
            Console.WriteLine("3 - Find expired");
            Console.WriteLine("4 - Display contents");
            Console.WriteLine("5 - Read in storage");
            Console.WriteLine("6 - Write out storage");
            Console.WriteLine("7 - Exit");
            Console.Write("\r\nSelect an option: ");
            
            int option = int.Parse(Console.ReadLine());
            if (option < 1 || option > 7)
            {
                Console.Write("Please select a valid option");
                MainMenu();
            }
            else
            {
                switch(option)
                {
                    case 1: //Add Food
                        AddFoodMenu();
                        break;
                    case 2: //Remove item
                        RemoveItemMenu();
                        break;
                    case 3: //Find Expired
                        FindExpired();
                        break;
                    case 4: //Return Storage Contents
                        DisplayContents();
                        break;


                }   
                   
            }
        
        }
        public void AddToLocation(Food FoodType)
        {
        
        if  (FoodType.StorageTemperature > -27.0 && FoodType.StorageTemperature <-5.0)
        {
            if (counter.Freezer == 20)
            {
                Console.WriteLine("Error - Freezer storage is full. Returning to the main menu.");
                MainMenu();
            }
            else
            {
                Storage[0][counter.Freezer] = FoodType;
                counter.Freezer++;
                Console.WriteLine("Item {0} added to the Freezer storage", FoodType.Name);
            }
        }
        else if (FoodType.StorageTemperature >-2.0 && FoodType.StorageTemperature <6.0) // For Fridge
        {
            if (counter.Fridge == 50)
            {
                Console.WriteLine("Error - Fridge storage is full. Returning to the main menu.");
                MainMenu();
            }
            else
            {
                Storage[1][counter.Fridge] = FoodType;
                counter.Fridge++;
                Console.WriteLine("Item {0} added to the Fridge storage", FoodType.Name);
            }
        } 
        else if (FoodType.StorageTemperature >8.0 && FoodType.StorageTemperature <25.0) // For Pantry
        {
            if (counter.Fridge == 50)
            {
                Console.WriteLine("Error - Fridge storage is full. Returning to the main menu.");
                MainMenu();
            }
            else
            {
                Storage[2][counter.Pantry] = FoodType;
                counter.Pantry++;
                Console.WriteLine("Item {0} added to the pantry storage", FoodType.Name);  
            }                
        } 
            // else
            // {
            //     Console.WriteLine("Error Invalid - Food item out of the storage temperature range");
            // }
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
            if (AddFoodOption < 1 || AddFoodOption > 4)
            {
                Console.Write("Please select a valid option");
                AddFoodMenu();
            }
            else
            {
                switch(AddFoodOption)
                {
                    case 1:
                        //code for adding meat
                        Console.Write("Enter meat name: ");
                        string Name = Console.ReadLine();

                        Console.Write("Enter meat cut: ");
                        string Cut = Console.ReadLine();

                        Console.Write("Enter meat weight (between 0.2 - 5.0): ");

                        string Weight = Console.ReadLine();

                        Console.Write("Enter meat storage temp between -27.0 and 25.0: ");

                        string StorageTemperature = Console.ReadLine();
                        
                        Console.Write("Enter meat useby date YYYYMMDD: "); 
                        string UseByDate = Console.ReadLine();

                        Console.Write("Enter meat packaging: ");
                        string Packaging = Console.ReadLine();
                        AddToLocation(CreateVeganMeatItem(Name, Cut, Weight, StorageTemperature, UseByDate, Packaging));
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
                        
                Console.WriteLine("Would you like to add another item? (Y/N)");
                string c = Console.ReadLine();
                if (c == "Y" || c == "y") 
                {
                    AddFoodMenu();
                }
                else if (c == "N" || c == "n")
                {
                    MainMenu();
                }
            }
        }   
        public void RemoveItemMenu()
        {
            Console.WriteLine("Which storage location would you like to remove an item from?");
            Console.WriteLine("1 - Freezer");
            Console.WriteLine("2 - Fridge");
            Console.WriteLine("3 - Pantry");
            Console.Write("\r\nSelect an option: ");
            
            int RemoveFoodLocation = int.Parse(Console.ReadLine());
            if (RemoveFoodLocation < 1 || RemoveFoodLocation > 3)
            {
                Console.WriteLine("Please select a valid option");
                RemoveItemMenu();
            }
            else
            {
                switch(RemoveFoodLocation)
                {
                    case 1:
                        RemoveItem(counter.Freezer, 0);
                        break;

                    case 2:
                        RemoveItem(counter.Fridge, 1);
                        break;
                    case 3:
                        RemoveItem(counter.Pantry, 2);
                        break;
                }
            }
            Console.WriteLine("Would you like to remove another item?");
            string c = Console.ReadLine();
            if (c == "Y") 
            {
                RemoveItemMenu();
            }
            else if (c == "N")
            {
                MainMenu();
            }

        }
        public void RemoveItem(int StorageCounter, int StorageNumber)
        {

            if (StorageCounter != 0)
            {
                Console.WriteLine("Enter a location number between 0 and " + (StorageCounter - 1));
                int pos = int.Parse(Console.ReadLine());
                Console.WriteLine("Item " + Storage[StorageNumber][pos].Name + " has been removed.");    

                for (var i = pos; i < StorageCounter ; i++) 
                {
                    Storage[StorageNumber][i] = Storage[StorageNumber][i + 1];
                }

                if(StorageNumber == 0)
                {
                    counter.Freezer--;
                }
                else if(StorageNumber == 1)
                {
                    counter.Fridge--;
                }
                else if(StorageNumber == 2)
                {
                    counter.Pantry--;
                }
            }
            else
            {
                Console.WriteLine("Storage is empty. Returning to main menu");
                MainMenu();
            }
        }
        public void FindExpired()
        {
            //should cycle through all items in the Find expired storage facility looking for expired food. If food has expired, the program should output the details, including the location, to the user. 
            for (int i = 0; i < counter.Freezer; i++) //Freezer check
            {
                if (Storage[0][i] is VeganMeat) 
                {
                    VeganMeat veganMeat = (VeganMeat)Storage[0][i];
                    if (veganMeat.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(veganMeat);
                        Console.WriteLine("Food Storage Location [0][{0}]", i);
                    }
                }
                else if (Storage[0][i] is Fruit) 
                {
                    Fruit fruit = (Fruit)Storage[0][i];
                    if (fruit.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(fruit);
                        Console.WriteLine("Food Storage Location [0][{0}]", i);
                    }
                }
            }
            for (int i = 0; i < counter.Fridge; i++) //Fridge check
            {
                if (Storage[1][i] is VeganMeat) 
                {
                    VeganMeat veganMeat = (VeganMeat)Storage[1][i];
                    if (veganMeat.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(veganMeat);
                        Console.WriteLine("Food Storage Location [1][{0}]", i);
                    }
                }
                else if (Storage[1][i] is Fruit) 
                {
                    Fruit fruit = (Fruit)Storage[1][i];
                    if (fruit.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(fruit);
                        Console.WriteLine("Food Storage Location [1][{0}]", i);
                    }
                }
            }
            for (int i = 0; i < counter.Pantry; i++) //Pantry check
            {
                if (Storage[2][i] is VeganMeat) 
                {
                    VeganMeat veganMeat = (VeganMeat)Storage[2][i];
                    if (veganMeat.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(veganMeat);
                        Console.WriteLine("Food Storage Location [2][{0}]", i);
                    }
                }
                else if (Storage[2][i] is Fruit) 
                {
                    Fruit fruit = (Fruit)Storage[2][i];
                    if (fruit.UseByDate < Today.Date)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(fruit);
                        Console.WriteLine("Food Storage Location [2][{0}]", i);
                    }
                }
            }
            Console.WriteLine("Returning back to Main Menu");
            MainMenu();
        }
        public void PrintFood(Food FoodItem)
        {
            if (FoodItem is VeganMeat) 
            {
                VeganMeat veganMeat = (VeganMeat)FoodItem; // casting the item to vegan meat

                Console.WriteLine(
                    "Vegan Meat Name: " + veganMeat.Name
                    + "\nVegan Meat Storage Temperature: " + veganMeat.StorageTemperature
                    + "\nVegan Meat Packaging Type: " + veganMeat.Packaging 
                    + "\nVegan Meat Cut " + veganMeat.Cut 
                    + "\nVegan Meat Usedby Date: " + veganMeat.UseByDate
                    + "\nVegan Meat Weight: " + veganMeat.Weight
                );
            } 
            else if (FoodItem is Grain)
            {
                Grain grain = (Grain)FoodItem;
                Console.WriteLine(
                    "Grain Name: " + grain.Name
                    + "\nGrain Storage Temperature: " + grain.StorageTemperature
                    + "\nGrain Packaging Type: " + grain.Packaging 
                    + "\nGrain Type " + grain.Type 
                    + "\nGrain Volume: " + grain.Volume
                    + "\nGrain Best Before Date: " + grain.BestBeforeDate
                );
            }
            else if (FoodItem is Fruit)
            {
                Fruit fruit = (Fruit)FoodItem;
                Console.WriteLine(
                    "Fruit Name: " + fruit.Name
                    + "\nFruit Storage Temperature: " + fruit.StorageTemperature
                    + "\nFruit Packaging Type: " + fruit.Packaging 
                    + "\nFruit Type " + fruit.Type 
                    + "\nFruit Number of pieces: " + fruit.NumberOfPieces
                    + "\nFruit Used By Date: " + fruit.UseByDate
                );                  
            }
            else if (FoodItem is Vegetable)
            {
                Vegetable vegetable = (Vegetable)FoodItem;
                Console.WriteLine(
                    "Vegetable Name: " + vegetable.Name
                    + "\nVegetable Storage Temperature: " + vegetable.StorageTemperature
                    + "\nVegetable Packaging Type: " + vegetable.Packaging 
                    + "\nVegetable Weight " + vegetable.Weight 
                    + "\nVegetable Best Before Date: " + vegetable.BestBeforeDate
                );            
            }
        }
        public void DisplayContents() //should output to the screen all th Display contents e contents of a particular storage location –
        {
            Console.WriteLine("Choose a storage location to view:");
            Console.WriteLine("1 - Freezer");
            Console.WriteLine("2 - Fridge");
            Console.WriteLine("3 - Pantry");
            Console.Write("\r\nSelect an option: ");
            
            int RevealStorageData = int.Parse(Console.ReadLine());
            switch(RevealStorageData)
            {
                case 1:
                    for (int i = 0; i < counter.Freezer; i++)
                    {
                        Console.WriteLine("Item {0}", i);
                        PrintFood(Storage[0][i]);
                        Console.WriteLine("\n");
                    }
                    break;
                
                case 2:
                    for (int i = 0; i < counter.Fridge; i++)
                    {
                        Console.WriteLine("Item {0}", i);
                        PrintFood(Storage[1][i]);
                        Console.WriteLine("\n");
                    }
                    break;
                
                case 3:
                    for (int i = 0; i < counter.Pantry; i++)
                    {
                        Console.WriteLine("Item {0}", i);
                        PrintFood(Storage[2][i]);
                        Console.WriteLine("\n");
                    }
                    break;
            }

        }
        public VeganMeat CreateVeganMeatItem(String Name, String Cut, String Weight, String StorageTemperature, String UseByDate, String Packaging)
        {
            VeganMeat Meat = new VeganMeat();
            Meat.Name = Name;
            Meat.Cut = Cut;
            double weight = double.Parse(Weight);
            if (weight > 0.2 && weight < 5.0)
            {
                Meat.Weight = weight;
            }
            else
            {
                Console.WriteLine("Error Invalid - Food item out of the weight range range.");
                Console.WriteLine("Item will not be added.");
            }
            double storagetemperature = double.Parse(StorageTemperature);
            if (storagetemperature > -27.0 && storagetemperature < 25.0)
            {
                Meat.StorageTemperature = storagetemperature;
            }
            else
            {
                Console.WriteLine("Error Invalid - Food item out of the storage temperature range. \nItem has not been added.");
                break; //the issue here is that the storagetemp is being constructed with the default value of 0. not running out of the loop. 
            }
            int usebydate = int.Parse(UseByDate);

            if(usebydate > Today.Date)
            {
                Meat.UseByDate = usebydate;
            }
            else
            {
                Console.WriteLine("Error Invalid - Food item use by is in the past.");
                Console.WriteLine("Item will not be added.");                        
            }

            Meat.Packaging = Packaging;

            return Meat;
            
        }

    }
}




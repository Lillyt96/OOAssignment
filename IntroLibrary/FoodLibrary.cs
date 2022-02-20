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
            string FilePath = @"C:\Users\Lillyt\Desktop\GIT\OOAssignment\Input.txt";
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
                    CreateVeganMeatItem(FoodDataArray[1], FoodDataArray[2], FoodDataArray[3], FoodDataArray[4], FoodDataArray[5], FoodDataArray[6]);
                }
                else if (FoodDataArray[0] == "Grain")
                {
                    CreateGrainItem(FoodDataArray[1], FoodDataArray[2], FoodDataArray[3], FoodDataArray[4], FoodDataArray[5], FoodDataArray[6]);
                }
                else if (FoodDataArray[0] == "Fruit")
                {
                    CreateFruitItem(FoodDataArray[1], FoodDataArray[2], FoodDataArray[3], FoodDataArray[4], FoodDataArray[5], FoodDataArray[6]);
                }
                else if (FoodDataArray[0] == "Vegetable")
                {
                    CreateVegetableItem(FoodDataArray[1], FoodDataArray[2], FoodDataArray[3], FoodDataArray[4], FoodDataArray[5]);
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
                        string MeatName = Console.ReadLine();

                        Console.Write("Enter meat cut: ");
                        string MeatCut = Console.ReadLine();

                        Console.Write("Enter meat weight (between 0.2 - 5.0): ");

                        string MeatWeight = Console.ReadLine();

                        Console.Write("Enter meat storage temp between -27.0 and 25.0: ");

                        string MeatStorageTemperature = Console.ReadLine();
                        
                        Console.Write("Enter meat useby date YYYYMMDD: "); 
                        string MeatUseByDate = Console.ReadLine();

                        Console.Write("Enter meat packaging: ");
                        string MeatPackaging = Console.ReadLine();
                        
                        CreateVeganMeatItem(MeatName, MeatCut, MeatWeight, MeatStorageTemperature, MeatUseByDate, MeatPackaging);
                        break;

                    case 2:
                        //code for adding grain
                        Console.Write("Enter grain name: ");
                        string GrainName = Console.ReadLine();

                        Console.Write("Enter grain type: ");
                        string GrainType = Console.ReadLine();

                        Console.Write("Enter grain weight (between 0.2 - 5.0): ");

                        string GrainWeight = Console.ReadLine();

                        Console.Write("Enter grain storage temp between -27.0 and 25.0: ");

                        string GrainStorageTemperature = Console.ReadLine();
                        
                        Console.Write("Enter grain best before date YYYYMMDD: "); 
                        string GrainBestBeforeDate = Console.ReadLine();

                        Console.Write("Enter grain packaging: ");
                        string GrainPackaging = Console.ReadLine();
                        
                        CreateGrainItem(GrainName, GrainType, GrainWeight, GrainStorageTemperature, GrainBestBeforeDate, GrainPackaging);

                        break;
                    
                    case 3:
                        // code for adding fruit
                        Console.Write("Enter fruit name: ");
                        string FruitName = Console.ReadLine();

                        Console.Write("Enter fruit type: ");
                        string FruitType = Console.ReadLine();

                        Console.Write("Enter fruit number of pieces (between 1 - 20): ");

                        string FruitNumberOfPieces = Console.ReadLine();

                        Console.Write("Enter fruit storage temp between -27.0 and 25.0: ");

                        string FruitStorageTemperature = Console.ReadLine();
                        
                        Console.Write("Enter fruit useby date YYYYMMDD: "); 
                        string FruitUsebyDate = Console.ReadLine();

                        Console.Write("Enter fruit packaging: ");
                        string FruitPackaging = Console.ReadLine();
                        
                        CreateFruitItem(FruitName, FruitType, FruitNumberOfPieces, FruitStorageTemperature, FruitUsebyDate, FruitPackaging);

                        break;

                    case 4:
                        //code for adding vegetable
                        Console.Write("Enter vegetable name: ");
                        string VegetableName = Console.ReadLine();

                        Console.Write("Enter vegetable weight (between 0.2 - 5.0): ");

                        string VegetableWeight = Console.ReadLine();

                        Console.Write("Enter vegetable storage temp between -27.0 and 25.0: ");

                        string VegetableStorageTemperature = Console.ReadLine();
                        
                        Console.Write("Enter vegetable best before date YYYYMMDD: "); 
                        string VegetableBestBeforeDate = Console.ReadLine();

                        Console.Write("Enter vegetable packaging: ");
                        string VegetablePackaging = Console.ReadLine();
                        
                        CreateVegetableItem(VegetableName, VegetableWeight, VegetableStorageTemperature, VegetableBestBeforeDate, VegetablePackaging);

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
                    + "\nVegan Meat Cut " + veganMeat.Cut 
                    + "\nVegan Meat Weight: " + veganMeat.Weight
                    + "\nVegan Meat Storage Temperature: " + veganMeat.StorageTemperature
                    + "\nVegan Meat Usedby Date: " + veganMeat.UseByDate
                    + "\nVegan Meat Packaging Type: " + veganMeat.Packaging 
                );
            } 
            else if (FoodItem is Grain)
            {
                Grain grain = (Grain)FoodItem;
                Console.WriteLine(
                    "Grain Name: " + grain.Name
                    + "\nGrain Type " + grain.Type 
                    + "\nGrain Volume: " + grain.Volume
                    + "\nGrain Storage Temperature: " + grain.StorageTemperature
                    + "\nGrain Best Before Date: " + grain.BestBeforeDate
                    + "\nGrain Packaging Type: " + grain.Packaging 
                );
            }
            else if (FoodItem is Fruit)
            {
                Fruit fruit = (Fruit)FoodItem;
                Console.WriteLine(
                    "Fruit Name: " + fruit.Name
                    + "\nFruit Type " + fruit.Type 
                    + "\nFruit Number of pieces: " + fruit.NumberOfPieces
                    + "\nFruit Storage Temperature: " + fruit.StorageTemperature
                    + "\nFruit Used By Date: " + fruit.UseByDate
                    + "\nFruit Packaging Type: " + fruit.Packaging 
                );                  
            }
            else if (FoodItem is Vegetable)
            {
                Vegetable vegetable = (Vegetable)FoodItem;
                Console.WriteLine(
                    "Vegetable Name: " + vegetable.Name
                    + "\nVegetable Weight " + vegetable.Weight 
                    + "\nVegetable Storage Temperature: " + vegetable.StorageTemperature
                    + "\nVegetable Best Before Date: " + vegetable.BestBeforeDate
                    + "\nVegetable Packaging Type: " + vegetable.Packaging 
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
        public void CreateVeganMeatItem(String Name, String Cut, String Weight, String StorageTemperature, String UseByDate, String Packaging)
        {
            double weight = double.Parse(Weight);
            double storagetemperature = double.Parse(StorageTemperature);
            int usebydate = int.Parse(UseByDate);

            if (weight > 0.2 && weight < 5.0 && storagetemperature > -27.0 && storagetemperature < 25.0 && usebydate > Today.Date)
            {
                VeganMeat Meat = new VeganMeat();
                Meat.Name = Name;
                Meat.Cut = Cut;
                Meat.Weight = weight;
                Meat.StorageTemperature = storagetemperature;
                Meat.UseByDate = usebydate;
                Meat.Packaging = Packaging;
                AddToLocation(Meat);
            }
            else
            {
                Console.WriteLine("Error Invalid -Item {0} will not be added.", Name);
            }
            
        }
        public void CreateGrainItem(String Name, String Type, String Volume, String StorageTemperature, String BestBeforeDate, String Packaging)
        {
            double volume = double.Parse(Volume);
            double storagetemperature = double.Parse(StorageTemperature);
            int bestbeforedate = int.Parse(BestBeforeDate);

            if (volume > 0.2 && volume < 5.0 && storagetemperature > -27.0 && storagetemperature < 25.0 && bestbeforedate > Today.Date)
            {
                Grain GrainItem = new Grain();
                GrainItem.Name = Name;
                GrainItem.Type = Type;
                GrainItem.Volume = volume;
                GrainItem.StorageTemperature = storagetemperature;
                GrainItem.BestBeforeDate = bestbeforedate;
                GrainItem.Packaging = Packaging;
                AddToLocation(GrainItem);
            }
            else
            {
                Console.WriteLine("Error Invalid -Item {0} will not be added.", Name);
            }
            
        }
        public void CreateFruitItem(String Name, String Type, String NumberofPieces, String StorageTemperature, String UseByDate, String Packaging)
        {
            int numberofPieces = int.Parse(NumberofPieces);
            double storagetemperature = double.Parse(StorageTemperature);
            int usebydate = int.Parse(UseByDate);

            if (numberofPieces > 1 && numberofPieces < 20 && storagetemperature > -27.0 && storagetemperature < 25.0 && usebydate > Today.Date)
            {
                Fruit FruitItem = new Fruit();
                FruitItem.Name = Name;
                FruitItem.Type = Type;
                FruitItem.NumberOfPieces = numberofPieces;
                FruitItem.StorageTemperature = storagetemperature;
                FruitItem.UseByDate = usebydate;
                FruitItem.Packaging = Packaging;
                AddToLocation(FruitItem);
            }
            else
            {
                Console.WriteLine("Error Invalid -Item {0} will not be added.", Name);
            }
            
        }
       
        public void CreateVegetableItem(String Name, String Weight, String StorageTemperature, String BestBeforeDate, String Packaging)
        {
            double weight = double.Parse(Weight);
            double storagetemperature = double.Parse(StorageTemperature);
            int bestbeforedate = int.Parse(BestBeforeDate);

            if (weight > 0.2 && weight < 5.0 && storagetemperature > -27.0 && storagetemperature < 25.0 && bestbeforedate > Today.Date)
            {
                Vegetable VegetableItem = new Vegetable();
                VegetableItem.Name = Name;
                VegetableItem.Weight = weight;
                VegetableItem.StorageTemperature = storagetemperature;
                VegetableItem.BestBeforeDate = bestbeforedate;
                VegetableItem.Packaging = Packaging;
                AddToLocation(VegetableItem);
            }
            else
            {
                Console.WriteLine("Error Invalid -Item {0} will not be added.", Name);
            }
            
        } 

    }
}




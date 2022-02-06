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
                    case 3:
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
                        VeganMeat Meat = new VeganMeat();
                        Console.Write("Enter meat name: ");
                        Meat.Name = Console.ReadLine();

                        Console.Write("Enter meat cut: ");
                        Meat.Cut = Console.ReadLine();

                        Console.Write("Enter meat weight (kgs): ");
                        Meat.Weight = float.Parse(Console.ReadLine());

                        Console.Write("Enter meat storage temp: ");
                        float StorageTemperature = float.Parse(Console.ReadLine());
                        if (StorageTemperature < -27.0 || StorageTemperature > 25.0)
                        {
                            Console.WriteLine("Error Invalid - Food item out of the storage temperature range.");
                            Console.WriteLine("Item has not been added.");
                            break;
                        }
                        else
                        {
                            Meat.StorageTemperature = StorageTemperature;
                        }

                        Console.Write("Enter meat useby date YYMMDD: "); //make consistent formating
                        Meat.UseByDate = int.Parse(Console.ReadLine());

                        Console.Write("Enter meat packaging: ");
                        Meat.Packaging = Console.ReadLine();

                        AddToLocation(Meat);
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
                if(Storage[0][i] is VeganMeat || Storage[0][i] is Fruit) 
                {
                    VeganMeat veganMeat = (VeganMeat)Storage[0][i];
                    if (veganMeat.UseByDate < 20220105)
                    {
                        Console.WriteLine("Food Details: ");
                        PrintFood(veganMeat);
                        Console.WriteLine("Food Storage Location [0][{0}]", i);
                    }
                }

            }

        }
        public void PrintFood(Food FoodItem)
        {
            if (FoodItem is VeganMeat) 
            {
                VeganMeat veganMeat = (VeganMeat)FoodItem;

                Console.WriteLine(
                    "Vegan Meat Name: " + veganMeat.Name
                    + " Vegan Meat Storage Temperature: " + veganMeat.StorageTemperature
                    + " Vegan Meat Packaging Type: " + veganMeat.Packaging 
                    + " Vegan Meat Cut " + veganMeat.Cut 
                    // + " Vegan Meat Usedby Date: " + veganMeat.UseByDate
                    + " Vegan Meat Weight: " + veganMeat.Weight
                );
            } 
            // else if (FoodItem == Food.Grain)
            // {
            //         Console.WriteLine(
            //         "Grain Name: " + Grain.Name
            //         + " Grain Storage Temperature: " + Grain.StorageTemperature
            //         + " Grain Packaging Type: " + Grain.Packaging 
            //         + " Grain Type " + Grain.Type 
            //         + " Grain Volume: " + Grain.Volume
            //         + " Grain Best Before Date: " + Grain.BestBeforeDate
            //     );
            // }
            // else if (FoodItem == Food.Fruit)
            // {
            //         Console.WriteLine(
            //         "Fruit Name: " + Fruit.Name
            //         + " Fruit Storage Temperature: " + Fruit.StorageTemperature
            //         + " Fruit Packaging Type: " + Fruit.Packaging 
            //         + " Fruit Type " + Fruit.Weight 
            //         + " Fruit Number of pieces: " + Fruit.NumberOfPieces
            //         + " Fruit Best Before Date: " + Fruit.BestBeforeDate
            //     );                  
            // }
            // else if (FoodItem == Food.Vegetable)
            // {
                    
            //         Console.WriteLine(
            //         "Vegetable Name: " + Food.Vegetable.Name
            //         + " Vegetable Storage Temperature: " + Food.Vegetable.StorageTemperature
            //         + " Vegetable Packaging Type: " + Food.Vegetable.Packaging 
            //         + " Vegetable Weight " + Food.Vegetable.Weight 
            //         + " Vegetable Best Before Date: " + Food.Vegetable.BestBeforeDate
            //     );            
            }
        }
    }




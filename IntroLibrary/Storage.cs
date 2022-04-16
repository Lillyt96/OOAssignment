namespace FoodLibrary
#nullable disable

{
    public class Storage
    {
        public int pantryMaximumCapacity;
        private const double PANTRYMIN = 8.0; 
        private const double PANTRYMAX = 25.0; 
        public int freezerMaximumCapacity;
        private const double FREEZERMIN = -27.0; 
        private const double FREEZERMAX = -5.0; 
        public int fridgeMaximumCapacity;
        private const double FRIDGEMIN = -2.0; 
        private const double FRIDGEMAX = 6.0; 
        public Container[] storageSection; 
        public Storage(int freezerStorage, int fridgeStorage, int pantryStorage)
        {
            pantryMaximumCapacity = pantryStorage;
            freezerMaximumCapacity = freezerStorage;
            fridgeMaximumCapacity = fridgeStorage;

            storageSection = new Container[3];
            storageSection[0] = new Container("freezer", freezerStorage, FREEZERMIN, FREEZERMAX);
            storageSection[1] = new Container("fridge", fridgeStorage, FRIDGEMIN, FRIDGEMAX);
            storageSection[2] = new Container("pantry", pantryStorage, PANTRYMIN, PANTRYMAX);
        }

        public void add(Food foodToAdd)
        {
            if  (foodToAdd.storageTemperature > FREEZERMIN && foodToAdd.storageTemperature < FREEZERMAX)
            {
                storageSection[0].add(foodToAdd);
            }
            else if  (foodToAdd.storageTemperature > FRIDGEMIN && foodToAdd.storageTemperature < FRIDGEMAX)
            {
                storageSection[1].add(foodToAdd);
            }   
            else if  (foodToAdd.storageTemperature > PANTRYMIN && foodToAdd.storageTemperature < PANTRYMAX)
            {
                storageSection[2].add(foodToAdd);
            }  
        }
        public void remove()
        {
            Console.WriteLine("Which storage location would you like to remove an item from?");
            Console.WriteLine("1 - Freezer");
            Console.WriteLine("2 - Fridge");
            Console.WriteLine("3 - Pantry");
            Console.Write("\r\nSelect an option: ");
            
            string Prompt = Console.ReadLine();
            bool LoopBreak = false;
            while (!LoopBreak)
            { 
                switch(Common.ReadUserInt(Prompt))
                {
                    case 1:
                        LoopBreak = true;
                        storageSection[0].Remove();
                        break;

                    case 2:
                        LoopBreak = true;
                        storageSection[1].Remove();
                        break;
                    case 3:
                        LoopBreak = true;
                        storageSection[2].Remove();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value");
                        Prompt = Console.ReadLine();
                        break;  
                }
            }
        }
    public void DisplayExpired(Storage storage)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int containerSection = 0; containerSection < storage.storageSection[i].count; containerSection++)
                {
                    if (storage.storageSection[i].container[containerSection] is VeganMeat) 
                    {
                        VeganMeat veganMeat = (VeganMeat)storage.storageSection[i].container[containerSection];
                        if (veganMeat.useByDate  < DateTime.Now)
                        {
                            Console.WriteLine("Expired Food Details: ");
                            Console.WriteLine(Common.PrintFood(veganMeat));
                            Console.WriteLine("Food Storage Location [{0}][{1}]", i, containerSection);
                        }
                    }
                    else if (storage.storageSection[i].container[containerSection] is Grain) 
                    {
                        Grain grain = (Grain)storage.storageSection[i].container[containerSection];
                        if (grain.bestBeforeDate < DateTime.Now)
                        {
                            Console.WriteLine("Expired Food Details: ");
                            Console.WriteLine(Common.PrintFood(grain));
                            Console.WriteLine("Food Storage Location [{0}][{1}]", i, containerSection);
                        }
                    }
                    else if (storage.storageSection[i].container[containerSection] is Fruit) 
                    {
                        Fruit fruit = (Fruit)storage.storageSection[i].container[containerSection];
                        if (fruit.useByDate < DateTime.Now)
                        {
                            Console.WriteLine("Expired Food Details: ");
                            Console.WriteLine(Common.PrintFood(fruit));
                            Console.WriteLine("Food Storage Location [{0}][{1}]", i, containerSection);
                        }
                    }
                    else if (storage.storageSection[i].container[containerSection] is Vegetable) 
                    {
                        Vegetable vegetable = (Vegetable)storage.storageSection[i].container[containerSection];
                        if (vegetable.bestBeforeDate < DateTime.Now)
                        {
                            Console.WriteLine("Expired Food Details: ");
                            Console.WriteLine(Common.PrintFood(vegetable));
                            Console.WriteLine("Food Storage Location [{0}][{1}]", i, containerSection);
                        }
                    }
                }
            }
         }
        public void DisplayContents(Storage storage) //should output to the screen all th Display contents e contents of a particular storage location –
        {
            Console.WriteLine("Choose a storage location to view:");
            Console.WriteLine("1 - Freezer");
            Console.WriteLine("2 - Fridge");
            Console.WriteLine("3 - Pantry");
            Console.Write("\r\nSelect an option: ");
            
            string Prompt = Console.ReadLine();
            bool LoopBreak = false;
            while (!LoopBreak)
            { 
                switch(Common.ReadUserInt(Prompt))
                {
                    case 1:
                        LoopBreak = true;
                        for (int containerSection = 0; containerSection < storage.storageSection[0].count; containerSection++)
                        {
                            Console.WriteLine("Item {0}", containerSection);
                            Console.WriteLine(Common.PrintFood(storage.storageSection[0].container[containerSection]));
                            Console.WriteLine("\n");
                        }
                        break;
                    case 2:
                        LoopBreak = true;
                        for (int containerSection = 0; containerSection < storage.storageSection[1].count; containerSection++)
                        {
                            Console.WriteLine("Item {0}", containerSection);
                            Console.WriteLine(Common.PrintFood(storage.storageSection[1].container[containerSection]));
                            Console.WriteLine("\n");
                        }
                        break;
                    case 3:
                        LoopBreak = true;
                        for (int containerSection = 0; containerSection < storage.storageSection[2].count; containerSection++)
                        {
                            Console.WriteLine("Item {0}", containerSection);
                            Console.WriteLine(Common.PrintFood(storage.storageSection[2].container[containerSection]));
                            Console.WriteLine("\n");
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid value");
                        Prompt = Console.ReadLine();
                        break;    
                }
            } 
        }
    }
}
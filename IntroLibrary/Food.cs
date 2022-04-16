namespace FoodLibrary
#nullable disable

{
    public class Food
    {
        public string name;
        public double storageTemperature;
        public string packaging;
    

        public Food GenerateFood()
        {
            Food food = null;
            Console.WriteLine("Choose a food item to add");
            Console.WriteLine("1 - Meat");
            Console.WriteLine("2 - Grain");
            Console.WriteLine("3 - Fruit");
            Console.WriteLine("4 - Vegetable");
            Console.Write("\r\nSelect an option: ");
            string promptFoodMenu = Console.ReadLine();
                        
            bool validAddFoodInput = false;
            while (!validAddFoodInput)
            {
                switch(Common.ReadUserInt(promptFoodMenu))
                {
                    case 1:                        
                        validAddFoodInput = true;
                        Console.WriteLine("Adding meat item...");

                        Console.Write("Enter meat name: ");
                        string meatName = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter meat cut: ");
                        string meatCut = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter meat weight (between 0.2 - 5.0): ");
                        double meatWeight = Common.CheckValidweight(Console.ReadLine());

                        Console.Write("Enter meat storage temp between -27.0 and 25.0: ");
                        double meatStorageTemperature = Common.CheckValidStorageTemp(Console.ReadLine());

                        Console.Write("Enter meat useby date YYYY-MM-DD: "); 
                        DateTime meatUseByDate = Common.CheckValidDate(Console.ReadLine());

                        Console.Write("Enter meat packaging: ");
                        string meatPackaging = Common.CheckNotEmpty(Console.ReadLine());
                        
                        // Create item & add it to storage
                        food = new VeganMeat(meatName, meatCut, meatWeight, meatStorageTemperature, meatUseByDate, meatPackaging);
                        break;

                    case 2:
                        validAddFoodInput = true;
                        Console.WriteLine("Adding grain item...");
                        Console.Write("Enter grain name: ");
                        string grainName = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter grain type: ");
                        string grainType = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter grain weight (between 0.2 - 5.0): ");

                        double grainWeight = Common.CheckValidweight(Console.ReadLine());

                        Console.Write("Enter grain storage temp between -27.0 and 25.0: ");

                        double grainStorageTemperature = Common.CheckValidStorageTemp(Console.ReadLine());
                        
                        Console.Write("Enter grain best before date:"); 
                        DateTime grainBestBeforeDate = Common.CheckValidDate(Console.ReadLine());

                        Console.Write("Enter grain packaging: ");
                        string grainPackaging = Common.CheckNotEmpty(Console.ReadLine());

                        food = new Grain(grainName, grainType, grainWeight, grainStorageTemperature, grainBestBeforeDate, grainPackaging);

                        break;
                    
                    case 3:
                        validAddFoodInput = true;
                        Console.WriteLine("Adding fruit item...");
                        Console.Write("Enter fruit name: ");
                        string fruitName = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter fruit type: ");
                        string fruitType = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter fruit number of pieces (between 1 - 20): ");

                        int fruitNumberOfPieces = Common.CheckValidNumberOfpieces(Console.ReadLine());

                        Console.Write("Enter fruit storage temp between -27.0 and 25.0: ");

                        double fruitStorageTemperature = Common.CheckValidStorageTemp(Console.ReadLine());
                        
                        Console.Write("Enter fruit useby date:"); 
                        DateTime fruitUsebyDate = Common.CheckValidDate(Console.ReadLine());

                        Console.Write("Enter fruit packaging: ");
                        string fruitPackaging = Common.CheckNotEmpty(Console.ReadLine());

                        food = new Fruit(fruitName, fruitType, fruitNumberOfPieces, fruitStorageTemperature, fruitUsebyDate, fruitPackaging);
                        break;

                    case 4:
                        validAddFoodInput = true;
                        Console.WriteLine("Adding vegetable item...");
                        Console.Write("Enter vegetable name: ");
                        string VegetableName = Common.CheckNotEmpty(Console.ReadLine());

                        Console.Write("Enter vegetable weight (between 0.2 - 5.0): ");

                        double VegetableWeight = Common.CheckValidweight(Console.ReadLine());

                        Console.Write("Enter vegetable storage temp between -27.0 and 25.0: ");

                        double VegetableStorageTemperature = Common.CheckValidStorageTemp(Console.ReadLine());
                        
                        Console.Write("Enter vegetable best before date:"); 
                        DateTime VegetableBestBeforeDate = Common.CheckValidDate(Console.ReadLine());

                        Console.Write("Enter vegetable packaging: ");
                        string VegetablePackaging = Common.CheckNotEmpty(Console.ReadLine());
                        break;
                 }
            }
            return food;
        }
    }
}   
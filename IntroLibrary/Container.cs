namespace FoodLibrary
#nullable disable

{
    public class Container
    {
        public string name;
        public int maximumCapacity;
        public int count;
        public double minTemperature;
        public double maxTemperature;
        public Food[] container;
        public Container(string name, int maximumCapacity, double minTemperature, double maxTemperature)
        {
            container = new Food[maximumCapacity];
            count = 0;
            this.name = name;
            this.maximumCapacity = maximumCapacity;
            this.minTemperature = minTemperature;
            this.maxTemperature = maxTemperature;
        }
        public void add(Food foodToAdd)
        {
            if (count < maximumCapacity)
            {
              container[count] = foodToAdd;
              count++;
            }
        }
        public void Remove()
        {
            if (count != 0)
            {
                Console.WriteLine("No of Storage items = {0}", count);
                Console.WriteLine("Enter a location number between 0 and {0}", count - 1);
                string prompt = Console.ReadLine();
                int pos = Common.ReadUserInt(prompt);
                while(pos > count - 1)
                {
                    Console.WriteLine("Please enter valid location number between 0 and {0}", count - 1);
                    prompt = Console.ReadLine();
                    pos = Common.ReadUserInt(prompt);
                }
                for (int i = pos; i < count; i++)
                {
                    container[i] = container[i + 1];
                }
                count--;
            }
            else
            {
                Console.WriteLine("Storage Empty");
            }
        }
    }
}

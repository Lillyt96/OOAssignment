namespace FoodLibrary
#nullable disable

{
    public class VeganMeat : Food
    {
        public string cut;
        public double weight;
        public DateTime useByDate;
        public VeganMeat(String meatName, String meatCut, double meatWeight, Double meatStorageTemperature, DateTime meatUseByDate, String meatPackaging)
        {
            name = meatName;
            cut = meatCut;
            weight = meatWeight;
            storageTemperature = meatStorageTemperature;
            useByDate = meatUseByDate;
            packaging = meatPackaging;
        }
    }
}
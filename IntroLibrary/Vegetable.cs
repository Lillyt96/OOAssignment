namespace FoodLibrary
#nullable disable

{
    public class Vegetable : Food
    {
        public double weight;
        public DateTime bestBeforeDate;
        public Vegetable(String vegetableName, Double vegetableWeight, Double vegetableStorageTemperature, DateTime vegetablebestBeforeDate, String vegetablePackaging)
        {
            name = vegetableName;
            weight = vegetableWeight;
            storageTemperature = vegetableStorageTemperature;
            bestBeforeDate = vegetablebestBeforeDate;
            packaging = vegetablePackaging;       
        } 
    }
}
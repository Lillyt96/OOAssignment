namespace FoodLibrary
#nullable disable

{
    public class Grain : Food
    {
        public string type;
        public double volume;
        public DateTime bestBeforeDate;
        public Grain(String grainName, String grainType, double grainVolume, double grainStorageTemperature, DateTime grainBestBeforeDate, String grainPackaging)
        {
            name = grainName;
            type = grainType;
            volume = grainVolume;
            storageTemperature = grainStorageTemperature;
            bestBeforeDate = grainBestBeforeDate;
            packaging = grainPackaging;        
        }
    }
}
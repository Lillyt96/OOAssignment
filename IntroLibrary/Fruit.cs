namespace FoodLibrary
#nullable disable
{
    public class Fruit : Food
    {
        public string type;
        public int numberOfPieces;
        public DateTime useByDate;
        public Fruit(String fruitName, String fruitType, int fruitNumberOfPieces, double fruitStorageTemperature, DateTime fruitUseByDate, String fruitPackaging)
        {
            name = fruitName;
            type = fruitType;
            numberOfPieces = fruitNumberOfPieces;
            storageTemperature = fruitStorageTemperature;
            useByDate = fruitUseByDate;
            packaging = fruitPackaging;
        }
    }
}
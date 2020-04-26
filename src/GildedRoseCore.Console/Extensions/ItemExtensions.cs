using ConsoleApplication;

namespace GildedRoseCore.Console.Extensions
{
    public static class ItemExtensions
    {
        public static void IncreaseQuality(this Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality += 1;
            }
        }
        
        public static void DecreaseQuality(this Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality -= 1;   
            }
        }
        
        public static void DecreaseSellIn(this Item item)
        {
            item.SellIn -= 1;
        }
    }
}
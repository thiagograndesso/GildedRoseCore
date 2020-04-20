using System;

namespace ConsoleApplication
{
    public class BackstagePassStrategy : IStrategy
    {
        public string Type { get; } = "Backstage passes to a TAFKAL80ETC concert";
        public void UpdateQuality(Item item)
        {
            item.IncreaseQuality();

            if (item.SellIn < 11)
            {
                item.IncreaseQuality();
            }
            
            if (item.SellIn < 6)
            {
                item.IncreaseQuality();
            }
            
            item.DecreaseSellIn();

            if (item.SellIn < 0)
            {
                item.Quality -= item.Quality;
            }
        }
    }
}
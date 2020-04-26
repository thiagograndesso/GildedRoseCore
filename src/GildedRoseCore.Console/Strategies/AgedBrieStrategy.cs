using ConsoleApplication;
using GildedRoseCore.Console.Extensions;

namespace GildedRoseCore.Console.Strategies
{
    public sealed class AgedBrieStrategy : IStrategy
    {
        public string Type { get; } = "Aged Brie";
        
        public void UpdateQuality(Item item)
        {
            item.IncreaseQuality();
            item.DecreaseSellIn();
            if (item.SellIn < 0)
            {
                item.IncreaseQuality();
            }
        }
    }
}
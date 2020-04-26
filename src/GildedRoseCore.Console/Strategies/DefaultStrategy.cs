using ConsoleApplication;
using GildedRoseCore.Console.Extensions;

namespace GildedRoseCore.Console.Strategies
{
    public sealed class DefaultStrategy : IStrategy
    {
        public string Type { get; } = "Default";
        public void UpdateQuality(Item item)
        {
            item.DecreaseQuality();
            
            item.DecreaseSellIn();
            
            if (item.SellIn < 0)
            {
                item.DecreaseQuality();        
            }
        }
    }
}
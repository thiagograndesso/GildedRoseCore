using System;

namespace ConsoleApplication
{
    public class ConjuredManaStrategy : IStrategy
    {
        public string Type { get; } = "Conjured Mana Cake";
        public void UpdateQuality(Item item)
        {
            item.DecreaseQuality();
            item.DecreaseQuality();
            
            item.DecreaseSellIn();
            
            if (item.SellIn < 0)
            {
                item.DecreaseQuality();
                item.DecreaseQuality();
                item.DecreaseQuality();
                item.DecreaseQuality();        
            }
        }
    }
}
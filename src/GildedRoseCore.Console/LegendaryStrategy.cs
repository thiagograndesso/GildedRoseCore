namespace ConsoleApplication
{
    public sealed class LegendaryStrategy : IStrategy
    {
        public string Type { get; } = "Sulfuras, Hand of Ragnaros";
        
        public void UpdateQuality(Item item)
        {
            // Legendary items won't have quality or sell in days updated
        }
    }
}
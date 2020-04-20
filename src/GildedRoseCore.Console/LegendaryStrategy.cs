namespace ConsoleApplication
{
    public class LegendaryStrategy : IStrategy
    {
        public string Type { get; } = "Sulfuras, Hand of Ragnaros";
        public void UpdateQuality(Item item)
        {
            // Won't do anything since item is legendary
        }
    }
}
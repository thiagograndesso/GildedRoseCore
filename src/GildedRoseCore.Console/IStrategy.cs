namespace ConsoleApplication
{
    public interface IStrategy
    {
        string Type { get; }
        void UpdateQuality(Item item);
    }
}
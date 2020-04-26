using ConsoleApplication;

namespace GildedRoseCore.Console.Strategies
{
    public interface IStrategy
    {
        string Type { get; }
        void UpdateQuality(Item item);
    }
}
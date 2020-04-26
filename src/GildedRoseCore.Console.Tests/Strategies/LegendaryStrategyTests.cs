using ConsoleApplication;
using GildedRoseCore.Console.Strategies;
using Xunit;

namespace GildedRoseCore.Console.Tests.Strategies
{
    public class LegendaryStrategyTests
    {
        [Fact]
        public void UpdateQuality_WhenItemIsLegendary_NeitherQualityOrSellInChanges()
        {
            // Arrange
            const int initialQuality = 80;
            const int initialSellIn = 0;
            var item = new Item { Quality = initialQuality, SellIn = initialSellIn };
            var legendaryStrategy = new LegendaryStrategy();
            
            // Act
            legendaryStrategy.UpdateQuality(item);
            
            // Assert
            Assert.Equal(initialQuality, item.Quality);
            Assert.Equal(initialSellIn, item.SellIn);
        }
    }
}
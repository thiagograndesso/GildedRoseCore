using ConsoleApplication;
using GildedRoseCore.Console.Strategies;
using Xunit;

namespace GildedRoseCore.Console.Tests.Strategies
{
    public class DefaultStrategyTests
    {
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesSellInByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5 };
            var defaultStrategy = new DefaultStrategy();
            
            // Act
            defaultStrategy.UpdateQuality(item);
            
            // Assert
            var expectedSellInDays = 4;
            Assert.Equal(expectedSellInDays, item.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsBelowZero_DecreasesQualityByTwo()
        {
            // Arrange
            var item = new Item { SellIn = -1, Quality = 4 };
            var defaultStrategy = new DefaultStrategy();
            
            // Act
            defaultStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 2;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesQualityByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5, Quality = 4 };
            var defaultStrategy = new DefaultStrategy();
            
            // Act
            defaultStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 3;
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
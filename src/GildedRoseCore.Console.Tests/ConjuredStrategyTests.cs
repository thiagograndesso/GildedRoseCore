using ConsoleApplication;
using Xunit;

namespace Tests
{
    public class ConjuredStrategyTests
    {
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesSellInByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5 };
            var conjuredStrategy = new ConjuredStrategy();
            
            // Act
            conjuredStrategy.UpdateQuality(item);
            
            // Assert
            var expectedSellInDays = 4;
            Assert.Equal(expectedSellInDays, item.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsBelowZero_DecreasesQualityByFour()
        {
            // Arrange
            var item = new Item { SellIn = -1, Quality = 4 };
            var conjuredStrategy = new ConjuredStrategy();
            
            // Act
            conjuredStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 0;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesQualityByTwo()
        {
            // Arrange
            var item = new Item { SellIn = 5, Quality = 4 };
            var conjuredStrategy = new ConjuredStrategy();
            
            // Act
            conjuredStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 2;
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
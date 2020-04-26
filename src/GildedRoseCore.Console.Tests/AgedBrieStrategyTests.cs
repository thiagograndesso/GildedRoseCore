using ConsoleApplication;
using Xunit;

namespace Tests
{
    public class AgedBrieStrategyTests
    {
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesSellInByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5 };
            var agedBrieStrategy = new AgedBrieStrategy();
            
            // Act
            agedBrieStrategy.UpdateQuality(item);
            
            // Assert
            var expectedSellInDays = 4;
            Assert.Equal(expectedSellInDays, item.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsBelowZero_IncreasesQualityByTwo()
        {
            // Arrange
            var item = new Item { SellIn = -1, Quality = 4 };
            var agedBrieStrategy = new AgedBrieStrategy();
            
            // Act
            agedBrieStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 6;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_IncreasesQualityByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5, Quality = 4 };
            var agedBrieStrategy = new AgedBrieStrategy();
            
            // Act
            agedBrieStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 5;
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
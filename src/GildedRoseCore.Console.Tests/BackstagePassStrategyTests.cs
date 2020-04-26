using ConsoleApplication;
using Newtonsoft.Json.Serialization;
using Xunit;

namespace Tests
{
    public class BackstagePassStrategyTests
    {
        [Theory]
        [InlineData(11, 1)]
        [InlineData(6, 2)]
        [InlineData(1, 3)]
        public void UpdateQuality_WhenSellInDaysIs_IncreasesQualityBy(int initialSellIn, int qualityShouldIncreaseBy)
        {
            // Arrange
            const int initialQuality = 5; 
            var item = new Item { SellIn = initialSellIn, Quality = initialQuality };
            var backstagePassStrategy = new BackstagePassStrategy();
            
            // Act
            backstagePassStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = initialQuality + qualityShouldIncreaseBy;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsBelowZero_DecreasesQualityToZero()
        {
            // Arrange
            var item = new Item { SellIn = -1, Quality = 5 };
            var backstagePassStrategy = new BackstagePassStrategy();
            
            // Act
            backstagePassStrategy.UpdateQuality(item);
            
            // Assert
            var expectedQuality = 0;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Fact]
        public void UpdateQuality_WhenSellInDaysIsHigherThanZero_DecreasesSellInByOne()
        {
            // Arrange
            var item = new Item { SellIn = 5 };
            var backstagePassStrategy = new BackstagePassStrategy();
            
            // Act
            backstagePassStrategy.UpdateQuality(item);
            
            // Assert
            var expectedSellInDays = 4;
            Assert.Equal(expectedSellInDays, item.SellIn);
        }
    }
}
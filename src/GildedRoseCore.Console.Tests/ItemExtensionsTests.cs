using ConsoleApplication;
using Xunit;

namespace Tests
{
    public class ItemExtensionsTests
    {
        [Theory]
        [InlineData(50)]
        [InlineData(60)]
        public void UpdateQuality_WhenQualityIsEqualsToOrGreaterThan50_DoesNotIncreaseQuality(int initialQuality)
        {
            // Arrange
            var item = new Item { Quality = initialQuality };
            
            // Act
            item.IncreaseQuality();
            
            // Assert
            Assert.Equal(initialQuality, item.Quality);
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(40)]
        public void UpdateQuality_WhenQualityCanBeUpdated_IncrementsQualityByOne(int initialQuality)
        {
            // Arrange
            var item = new Item { Quality = initialQuality };
            
            // Act
            item.IncreaseQuality();
            
            // Assert
            var expectedQuality = initialQuality + 1;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void DecreaseQuality_WhenQualityIsLessThanOrEqualsToZero_DoesNotDecreaseQuality(int initialQuality)
        {
            // Arrange
            var item = new Item { Quality = initialQuality };
            
            // Act
            item.DecreaseQuality();
            
            // Assert
            Assert.Equal(initialQuality, item.Quality);
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(40)]
        public void DecreaseQuality_WhenQualityCanBeUpdated_DecrementsQualityByOne(int initialQuality)
        {
            // Arrange
            var item = new Item { Quality = initialQuality };
            
            // Act
            item.DecreaseQuality();
            
            // Assert
            var expectedQuality = initialQuality - 1;
            Assert.Equal(expectedQuality, item.Quality);
        }
        
        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(30)]
        [InlineData(40)]
        public void DecreaseSellIn_WhenSellInIsAValidNumber_DecrementsSellInByOne(int initialSellIn)
        {
            // Arrange
            var item = new Item { SellIn = initialSellIn };
            
            // Act
            item.DecreaseSellIn();
            
            // Assert
            var expectedSellIn = initialSellIn - 1;
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
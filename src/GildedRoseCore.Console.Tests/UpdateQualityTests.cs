using System.Collections.Generic;
using System.Linq;
using ConsoleApplication;
using Xunit;

namespace Tests
{
    public class UpdateQualityTests
    {
        [Fact]
        public void UpdateQuality_WhenItemIsSulfuras_SellInIsAlwaysZeroAndQualityIsAlwaysEighty()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };

            // Act
            program.UpdateQuality();
            
            // Assert
            var sulfuras = program.Items.FirstOrDefault(item => item.Name.Equals("Sulfuras, Hand of Ragnaros"));
            
            Assert.NotNull(sulfuras);
            Assert.Equal(sulfuras.Quality, 80);
            Assert.Equal(sulfuras.SellIn, 0);
        }
        
        [Fact]
        public void UpdateQuality_WhenQualityIsUpdated_QualityIsNeverNegative()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };

            // Act
            for (int quality = 0; quality < 51; quality++)
            {
                program.UpdateQuality();
            }

            // Assert
            Assert.All(program.Items, item =>
            {
                Assert.True(item.Quality >= 0, "Quality should be 0 but it was negative");
            });
        }
        
        [Fact]
        public void UpdateQuality_WhenQualityIsUpdated_QualityNeverExceedsFifty()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };

            // Act
            for (int quality = 0; quality < 51 ; quality++)
            {
                program.UpdateQuality();
            }

            // Assert
            Assert.All(program.Items, item =>
            {
                if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
                {
                    Assert.True(item.Quality <= 50, $"Quality from item {item.Name} should be up to 50 only, but it was {item.Quality}");   
                }
            });
        }
        
        [Fact]
        public void UpdateQuality_WhenItemIsAgedBrie_QualityIncreasesTheOlderItGets()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };
            var agedBrie = GetItem(program.Items, "Aged Brie");
            var agedBrieQuality = agedBrie.Quality;

            // Act
            program.UpdateQuality();

            // Assert
            ++agedBrieQuality;
            Assert.Equal(agedBrie.Quality,agedBrieQuality);
        }
        
        [Fact]
        public void UpdateQuality_WhenItemIsBackstagePasses_QualityIncreasesUntilSellInDate()
        {
            var program = new Program { Items = InventoryStore.GetItems() };
            var backstagePass = GetItem(program.Items, "Backstage passes to a TAFKAL80ETC concert");

            var quality = backstagePass.Quality;
            var sellIn = backstagePass.SellIn;
            
            while (sellIn > -1)
            {
                program.UpdateQuality();
            
                if (sellIn > 10)
                {
                    quality += 1;
                }
                else if (sellIn > 5)
                {
                    quality += 2;
                }
                else if (sellIn > 0)
                {
                    quality += 3;
                }
                else
                {
                    quality = 0;
                }
            
                if (quality > 50)
                {
                    quality = 50;
                }
                
                Assert.Equal(quality, backstagePass.Quality);
            
                sellIn -= 1;
            }
        }
        
        [Fact]
        public void UpdateQuality_WhenSellByDateHasPassed_QualityDegradesTwiceAsFast()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };

            var itemsWithQualityDegradingTwiceAsFast = program.Items
                .Where(item => !item.Name.Equals("Aged Bried"))
                .Where(item => !item.Name.Equals("Sulfuras, Hand of Ragnaros"));

            var pickedItem = itemsWithQualityDegradingTwiceAsFast.First();
            
            // Until sell by date is reached
            while (pickedItem.SellIn >= 0)
            {
                program.UpdateQuality();
            }

            var previousQuality = pickedItem.Quality;
            
            // Act
            program.UpdateQuality();
            
            // Assert
            Assert.Equal(pickedItem.Quality, previousQuality - 2);
        }
        
        [Fact]
        public void UpdateQuality_WhenItemIsConjuredManaCake_QualityDegradesTwiceAsFast()
        {
            // Arrange
            var program = new Program { Items = InventoryStore.GetItems() };
            var conjuredManaCake = GetItem(program.Items, "Conjured Mana Cake");
            var quality = conjuredManaCake.Quality;
            
            // Act
            program.UpdateQuality();
            
            // Assert
            Assert.Equal(quality - 2, conjuredManaCake.Quality);
        }

        Item GetItem(IList<Item> items, string name)
        {
            return items.Single(item => item.Name.Equals(name));
        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

/*
 * Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a prominent city ran by a friendly innkeeper named Allison. We also buy and sell only the finest goods. Unfortunately, our goods are constantly degrading in quality as they approach their sell by date. We have a system in place that updates our inventory for us. It was developed by a no-nonsense type named Leeroy, who has moved on to new adventures. Your task is to add the new feature to our system so that we can begin selling a new category of items. First an introduction to our system:


- All items have a SellIn value which denotes the number of days we have to sell the item
- All items have a Quality value which denotes how valuable the item is
- At the end of each day our system lowers both values for every item


Pretty simple, right? Well this is where it gets interesting:

- Once the sell by date has passed, Quality degrades twice as fast OK
- The Quality of an item is never negative OK
- "Aged Brie" actually increases in Quality the older it gets OK
- The Quality of an item is never more than 50 OK
- "Sulfuras", being a legendary item, never has to be sold or decreases in Quality OK
- "Backstage passes", like aged brie, increases in Quality as it's SellIn value approaches; Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but Quality drops to 0 after the concert OK

We have recently signed a supplier of conjured items. This requires an update to our system:

- "Conjured" items degrade in Quality twice as fast as normal items

Feel free to make any changes to the UpdateQuality method and add any new code as long as everything still works correctly. However, do not alter the Item class or Items property as those belong to the goblin in the corner who will insta-rage and one-shot you as he doesn't believe in shared code ownership (you can make the UpdateQuality method and Items property static if you like, we'll cover for you).

Just for clarification, an item can never have its Quality increase above 50, however "Sulfuras" is a legendary item and as such its Quality is 80 and it never alters.
 */

namespace ConsoleApplication
{
    public class Item
    {
        public string Name { get; set; }
        
        /// <summary>
        ///     The number of days we have to sell the item
        /// </summary>
        public int SellIn { get; set; }
        
        /// <summary>
        ///     How valuable the item is
        /// </summary>
        public int Quality { get; set; }
    }


    public class Program
    {
        public IList<Item> Items;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program { Items = GetAllItems() };
            app.UpdateQuality();

            Console.ReadKey();
        }

        public static List<Item> GetAllItems()
        {
            return new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };
        }

        public void UpdateQuality()
        {
            var allNotLegendaryItems = Items.Where(item => !IsLegendary(item)).ToList();

            foreach (var item in allNotLegendaryItems)
            {
                IncreaseQualityIfAgedBrie(item);
                IncreaseQualityIfBackstagePass(item);

                if (!DoesQualityIncreaseOverTime(item))
                {
                    DecreaseQuality(item);
                }

                DecreaseSellIn(item);

                if (item.SellIn >= 0) continue;
                
                if (IncreaseQualityForAgedBrieWhenSellByHasPassed(item)) continue;
                if (ResetQualityForBackstagePassWhenSellByDateHasPassed(item)) continue;
                            
                DecreaseQuality(item);
            }
        }

        private static bool ResetQualityForBackstagePassWhenSellByDateHasPassed(Item item)
        {
            if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                ResetQualityToZero(item);
                return true;
            }

            return false;
        }

        private static bool IncreaseQualityForAgedBrieWhenSellByHasPassed(Item item)
        {
            if (item.Name.Equals("Aged Brie"))
            {
                IncreaseQuality(item);
                return true;
            }

            return false;
        }

        private static void IncreaseQualityIfAgedBrie(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                IncreaseQuality(item);
            }
        }

        private static void IncreaseQualityIfBackstagePass(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                return;
            }
            
            IncreaseQuality(item);
            
            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }
        }

        private static bool DoesQualityIncreaseOverTime(Item item)
        {
            var items = new List<string> { "Aged Brie", "Backstage passes to a TAFKAL80ETC concert" };
            return items.Contains(item.Name);
        }

        private static bool IsLegendary(Item item)
        {
            return item.Name.Equals("Sulfuras, Hand of Ragnaros");
        }

        private static bool IsQualityLowerThanMaxValue(Item item)
        {
            return item.Quality < 50;
        }
        
        private static bool IsQualityHigherThanMinValue(Item item)
        {
            return item.Quality > 0;
        }

        private static void ResetQualityToZero(Item item)
        {
            item.Quality -= item.Quality;
        }

        private static void IncreaseQuality(Item item)
        {
            if (IsQualityLowerThanMaxValue(item))
            {
                item.Quality += 1;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (IsQualityHigherThanMinValue(item))
            {
                item.Quality -= 1;   
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn -= 1;
        }
    }
}

using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public IList<Item> Items;

        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program { Items = InventoryStore.GetItems() };
            app.UpdateQuality();

            Console.ReadKey();
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var strategy = StrategyFactory.Create(item);
                strategy.UpdateQuality(item);
            }
        }
    }
}

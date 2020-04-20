using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public static class StrategyFinder
    {
        private static readonly IList<IStrategy> Strategies = new List<IStrategy>
        {
            new AgedBrieStrategy(),
            new BackstagePassStrategy(),
            new ConjuredManaStrategy(),
            new LegendaryStrategy(),
            new DefaultStrategy()
        };
            
        public static IStrategy Create(Item item)
        {
            try
            {
                return Strategies.Single(strategy => strategy.Type == item.Name);
            }
            catch (Exception)
            {
                return new DefaultStrategy();
            }
        }
    }
}
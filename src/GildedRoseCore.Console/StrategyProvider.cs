using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public static class StrategyProvider
    {
        private static readonly IList<IStrategy> Strategies = new List<IStrategy>
        {
            new AgedBrieStrategy(),
            new BackstagePassStrategy(),
            new ConjuredManaStrategy(),
            new LegendaryStrategy()
        };
            
        public static IStrategy GetStrategyFor(Item item)
        {
            var strategy = Strategies.SingleOrDefault(s => s.Type.Equals(item.Name, StringComparison.OrdinalIgnoreCase));
            return strategy ?? GetDefaultStrategy();
        }

        private static IStrategy GetDefaultStrategy()
        {
            return Strategies.Single(s => s.Type.Equals("Default", StringComparison.OrdinalIgnoreCase));
        }
    }
}
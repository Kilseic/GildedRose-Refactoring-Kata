using System;
using System.Collections.Generic;
using NUnit.Framework.Internal.Execution;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            List<string> increasingItems = new List<string> {"Aged Brie", "Backstage passes to a TAFKAL80ETC concert"};
            List<string> legendaryItems = new List<string> {"Sulfuras, Hand of Ragnaros"};
            for (var i = 0; i < Items.Count; i++)
            {
                if (legendaryItems.Contains(Items[i].Name))
                {
                    Items[i].SellIn = 0;
                    continue;
                }

                if (increasingItems.Contains(Items[i].Name))
                {
                    Items[i] = IncreasingItem(Items[i]);
                    continue;
                }

                int qualityLoss = -1;
                if (Items[i].SellIn <= 0)
                    qualityLoss *= 2;
                if (Items[i].Name.Contains("Conjured"))
                    qualityLoss *= 2;
                Items[i].Quality = Math.Max(0, Items[i].Quality + qualityLoss);
                Items[i].SellIn -= 1;
            }
        }

        private Item IncreasingItem(Item inputItem)
        {
            int newQuality = inputItem.Quality + 1;
            if (inputItem.Name == "Aged Brie")
            {
                if (inputItem.SellIn <= 0)
                    newQuality = Math.Min(50, newQuality+1);
            }

            if (inputItem.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                if (inputItem.SellIn <= 0)
                    newQuality = 0;
                else if (inputItem.SellIn <= 10)
                {
                    newQuality = Math.Min(newQuality+1,50);
                    if (inputItem.SellIn <= 5)
                        newQuality = Math.Min(newQuality+1,50);
                }
            }
            inputItem.Quality = newQuality;
            inputItem.SellIn--;
            return inputItem;
        }
    }
}

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
                    continue;
                }

                if ("Aged Brie" == Items[i].Name)
                {
                    Items[i] = IncreasingItem(Items[i]);
                    continue;
                }

                if ("Backstage passes to a TAFKAL80ETC concert" == Items[i].Name)
                {
                    Items[i] = DeadlineItem(Items[i]);
                    continue;
                }

                Items[i] = DecreasingItem(Items[i]);
            }
        }

        private Item DecreasingItem(Item inputItem)
        {
            int qualityLoss = -1;
            if (inputItem.SellIn <= 0)
                qualityLoss *= 2;
            //if (inputItem.Name.Contains("Conjured"))
                //qualityLoss *= 2;
            inputItem.Quality = Math.Max(0, inputItem.Quality + qualityLoss);
            inputItem.SellIn -= 1;
            return inputItem;
        }

        private Item DeadlineItem(Item inputItem)
        {
            int newQuality = inputItem.Quality + 1;
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

        private Item IncreasingItem(Item inputItem)
        {
            int newQuality = inputItem.Quality + 1;
            if (inputItem.Name == "Aged Brie")
            {
                if (inputItem.SellIn <= 0)
                    newQuality = Math.Min(50, newQuality+1);
            }
            inputItem.Quality = newQuality;
            inputItem.SellIn--;
            return inputItem;
        }
    }
}

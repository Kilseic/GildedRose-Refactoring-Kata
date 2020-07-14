using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 0 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5},
                new Item { Name = "Normal Iron Sword", SellIn = 15, Quality = 25},
                new Item { Name = "Conjured Iron Sword", SellIn = 15, Quality = 25}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(2, Items[0].Quality);
            app.UpdateQuality();
            Assert.True(2*(25-Items[2].Quality) == (25-Items[3].Quality));
            Assert.AreEqual(8, Items[1].Quality);
        }
    }
}

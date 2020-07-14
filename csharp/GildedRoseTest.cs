using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void CheckConjured()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Normal Iron Sword", SellIn = 15, Quality = 25},
                new Item { Name = "Conjured Iron Sword", SellIn = 15, Quality = 25}
            };
            GildedRose app = new GildedRose(Items);
            for (int i = 0;i < 10; i++)
                app.UpdateQuality();
            Assert.True(2*(25-Items[0].Quality) == (25-Items[1].Quality));
            for (int i = 0;i < 10; i++)
                app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
            Assert.AreEqual(0, Items[1].Quality);
        }
        [Test]
        public void CheckBackstagePasses()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10},
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 8}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(11, Items[2].Quality);
            Assert.AreEqual(6, Items[0].Quality);
            Assert.AreEqual(12, Items[1].Quality);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[2].Quality);
            Assert.AreEqual(8, Items[0].Quality);
        }
        [Test]
        public void CheckBrie()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5},
                new Item { Name = "Aged Brie", SellIn = 6, Quality = 0},
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 8}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(10, Items[2].Quality);
            Assert.AreEqual(1, Items[1].Quality);
            for (int i = 0; i<10; i++)
                app.UpdateQuality();
            Assert.AreEqual(30, Items[2].Quality);
            Assert.AreEqual(16, Items[1].Quality);
        }
        [Test]
        public void CheckLegendary()
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 11, Quality = 80},
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 23, Quality = 80}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
            for (int i = 0; i< 1000; i++)
                app.UpdateQuality();
            Assert.AreEqual(80, Items[0].Quality);
        }
    }
}

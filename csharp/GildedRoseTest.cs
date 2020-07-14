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
        [TestCase(11,5,6)]
        [TestCase(8,5,7)]
        [TestCase(4,5,8)]
        [TestCase(0,5,0)]
        public void CheckBackstagePasses(int deadline,int startQuality, int expectedQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = deadline, Quality = startQuality}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
        }
        [TestCase(6,0,1)]
        [TestCase(0,0,2)]
        [TestCase(-34,23,25)]
        public void CheckBrie(int deadline,int startQuality, int expectedQuality)
        {
            IList<Item> Items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = deadline, Quality = startQuality}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expectedQuality, Items[0].Quality);
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

using NUnit.Framework;
using SwinAdventure;
using System;

namespace Test
{
    public class BagTest
    {
        private Bag bag;
        private Item key;
        private Item book;

        [SetUp]
        public void SetUp()
        {
            // Create a Bag and some items to put in the bag
            bag = new Bag(new string[] { "bag" }, "Small Bag", "A small bag.");
            key = new Item(new string[] { "key" }, "Golden Key", "A shiny golden key.");
            book = new Item(new string[] { "book" }, "Ancient Book", "A dusty old book.");
        }

        [Test]
        public void TestBagLocatesItems()
        {
            SetUp();
            bag.Inventory.Put(key);

            //Try to locate the item in the bag
            GameObject locatedItem = bag.Locate("key");

            // Assert: Ensure that the item is found in the bag
            Assert.AreEqual(key, locatedItem);
        }

        [Test]
        public void TestBagLocatesItself()
        {
            //Try to locate the bag by its identifiers
            GameObject locatedBag = bag.Locate("bag");

            //Ensure that the bag is found
            Assert.AreEqual(bag, locatedBag);
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            //Try to locate something that doesn't exist in the bag
            GameObject locatedObject = bag.Locate("book");

            //Ensure that nothing is found
            Assert.IsNull(locatedObject);
        }

        [Test]
        public void TestBagFullDescription()
        {
            bag.Inventory.Put(key);
            bag.Inventory.Put(book);

            // Define the expected full description string
            string expectedstring = "In the Small Bag you can see: Golden Key (key)\nAncient Book (book)\n";

            // Ensure that the full description matches the expected string
            Assert.AreEqual(expectedstring, bag.FullDescription);
        }

        [Test]
        public void TestBagInBag()
        {
            // Create two bags, one inside the other
            Bag b1 = new Bag(new string[] { "outer" }, "Outer Bag", "A larger bag.");
            Bag b2 = new Bag(new string[] { "inner" }, "Inner Bag", "A smaller bag.");
            b1.Inventory.Put(b2);
            b1.Inventory.Put(key);
            b2.Inventory.Put(book);
            
            //test with key item
            // Try to locate the inner bag within the outer bag
            GameObject locatedInnerBag = b1.Locate("inner");
            GameObject locatedKeyInB1 = b1.Locate("key");
            GameObject locatedKeyInB2 = b2.Locate("key");

            // Ensure that the inner bag is found inside the outer bag
            Assert.AreEqual(b2, locatedInnerBag);
            Assert.AreEqual(key, locatedKeyInB1);

            //key cannot find in b2
            Assert.AreNotEqual(key, locatedKeyInB2);

            //test with book item
            GameObject locatedbookinb1 = b1.Locate("book");
            GameObject locatedbookinb2 = b2.Locate("book");

            Assert.AreEqual(book, locatedbookinb2);
            Assert.AreNotEqual(book, locatedbookinb1);





        }

    }
}

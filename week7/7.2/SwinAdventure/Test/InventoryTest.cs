using System;
using NUnit.Framework;
 
namespace SwinAdventure
{
    public class TestInventory
    {
        [Test]
        public void TestFindItem() 
        {
            // Initialize the inventory and create items for testing
            Inventory inventory = new Inventory();
            Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
            Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

            //put the item "axe" in the inventory
            inventory.Put(axe);
            //check if the Inventory has items that are put in it.
            Assert.IsTrue(inventory.HasItem(axe.FirstID));
        }

        [Test]
        public void TestNoFindItem()
        {
            // Initialize the inventory and create items for testing
            Inventory inventory = new Inventory();
            Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
            Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

            //put the item "axe" in the inventory
            inventory.Put(axe);
            //check if the Inventory has items that are put in it.
            Assert.IsFalse(inventory.HasItem(sword.FirstID));
        }

        [Test]
        public void TestFetchItems()
        {
            // Initialize the inventory and create items for testing
            Inventory inventory = new Inventory();
            Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
            Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

            inventory.Put(axe);
            Item fetchItem = inventory.Fetch(axe.FirstID);

            Assert.IsNotNull(fetchItem); // Ensure the fetched item is not null
            Assert.AreEqual(axe, fetchItem); // Ensure the fetched item is the same as the one we put
            Assert.IsTrue(inventory.HasItem(axe.FirstID)); // Ensure the item is still in the inventory after being fetched one we put
        }

        [Test]
        public void TestTakenItem()
        {
            // Initialize the inventory and create items for testing
            Inventory inventory = new Inventory();
            Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
            Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

            inventory.Put(axe); // Put the axe in the inventory
            Item fetchItem = inventory.Fetch(axe.FirstID); // Fetch the axe

            Assert.IsNotNull(fetchItem); // Ensure the fetched item is not null
            Assert.AreEqual(axe, fetchItem); // Ensure the fetched item is the same as the item was put earlier

            inventory.Take(axe.FirstID);

            // Assert that the item is no longer in the inventory
            Assert.IsFalse(inventory.HasItem(axe.FirstID));
        }

        [Test]
        public void TestItemList()
        {
            // Initialize the inventory and create items for testing
            Inventory inventory = new Inventory();
            Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
            Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

            //put items to the inventory
            inventory.Put(sword);
            inventory.Put(axe);

            // Act: Access the ItemList property of the inventory to retrieve a string containing item descriptions.
            string itemList = inventory.ItemList;

            // Define the expected item list string with proper formatting, including tab indentation and line breaks.
            string expectedItemList = "an iron sword (sword)\na wooden axe (axe)\n";

            // Assert: Check that the actual item list matches the expected item list string.
            Assert.AreEqual(expectedItemList, itemList);

        }
    }
}

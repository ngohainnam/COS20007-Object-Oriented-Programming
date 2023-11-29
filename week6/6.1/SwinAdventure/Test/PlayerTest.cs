using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SwinAdventure
{
    public class TestPlayer
    {
        // Create a Player instance for testing
        Player player = new Player("Hai Nam Ngo", "Swinburne Warrior");

        //creating two items for testing
        Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
        Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

        [Test]
        public void TestPlayerIdentifiable()
        {
            // Assert that the player is identified by "me"
            Assert.IsTrue(player.AreYou("me"));

            // Assert that the player is identified by "inventory"
            Assert.IsTrue(player.AreYou("inventory"));
        }

        [Test]
        public void TestPlayerLocateItems()
        {
            // Put a sword into the player's inventory
            player.Inventory.Put(sword);

            // Try to locate the sword
            Item itemsLocated = (Item)player.Locate("sword");

            // Assert that the located item is the same as the one put in the inventory
            Assert.AreEqual(sword, itemsLocated);
        }

        [Test]
        public void TestPlayerLocateItself()
        {
            // Try to locate the player by "me"
            Player me = (Player)player.Locate("me");

            // Try to locate the player by "inventory"
            Player inventory = (Player)player.Locate("inventory");

            // Assert that both "me" and "inventory" locate the player
            Assert.AreEqual(player, me);
            Assert.AreEqual(player, inventory);
        }


        [Test]
        public void TestPlayerLocateNothing()
        {
            // Try to locate an item with an unknown identifier
            Item itemLocated = (Item)player.Locate("Silver Arrow");

            // Assert that no item is located for an unknown identifier
            Assert.IsNull(itemLocated);
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            // Put a sword and a shovel into the player's inventory
            player.Inventory.Put(sword);
            player.Inventory.Put(axe);

            // Define the expected full description
            string expected = "Hai Nam Ngo, Swinburne Warrior\nList of Items that you have:\nan iron sword (sword)\na wooden axe (axe)\n";

            // Assert that the full description matches the expected description
            Assert.AreEqual(player.FullDescription, expected);
        }
    }
}
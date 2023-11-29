using System;
using NUnit.Framework;
using SwinAdventure;

namespace Test
{
    public class LookCommandTest
    {
        private LookCommand look;
        private Player player;
        private Bag bag;
        private Item gem;

        [SetUp]
        public void SetUp()
        {
            // Create a LookCommand instance for testing
            look = new LookCommand();

            // Create a player and a bag for testing
            player = new Player("Hai Nam Ngo", "Swinburne Warrior");
            bag = new Bag(new string[] { "bag" }, "Nam's Bag", "A Small Bag");

            // Create a gem for testing
            gem = new Item(new string[] { "gem" }, "a gem", "a bright red gem");

            // Put the bag in the player's inventory
            player.Inventory.Put(bag);
        }

        [Test]
        public void TestLookAtMe()
        {
            // Test looking at "inventory"
            string output = look.Execute(player, new string[] { "look", "at", "inventory" });
            string expected = "Hai Nam Ngo, Swinburne Warrior\nList of Items that you have:\nNam's Bag (bag)\n";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGem()
        {
            // Put the gem in the player's inventory
            player.Inventory.Put(gem);

            // Test looking at the gem
            string output = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "a bright red gem";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtUnk()
        {
            // Test looking at an unknown item
            string output = look.Execute(player, new string[] { "look", "at", "gem" });
            string expected = "I cannot find the gem in the Hai Nam Ngo";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            // Put the gem in the player's inventory
            player.Inventory.Put(gem);

            // Test looking at the gem in "me"
            string output = look.Execute(player, new string[] { "look", "at", "gem", "in", "inventory" });
            string expected = "a bright red gem";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            // Put the gem in the bag
            bag.Inventory.Put(gem);

            // Test looking at the gem in the bag
            string output = look.Execute(player, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "a bright red gem";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookatGemInNoBag()
        {
            // Create a player with no bag
            Player player1 = new Player("NPC", "Robot Warrior");

            // Test looking at the gem as if it's in a bag (even though there's no bag)
            string output = look.Execute(player1, new string[] { "look", "at", "gem", "in", "bag" });
            string expected = "I cannot find the gem";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            // Create an empty bag
            Bag emptyBag = new Bag(new string[] { "emptybag" }, "Empty Bag", "An empty bag");

            // Put the empty bag in the player's inventory
            player.Inventory.Put(emptyBag);

            // Test looking at the gem in the empty bag
            string output = look.Execute(player, new string[] { "look", "at", "gem", "in", "emptybag" });
            string expected = "I cannot find the gem in the Empty Bag";
            Assert.AreEqual(expected, output);
        }

        [Test]
        public void TestInvalidLookCommands()
        {
            // Test invalid look commands
            string output1 = look.Execute(player, new string[] { "look", "around" });
            string output2 = look.Execute(player, new string[] { "hello" });
            string expected = "I don't know how to look like that";

            Assert.AreEqual(expected, output1);
            Assert.AreEqual(expected, output2);
        }
    }
}

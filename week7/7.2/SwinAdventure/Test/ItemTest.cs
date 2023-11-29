using System;
using NUnit.Framework;

namespace SwinAdventure
{
    public class TestItem
    {
        //creating two items for testing
        Item axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");
        Item sword = new Item(new string[] { "sword" }, "an iron sword", "This is a sword, + 10 ATK Damage");

        [Test]
        public void TestItemIdentifiable()
        {
            // Each test checks a single identification, and we use two separate Assert statements
            Assert.IsFalse(axe.AreYou("sword")); // The axe should not be identified as "sword"
            Assert.IsTrue(axe.AreYou("axe")); // The axe should be identified as "axe"

            Assert.IsFalse(sword.AreYou("axe")); // The sword should not be identified as "axe"
            Assert.IsTrue(sword.AreYou("sword")); // The sword should be identified as "sword"
        }

        [Test]
        public void TestShortDescription()
        {
            Assert.AreEqual(axe.ShortDescription, "a wooden axe (axe)"); // Check the short description of the axe
            Assert.AreNotEqual(axe.ShortDescription, "This is a shovel"); // Ensure it's not equal to an incorrect description

            Assert.AreEqual(sword.ShortDescription, "an iron sword (sword)"); // Check the short description of the sword
            Assert.AreNotEqual(sword.ShortDescription, "This is a shovel"); // Ensure it's not equal to an incorrect description
        }

        [Test]
        public void TestFullDescription()
        {
            Assert.AreEqual(axe.FullDescription, "+5 ATK Damage"); // Check the full description of the axe
            Assert.AreNotEqual(axe.FullDescription, "a wooden axe (axe)"); // Ensure it's not equal to the short description

            Assert.AreEqual(sword.FullDescription, "This is a sword, + 10 ATK Damage"); // Check the full description of the sword
            Assert.AreNotEqual(sword.FullDescription, "an iron sword (sword)"); // Ensure it's not equal to the short description
        }
    }
}

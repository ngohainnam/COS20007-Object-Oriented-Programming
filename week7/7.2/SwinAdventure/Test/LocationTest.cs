using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using NUnit.Framework;
using SwinAdventure;

namespace Test
{
    public class LocationTest
    {
        private Player player;
        private Location location;
        private Item axe;

        [SetUp]
        public void SetUp()
        {
            // Create a Player instance for testing
            player = new Player("Hai Nam Ngo", "Swinburne Warrior");

            //creating two items for testing
            axe = new Item(new string[] { "axe" }, "a wooden axe", "+5 ATK Damage");

            //create a location
            location = new Location("The lost island", "Small island in the world map");
        }

        [Test]
        public void TestLocationIdentifiesItself()
        {
            // Act
            GameObject result = location.Locate("location");

            // Assert
            Assert.AreEqual(location, result);
        }

        [Test]
        public void LocationLocateItemTheyHave()
        {
            location.Inventory.Put(axe);
            GameObject expected = axe;
            GameObject actual = location.Locate("axe");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayerCanLocateItemInTheirLocation()
        {
            location.Inventory.Put(axe);
            player.Location = location;
            GameObject expected = axe;
            GameObject actual = player.Location.Locate("axe");
            Assert.AreEqual(expected, actual);
        }
    }
}

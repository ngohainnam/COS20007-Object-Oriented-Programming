using System;
using System.IO;
using System.Numerics;
using NUnit.Framework;
using SwinAdventure;

namespace SwinAdventure
{
    public class MoveCommandTest
    {
        Player player;
        Location location1;
        Location location2;
        Location location3;
        Paths path1;
        Paths path2;

        [SetUp]
        public void SetUp()
        {
            // Create a Player instance for testing
            player = new Player("Hai Nam Ngo", "Swinburne Warrior");

            //create a location
            location1 = new Location("State Library", "A library in Melbourne");
            location2 = new Location("Melbourne Central", "A huge shopping mall");

            //creating a path for testing
            path1 = new Paths(new string[] { "south" }, "Main entrance", "The way to Swanston St", location2);
            path2 = new Paths(new string[] { "north" }, "Back Door", "The way to Elizabeth St", null);
            player.Location = location1;
            location1.AddPath(path1);
            location1.AddPath(path2);
        }

        [Test]
        public void MoveTestSucessful()
        {
            Location start1 = location1;
            Location end1 = location2;
            Assert.AreEqual(player.Location, start1);
            player.Move(path1);
            Assert.AreEqual(player.Location, end1);
        }

        [Test]
        public void MoveTestFail()
        {
            Location start1 = location1;
            Assert.AreEqual(player.Location, start1);  // Assert the player starts at location1
            player.Move(path2);  // Try to move the player via path2
            Assert.AreEqual(player.Location, start1);  // player still standing the same place
        }
    }
}
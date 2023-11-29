using System;
using System.IO;
using System.Numerics;
using NUnit.Framework;

namespace SwinAdventure
{
    public class PathTest
    {
        Player player;
        Location location1;
        Location location2;
        Paths path1;

        [SetUp]
        public void SetUp()
        {
            // Create a Player instance for testing
            player = new Player("Hai Nam Ngo", "Swinburne Warrior");

            //create a location
            location1 = new Location("State Library", "A library in Melbourne");
            location2 = new Location("Melbourne Central", "A huge shopping mall");
            //creating a path for testing
            path1 = new Paths(new string[] { "south" }, "Main entrance", "The way to Swanston St", location1, location2);
            player.Location = location1;
            location1.AddPath(path1);
        }

        [Test]
        public void PathIdenTest()
        {
            Location expected1 = location2;
            Location actual1 = path1.End;

            Location expected2 = location1;
            Location actual2 = path1.Start;

            Assert.AreEqual(expected1, actual1);
            Assert.AreEqual(expected2, actual2);
        }

        [Test]
        public void PathNameTest()
        {
            string expected = "Main entrance";
            string actual = path1.FullDescription;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PathLocate()
        {
            GameObject expected = location1.Locate("south");
            GameObject actual = path1;

            Assert.AreEqual(expected, actual);
        }
    }
}


using System;
using System.Xml.Linq;
using NUnit.Framework;
using SwinAdventure;

namespace Test
{
    public class CommandProcessorTest
    {
        Player player;
        Location location1;
        Location location2;
        Item book;
        CommandProcessor commandProcessor;

        [SetUp]
        public void SetUp()
        {
            // Your Setup code seems good, let's keep it and
            // instantiate the CommandProcessor
            player = new Player("Hai Nam Ngo", "Swinburne Warrior");
            location1 = new Location("State Library", "A library in Melbourne");
            location2 = new Location("Melbourne Central", "A huge shopping mall");
            Paths path = new Paths(new string[] { "south" }, "Main entrance", "The way to Swanston St", location1, location2);
            player.Location = location1;
            location1.AddPath(path);
            book = new Item(new string[] { "book" }, "Ancient Book", "A dusty old book.");
            player.Inventory.Put(book);
            commandProcessor = new CommandProcessor();
        }

        [Test]
        public void TestLookCommand()
        {
            // Here's how you might test that the Look command works
            string expectedOutput = "You are in A library in Melbourne\nItems that available here:\n\n";
            string[] input = { "look" };
            Assert.AreEqual(expectedOutput, commandProcessor.Execute(player, input));
        }

        [Test]
        public void TestMoveCommand()
        {
            // Ensure the player starts at location1
            Assert.AreEqual(location1, player.Location);

            // Execute a move command and assert player arrives at location2
            string[] input = { "move", "south" };
            Assert.AreEqual("You have moved south to the Melbourne Central...\nYou are in A huge shopping mall\nItems that available here:\n\n\nThere are no path here.", commandProcessor.Execute(player, input));
            Assert.AreEqual(location2, player.Location);
        }
    }
}

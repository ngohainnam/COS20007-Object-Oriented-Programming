using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Input;

namespace SwinAdventure
{
    public class Program
    {
        static void Main(string[] args)
        {
            //take information from the player
            string PlayerName;
            Console.WriteLine("What's your name?");
            PlayerName = Console.ReadLine();

            string PLayerDesc;
            Console.WriteLine("Can you tell us something about you (short please)?");
            PLayerDesc = Console.ReadLine();

            //create new player based on the information above
            Player player = new Player(PlayerName, PLayerDesc);

            //create two items
            Console.WriteLine("For now, we will give you a wooden sword and a wooden shield...");
            Item sword = new Item(new string[] { "sword" }, "an wooden sword", "This is a sword, + 10 ATK");
            Item shield = new Item(new string[] { "shield" }, "an wooden shield", "This is a sword, + 10 DEF");

            //put sword and shield to the player inventory
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);

            //create a bag and put in the player inventory
            Console.WriteLine("...and a small bag...Enjoy!");
            Bag bag = new Bag(new string[] { "bag" }, "Small Bag", "A small bag.");
            player.Inventory.Put(bag);

            //create a location
            Location location1 = new Location("State Library", "A library in Melbourne");
            Location location2 = new Location("Melbourne Central", "A huge shopping mall");
            Location location3 = new Location("QV", "A smaller mall");
            //creating a path for testing
            Paths path1 = new Paths(new string[] { "south" }, "Main entrance", "The way to Little Lonsdale St", location1, location2);
            Paths path2 = new Paths(new string[] { "east" }, "Back Door", "The way to Elizabeth St", location2, location3);
            Paths path3 = new Paths(new string[] { "west" }, "Small Exit", "The way to Swanston St", location3, location1);
            player.Location = location1;
            location1.AddPath(path1);
            location1.AddPath(path3);
            location2.AddPath(path2);
            location3.AddPath(path3);

            //create items in location
            Item key = new Item(new string[] { "key" }, "a key", "This is a key");
            Item book = new Item(new string[] { "book" }, "a book", "This is a book");
            Item armour = new Item(new string[] { "armour" }, "an armour", "This is an armour");

            location1.Inventory.Put(key);
            location2.Inventory.Put(book);
            location3.Inventory.Put(armour);

            bool playing = true;
            Command c = new CommandProcessor();

            Console.WriteLine(c.Execute(player, new string[] { "look" }));

            //Loop reading commands from the user, and getting the look command to execute them
            while (playing) // loop until the user types 'exit'
            {
                Console.WriteLine("Type your command here (enter 'exit' to end): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    playing = false;

                string[] playerCommand = input.Split();
                Console.WriteLine(c.Execute(player, input.Split()));
            }
        }
    }
}
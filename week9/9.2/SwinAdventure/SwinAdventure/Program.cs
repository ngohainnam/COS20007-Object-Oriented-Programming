using System;
using System.IO;
using System.Runtime.InteropServices;

namespace SwinAdventure
{
    public class Program
    {
        static void LookExecution(Command look, string input, Player player)
        {
            Console.WriteLine(look.Execute(player, input.Split()));

        }

        static void MoveExecution(Command move, string input, Player player)
        {
            Console.WriteLine(move.Execute(player, input.Split()));
        }

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
            Paths path1 = new Paths(new string[] { "south" }, "Main entrance", "The way to Little Lonsdale St", location2);
            Paths path2 = new Paths(new string[] { "east" }, "Back Door", "The way to Elizabeth St", location3);
            Paths path3 = new Paths(new string[] { "west" }, "Small Exit", "The way to Swanston St", location1);
            player.Location = location1;
            location1.AddPath(path1);
            location1.AddPath(path3);
            location2.AddPath(path2);
            location3.AddPath(path3);

            //create items in location
            Item key = new Item(new string[] { "key" }, "a key", "This is a key");
            Item book = new Item(new string[] { "book" }, "a book", "This is a book");

            location1.Inventory.Put(key);
            location2.Inventory.Put(book);

            bool playing = true;
            LookCommand look = new LookCommand();
            MoveCommand move = new MoveCommand();

            //Loop reading commands from the user, and getting the look command to execute them
            while (playing) // loop until the user types 'exit'
            {
                Console.WriteLine("Type your command here (enter 'exit' to end): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                    playing = false;

                string[] playerCommand = input.Split();

                if (playerCommand[0].ToLower() == "look")
                {
                    LookExecution(look, input, player);
                }
                else
                {
                    MoveExecution(move, input, player);
                }
            }
        }
    }
}
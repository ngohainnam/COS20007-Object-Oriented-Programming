using System;
using System.Runtime.InteropServices;

namespace SwinAdventure
{
    public class Program
    {
        static void LookExecution(Command look, string input, Player player)
        {
            Console.WriteLine(look.Execute(player, input.Split()));

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
            Item shield = new Item(new string[] { "sword" }, "an wooden shield", "This is a sword, + 10 DEF");

            //put sword and shield to the player inventory
            player.Inventory.Put(sword);
            player.Inventory.Put(shield);

            //creat a bag and put in the player inventory
            Console.WriteLine("...and a small bag...Enjoy!");
            Bag bag = new Bag(new string[] { "bag" }, "Small Bag", "A small bag.");
            player.Inventory.Put(bag);
            bag.Inventory.Put(shield); 

            bool playing = true;
            LookCommand look = new LookCommand();

            //Loop reading commands from the user, and getting the look command to execute them
            while (playing) // loop until the user types 'exit'
            {
                Console.WriteLine("Type your command here (enter 'exit' to end): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "exit") 
                    playing = false;

                string[] playerCommand = input.Split();
                LookExecution(look, input, player);
            } 
        }
    }
}
using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // Define a Player class that inherits from GameObject
    public class Player : GameObject, IHaveInventory
    {
        // Declare a private field to store the player's inventory
        private Inventory _inventory;

        // Constructor for Player that takes a name and a description
        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            // Initialize the player's inventory
            _inventory = new Inventory();
        }

        // Locate method to find an object by its ID
        public GameObject Locate(string id)
        {
            // Check if the player matches the provided ID
            if (AreYou(id))
            {
                return this; // Return the player object
            }

            // If not, try to locate the item in the player's inventory
            return _inventory.Fetch(id);
        }

        // Override the FullDescription property to provide a custom description for the player
        public override string FullDescription
        {
            get
            {
                // Combine the parent's description with the player's name and inventory list
                return $"{Name}, {base.FullDescription}\nList of Items that you have:\n{_inventory.ItemList}";
            }
        }

        // Define a public property to access the player's inventory
        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}

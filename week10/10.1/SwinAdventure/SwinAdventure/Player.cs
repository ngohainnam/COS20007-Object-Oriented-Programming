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
            // checking if they are what is to be located
            if (AreYou(id))
            {
                return this;
            }

            //checking if they have what is being located
            GameObject obj = _inventory.Fetch(id);
            if (obj != null)
            {
                return obj;
            }

            //checking if the item can be located where they are
            if (_location != null)
            {
                obj = _location.Locate(id);
                return obj;
            }
            else
            {
                return null;
            }
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

        //player has a location
        private Location _location;

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        //player can move
        public void Move(Paths move)
        {
            if (move.Start == _location && move.End != null)
            {
                _location = move.End;
            }
            else
            {
                _location = null;
            }
        }
    }
}

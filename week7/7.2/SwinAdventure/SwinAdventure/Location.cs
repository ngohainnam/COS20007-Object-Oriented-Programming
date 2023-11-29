using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // Define a Location class that inherits from GameObject
    public class Location : GameObject, IHaveInventory
    {
        // Declare a private field to store the location's item
        private Inventory _inventory;

        // Constructor for Location that takes a name and a description
        public Location(string name, string desc) : base(new string[] {"location"}, name, desc)
        {
            // Initialize the location's inventory
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            // Check if the location matches the provided ID
            if (AreYou(id))
            {
                return this; // Return the location
            }

            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"{Name}, You are in {base.FullDescription}\nItems that available here:\n{_inventory.ItemList}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}

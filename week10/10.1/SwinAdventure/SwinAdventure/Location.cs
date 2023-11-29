using System;
using System.Collections.Generic;
using System.IO;

namespace SwinAdventure
{
    // Define a Location class that inherits from GameObject
    public class Location : GameObject, IHaveInventory
    {
        // Declare a private field to store the location's item
        private Inventory _inventory;
        List<Paths> _paths;

        // Constructor for Location that takes a name and a description
        public Location(string name, string desc) : base(new string[] {"location"}, name, desc)
        {
            // Initialize the location's inventory
            _inventory = new Inventory();
            _paths = new List<Paths>();
        }

        public Location(string name, string desc, List<Paths> paths) : this(name, desc)
        {
            _paths = paths;
        }

        public GameObject Locate(string id)
        {
            // Check if the location matches the provided ID
            if (AreYou(id))
            {
                return this; // Return the location
            }

            foreach (Paths path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return $"You are in {base.FullDescription}\nItems that available here:\n{_inventory.ItemList}\n";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public void AddPath(Paths path)
        {
            _paths.Add(path);
        }

        public string PathDesc
        {
            get
            {
                // Case 1: No paths available
                if (_paths.Count == 0)
                {
                    return "There are no path here.";
                }
                // Case 2: Exactly one path available
                else if (_paths.Count == 1)
                {
                    return "You can go to " + _paths[0].FirstID + ".";
                }
                // Case 3: Multiple paths available
                else
                {
                    // Initialize the list string with an introductory phrase
                    string list = "There are ways to the ";

                    // Initialize counter to keep track of the iteration through _paths
                    int counter = 0;

                    // Iterate through each path in _paths using foreach
                    foreach (Paths path in _paths)
                    {
                        // If the current path is the last in the list...
                        if (counter == _paths.Count - 1)
                        {
                            // ...append "and [path.FirstID]." to the list string
                            list += "and " + path.FirstID + ".";
                        }
                        else
                        {
                            // If it's NOT the last path, append "[path.FirstID], " to the list string
                            list += path.FirstID + ", ";
                        }
                        // Increment counter for the next iteration
                        counter++;
                    }
                    // Return the fully constructed path list string
                    return list;
                }
            }
        }

        public string ItemList
        {
            get
            {
                if (_inventory != null)
                {
                    return "There is nothing.";
                }
                return "In the room you see:\n" + _inventory.ItemList;
            }
        }
    }
}

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
            if (AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public Paths FindPath(string id)
        {
            foreach (Paths path in _paths)
            {
                if (path.AreYou(id))
                {
                    return path;
                }
            }
            return null;
        }

        public override string FullDescription
        {
            get
            {
                return $"{base.FullDescription}\nItems that available here:\n{_inventory.ItemList}";
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

        public string PathList
        {
            get
            {
                if (_paths.Count == 0)
                {
                    return "\nThere are no exits.";
                }
                else
                {
                    string list = "\nPaths that you can go to:\n";
                    foreach (Paths path in _paths)
                    {
                        list += path.FirstID + "\n";
                    }
                    return list;
                }
            }
        }


        public bool PathExists(Paths checkPath)
        {
            return _paths.Contains(checkPath);
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

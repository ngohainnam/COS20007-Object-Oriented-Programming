using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    // Create an abstract class named GameObject, inheriting from IdentifiableObject
    public abstract class GameObject : IdentifiableObject
    {
        private string _description;
        private string _name;

        // Constructor for GameObject that takes an array of IDs, a name, and a description
        // It initializes the base class (IdentifiableObject) with the provided IDs
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            // Initialize the private fields with the provided name and description
            _name = name;
            _description = desc;
        }

        // Define a public property Name to get the object's name
        public string Name
        {
            get
            {
                return _name;
            }
        }

        // Define a public property ShortDescription to get a short description of the object
        public string ShortDescription
        {
            get
            {
                return $"{_name} ({FirstID})"; // It combines the name and the first ID of the object
            }
        }

        // Define a virtual property FullDescription to get the full description of the object
        public virtual string FullDescription  // Subclasses can override this property to provide a custom full description
        {
            get
            {
                return _description;
            }
        }
    }
}

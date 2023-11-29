using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Item : GameObject //item is a kind of game object
    {
        //create a default constructor of item
        public Item(string[] idents, string name, string desc) : base(idents, name, desc)
        {

        }
    }
}


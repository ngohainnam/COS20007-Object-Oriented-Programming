using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            // This provides a managed list of items
            _items = new List<Item>();
        }

        public bool HasItem(string id) //identify if the item is avalaible or not
        {
            //loop through every item
            foreach (Item item in _items)
            {
                //if an item is found with the correct id
                if (item.AreYou(id))
                {
                    //return true means the item is exist
                    return true;
                }
            }
            //return false means no item is found
            return false;
        }

        //items can be added using Put
        public void Put(Item item)
        {
            _items.Add(item);
        }

        public Item Take(string id)
        {
            // Fetch the item with the specified ID
            Item TakeItem = Fetch(id);
            // Remove the fetched item from the inventory
            _items.Remove(TakeItem);
            // Return the removed item
            return TakeItem;
        }

        public Item Fetch(string id)  //locates an item by id 
        {
            //this will loop through every item
            foreach (Item item in _items)
            {
                //in the case that item are found with the correct id
                if (item.AreYou(id))
                {
                    //return the item as the result
                    return item;
                }
            }
            //return null in the case that no item was found
            return null;
        }

        public string ItemList // Define a readonly property called ItemList of type string
        {
            get
            {
                // Initialize an empty string to store the list of item descriptions
                string ListItem = "";

                // Loop through each Item in the _items collection
                foreach (Item item in _items)
                {
                    // Append the short description of each item to the ListItem string,
                    ListItem = ListItem + item.ShortDescription +"\n";
                }
                // Return the generated item list as a single string
                return ListItem;
            }
        }
    }
}


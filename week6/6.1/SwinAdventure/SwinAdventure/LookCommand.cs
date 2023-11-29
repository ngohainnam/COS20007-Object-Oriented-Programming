using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] { "look" })
        {
        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;
            string _itemid;
            string _containerid;

            if (text.Length != 3 && text.Length !=5)//There must be either 3 or 5 elements in the array (I changed this so it must be 3 or 5 exactly.
            {
                return "I don't know how to look like that";
            }

            //The first word must be “look”, otherwise return “Error in look input"
            if (text[0].ToLower() != "look")
            {
                return "Error in look input";
            }

            //The second word must be “at”, otherwise return “What do you want to look at?
            if (text[1].ToLower() != "at")
            {
                return "What do you want to look at?";
            }

            if (text.Length == 3)
            {
                _container = p;
            }

            //If there are 5 elements, then the 4th word must be “in"
            if (text.Length == 5)
            {
                if (text[3].ToLower() != "in")
                {
                    //otherwise return “What do you want to look in?
                    return "What do you want to look in?";
                }

                // The container id is the 5th word
                _containerid = text[4];

                //this method retrieve the container from the Player
                _container = FetchContainer(p, _containerid);
            }

            //The item id is the 3rd word
            _itemid = text[2];

            //Perform the look at in, with the container and the item id
            return LookAtIn(_itemid, _container);
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {

            // Check if the container is null
            if (container == null)
            {
                return "I cannot find the " + thingId;
            }

            // Try to locate the item from the container
            GameObject item = container.Locate(thingId);

            if (item == null)
            {
                return "I cannot find the " + thingId + " in the " + container.Name;
            }

            // Return the full description of the Game Object found
            return item.FullDescription;
        }
    }
}

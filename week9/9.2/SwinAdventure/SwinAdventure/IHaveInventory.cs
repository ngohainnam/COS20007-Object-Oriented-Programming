using System;
using System.Collections.Generic;
using System.Text;

namespace SwinAdventure
{
    public interface IHaveInventory
    {
        GameObject Locate(string id);

        public string Name
        {
            get;
        }
    }
}

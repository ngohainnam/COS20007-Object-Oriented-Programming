using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterTask
{
    public class Counter
    {
        private int _count;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public int Ticks //read only
        {
            get
            {
                return _count;
            }
        }

        public Counter(string name)
        {
            _name = name; //set the name of the Counter
            _count = 0; //assigns 0 to the _count field
        }

        public void Increment()
        {
            //increases the value of the _count field by one.
            _count++;
        }

        public void Reset()
        {
            //assigns 0 to the _count field
            _count = 0;
        }
    }
}

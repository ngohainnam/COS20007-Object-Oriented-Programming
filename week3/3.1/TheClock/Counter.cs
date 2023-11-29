using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheClock
{
    public class Counter
    {
        private int _count;

        public int Ticks 
        {
            get
            {
                return _count;
            }
        }

        public Counter()
        {
            _count = 0; 
        }

        public void Increment()
        {
            _count++;
        }

        public void Reset()
        {
            _count = 0;
        }
    }
}


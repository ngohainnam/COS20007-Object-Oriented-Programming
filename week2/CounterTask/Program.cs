using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace CounterTask
{
    class MainClass
    {
        private static void PrintCounters(Counter[] counters)
        {
            //c: a reference to a Counter
            foreach (Counter c in counters)
            {
                //Tell Console, to WriteLine with the format "{0} is {1}"
                Console.WriteLine("{0} is {1}", c.Name, c.Ticks);
            }
        }

        public static void Main(string[] args)
        {
            //assign local variable
            int i;
            //an array of 3 references to Counter objects
            Counter[] myCounters = new Counter[3];

            //assign name to counters
            myCounters[0] = new Counter ("Counter1");
            myCounters[1] = new Counter ("Counter2");
            myCounters[2] = myCounters[0];

            //Loop i from 0 to 9
            for (i=0; i<10; i++)
            {
                //Tell myCounters[0] to Increment
                myCounters[0].Increment();
            }

            //Loop i from 0 to 14
            for (i=0; i<15; i++)
            {
                //Tell myCounters[1] to Increment
                myCounters[1].Increment();
            }

            //Tell MainClass to Print Counters, pass in myCounters
            PrintCounters(myCounters);

            //Tell myCounters[2] to Reset
            myCounters[2].Reset();

            //Tell MainClass to Print Counters, pass in myCounters
            PrintCounters(myCounters);
        }     
    }
}


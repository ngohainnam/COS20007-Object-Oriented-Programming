using System;
using System.Threading;
using TheClock;

class MainClass
{
    public static void Main(string[] args)
    {
        Clock clock = new Clock();

        while (true)
        {
            Thread.Sleep(100);
            Console.Clear();
            Console.WriteLine(clock.GetTimeString());
            clock.Ticks();
        }
    }
}

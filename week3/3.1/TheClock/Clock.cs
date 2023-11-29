using System;

namespace TheClock
{
    public class Clock
    {
        private Counter Hours = new();
        private Counter Minutes = new();
        private Counter Seconds = new();

        public string GetTimeString()
        {
            return $"{Hours.Ticks:D2}:{Minutes.Ticks:D2}:{Seconds.Ticks:D2}";
        }

        public void Ticks()
        {
            Seconds.Increment();

            if (Seconds.Ticks >= 60)
            {
                Minutes.Increment();
                Seconds.Reset();
            }

            if (Minutes.Ticks >= 60)
            {
                Hours.Increment();
                Minutes.Reset();
            }

            if (Hours.Ticks >= 24)
            {
                Hours.Reset();
            }
            Thread.Sleep(200);
        }

        public void Reset()
        {
            Hours.Reset();
            Minutes.Reset();
            Seconds.Reset(); 
        }
    }
}

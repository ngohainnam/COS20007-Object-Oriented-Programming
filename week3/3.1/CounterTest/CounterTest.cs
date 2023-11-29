using NUnit.Framework;
using TheClock;

namespace CounterTest
{
    public class CounterTests
    {
        private Counter counter;

        [SetUp]
        public void Setup()
        {
            counter = new Counter();
        }

        [Test]
        public void InitializingCounter_StartsAt0()
        {
            Assert.That(counter.Ticks, Is.EqualTo(0));
        }

        [Test]
        public void IncrementingCounter_AddsOneToCount()
        {
            counter.Increment();
            Assert.That(counter.Ticks, Is.EqualTo(1));
        }

        [Test]
        public void IncrementingCounter_MultipleTimes_IncreasesCount()
        {
            for (int i = 0; i < 10; i++)
            {
                counter.Increment();
            }
            Assert.That(counter.Ticks, Is.EqualTo(10));
        }

        [Test]
        public void ResettingCounter_SetsCountToZero()
        {
            counter.Increment();
            counter.Reset();
            Assert.That(counter.Ticks, Is.EqualTo(0));
        }
    }
}

using NUnit.Framework;
using TheClock;

namespace ClockTest
{
    public class ClockTests
    {
        private Clock clock;

        [SetUp]
        public void Setup()
        {
            clock = new Clock();
        }

        [Test]
        public void ReadTimeTest()
        {
            string expected = "00:00:00";
            string actual = clock.GetTimeString();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void TicksTest()
        {
            clock.Ticks();
            string expected = "00:00:01";
            string actual = clock.GetTimeString();
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ResetTest()
        {
            clock.Ticks();
            clock.Reset();
            string expected = "00:00:00";
            string actual = clock.GetTimeString();
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

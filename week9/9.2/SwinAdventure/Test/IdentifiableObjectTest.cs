using SwinAdventure;
using NUnit.Framework;

namespace TestSwinAdventure
{
    public class TestIdentifiableObject
    {
        private IdentifiableObject id;
        private IdentifiableObject idWithNoIDs;

        [SetUp]
        public void Setup()
        {
            // Create IdentifiableObject instances with identifiers for testing
            id = new IdentifiableObject(new string[] { "fred", "bob" });

            // Create an IdentifiableObject instance with no identifiers for testing
            idWithNoIDs = new IdentifiableObject(new string[] { });
        }

        [Test]
        public void TestAreYou()
        {
            // Assert that the object can correctly identify itself with the given identifiers
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }

        [Test]
        public void TestNotAreYou()
        {
            // Assert that the object does not incorrectly identify itself with identifiers it doesn't have
            Assert.IsFalse(id.AreYou("wilma"));
            Assert.IsFalse(id.AreYou("boby"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            // Assert that the identification is case-insensitive
            Assert.IsTrue(id.AreYou("FRED"));
            Assert.IsTrue(id.AreYou("bOB"));
        }

        [Test]
        public void TestFirstID()
        {
            // Assert that the first identifier is correctly retrieved
            Assert.AreEqual("fred", id.FirstID);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            // Assert that an empty string is returned when there are no identifiers
            Assert.AreEqual("", idWithNoIDs.FirstID);
        }

        [Test]
        public void TestAddID()
        {
            // Add an identifier and assert that the object can now identify itself with it
            id.AddIdentifier("wilma");
            Assert.IsTrue(id.AreYou("wilma"));
            Assert.IsTrue(id.AreYou("fred"));
            Assert.IsTrue(id.AreYou("bob"));
        }
    }
}

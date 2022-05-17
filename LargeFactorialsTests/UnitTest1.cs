using NUnit.Framework;
using LargeFactorials;
using LargeFactorialsTests;

namespace LargeFactorialsTests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("1", Program.Factorial(1));
            Assert.AreEqual("120", Program.Factorial(5));
            Assert.AreEqual("362880", Program.Factorial(9));
            Assert.AreEqual("1307674368000", Program.Factorial(15));
        }
    }
}
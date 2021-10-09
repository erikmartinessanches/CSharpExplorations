using NUnit.Framework;

namespace CSharpExplorationsTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SquareDigitsTest()
        {
            Assert.AreEqual(811181, CSharpExplorations.Challenges.SquareDigits(9119));
        }
    }
}
using NUnit.Framework;
using P10Gen.Core.Model;

namespace G10Gen.Core.Tests
{
    class CombinationTypeTest
    {
        [Test]
        public void Ctor_Aufgabe_Get()
        {
            Assert.AreEqual(Aufgabe.Type, new CombinationType(0, false).Aufgabe);
        }

        [TestCase(0, false, ExpectedResult = 0)]
        [TestCase(2, false, ExpectedResult = 2)]
        [TestCase(15, false, ExpectedResult = 15)]
        public int Ctor_Aufgabe_Get(int count, bool sameColor)
        {
            return new CombinationType(count, sameColor).Count;
        } 

        [TestCase(3, false, ExpectedResult = false)]
        [TestCase(3, true, ExpectedResult = true)]
        [TestCase(5, true, ExpectedResult = false)]
        public bool Ctor_SameColor_Get(int count, bool sameColor)
        {
            return new CombinationType(count, sameColor).SameColor;
        }

        [TestCase(3, true, ExpectedResult = 7.2)]
        [TestCase(7, true, ExpectedResult = 8.4)]
        [TestCase(3, false, ExpectedResult = 3.6)]
        [TestCase(7, false, ExpectedResult = 8.4)]
        public decimal CalculateComplexity_Cards_Result(int value, bool sameColor)
        {
            return new CombinationType(value, sameColor).CalculateComplexity();
        }
    }
}

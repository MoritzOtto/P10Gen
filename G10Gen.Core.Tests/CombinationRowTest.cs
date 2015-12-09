using NUnit.Framework;
using P10Gen.Core.Model;
using System.Linq;

namespace G10Gen.Core.Tests
{
    class CombinationRowTest
    {
        [Test]
        public void Ctor_Aufgabe_Get()
        {
            Assert.AreEqual(Aufgabe.Row, new CombinationRow(0, false).Aufgabe);
        }

        [TestCase(0, false, ExpectedResult = 0)]
        [TestCase(2, false, ExpectedResult = 2)]
        [TestCase(15, false, ExpectedResult = 15)]
        public int Ctor_Aufgabe_Get(int count, bool sameColor)
        {
            return new CombinationRow(count, sameColor).Count;
        } 

        [TestCase(3, false, ExpectedResult = false)]
        [TestCase(3, true, ExpectedResult = true)]
        [TestCase(5, true, ExpectedResult = true)]
        public bool Ctor_SameColor_Get(int count, bool sameColor)
        {
            return new CombinationRow(count, sameColor).SameColor;
        }

        [TestCase(3, true, ExpectedResult = 7.8)]
        [TestCase(7, true, ExpectedResult = 18.2)]
        [TestCase(3, false, ExpectedResult = 3.9)]
        [TestCase(7, false, ExpectedResult = 9.1)]
        public decimal CalculateComplexity_Cards_Result(int value, bool sameColor)
        {
            return new CombinationRow(value, sameColor).CalculateComplexity();
        }
    }
}

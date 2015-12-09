using NUnit.Framework;
using P10Gen.Core.Model;

namespace G10Gen.Core.Tests
{
    public class CombinationColorTest
    {
        [Test]
        public void Ctor_Aufgabe_Get()
        {
            Assert.AreEqual(Aufgabe.Color, new CombinationColor(0).Aufgabe);
        }

        [TestCase(0, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(15, ExpectedResult = 15)]
        public int Ctor_Aufgabe_Get(int count)
        {
            return new CombinationColor(count).Count;
        }

        [Test]
        public void Ctor_SameColor_Get()
        {
            Assert.IsFalse(new CombinationColor(1).SameColor);
        }

        [TestCase(3)]
        [TestCase(7)]
        public void CalculateComplexity_Cards_Result(int value)
        {
            Assert.AreEqual(value, new CombinationColor(value).CalculateComplexity());
        }
    }
}
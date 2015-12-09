using G10Gen.Core.Tests.Impls;
using NUnit.Framework;
using P10Gen.Core.Model;

namespace G10Gen.Core.Tests
{
    [TestFixture]
    class CombinationTest
    {
        [TestCase(Aufgabe.Color, false, ExpectedResult = Aufgabe.Color)]
        [TestCase(Aufgabe.Row, false, ExpectedResult = Aufgabe.Row)]
        [TestCase(Aufgabe.Type, false, ExpectedResult = Aufgabe.Type)]
        public Aufgabe Ctor_Aufgabe_Get(Aufgabe aufgabe, bool sameColor) {
            return new CombinationForTest(aufgabe, 0, sameColor).Aufgabe;
        }

        [TestCase(Aufgabe.Color, 0, false, ExpectedResult = 0)]
        [TestCase(Aufgabe.Row, 2, false, ExpectedResult = 2)]
        [TestCase(Aufgabe.Type, 15, false, ExpectedResult = 15)]
        public int Ctor_Aufgabe_Get(Aufgabe aufgabe, int count, bool sameColor)
        {
            return new CombinationForTest(aufgabe, count, sameColor).Count;
        }
    }
}

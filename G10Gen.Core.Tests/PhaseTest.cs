using System.Collections.Generic;
using G10Gen.Core.Tests.Impls;
using NUnit.Framework;
using P10Gen.Core.Model;

namespace G10Gen.Core.Tests
{
    public class PhaseTest
    {
        [TestCase(3.2)]
        [TestCase(5.4)]
        public void CalculateComplexity_OneCombi_IsIt(decimal complexity)
        {
            Assert.AreEqual(complexity, new Phase(new List<Combination> {new CombinationForTest(Aufgabe.Color, 3, false) {Complexity = complexity } }).CalculateComplexity());
        }

        [TestCase(3.2, 2.1, 4.3, ExpectedResult = 9.6)]
        [TestCase(5.4, 7.1, 6.6, ExpectedResult = 19.1)]
        public decimal CalculateComplexity_ThreeCombi_IsIt(decimal complexity, decimal complexity2, decimal complexity3)
        {
            var combinationForTest = new CombinationForTest(Aufgabe.Color, 3, false) { Complexity = complexity };
            var combinationForTest2 = new CombinationForTest(Aufgabe.Color, 3, false) { Complexity = complexity2 };
            var combinationForTest3 = new CombinationForTest(Aufgabe.Color, 3, false) { Complexity = complexity3 };
            return new Phase(new List<Combination> { combinationForTest, combinationForTest2, combinationForTest3 }).CalculateComplexity();
        }
    }
}
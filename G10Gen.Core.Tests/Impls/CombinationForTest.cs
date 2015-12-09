using System;
using P10Gen.Core.Model;

namespace G10Gen.Core.Tests.Impls
{
    public class CombinationForTest : Combination
    {
        public CombinationForTest(Aufgabe aufgabe, int count, bool sameColor) : base(aufgabe, count)
        {
            SameColor = sameColor;
        }

        public override bool SameColor { get; }

        public decimal Complexity { get; set; }

        public override decimal CalculateComplexity()
        {
            return Complexity;
        }
    }
}

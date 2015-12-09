namespace P10Gen.Core.Model
{
    public class CombinationRow : Combination
    {
        public CombinationRow(int count, bool sameColor) : base(Aufgabe.Row, count)
        {
            SameColor = sameColor;
        }

        public override bool SameColor { get; }
        public override decimal CalculateComplexity()
        {
            var wert = Count*1.3m;
            if (SameColor)
            {
                wert = wert*2;
            }

            return wert;
        }
    }
}
namespace P10Gen.Core.Model
{
    public class CombinationType : Combination
    {
        public CombinationType(int count, bool sameColor) : base(Aufgabe.Type, count)
        {
            if (count <= 4)
            {
                SameColor = sameColor;
            }
        }

        public override bool SameColor { get; }
        public override decimal CalculateComplexity()
        {
            var wert = Count * 1.2m;
            if (SameColor)
            {
                wert = wert * 2;
            }

            return wert;
        }
    }
}

namespace P10Gen.Core.Model
{
    public class CombinationColor : Combination
    {
        public CombinationColor(int count) : base(Aufgabe.Color, count)
        {
            SameColor = false;
        }

        public override bool SameColor { get; }
        public override decimal CalculateComplexity()
        {
            return Count;
        }
    }
}
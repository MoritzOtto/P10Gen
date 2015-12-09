namespace P10Gen.Core.Model
{
    public abstract class Combination
    {
        protected Combination(Aufgabe aufgabe, int count)
        {
            Aufgabe = aufgabe;
            Count = count;
        }

        public Aufgabe Aufgabe { get; private set; }
        public int Count { get; private set; }
        public abstract bool SameColor { get; }

        public abstract decimal CalculateComplexity();
    }
}

namespace P10Gen.Core.UtilAdapter
{
    public interface IRandomAdapter
    {
        int GetRandomInt(int minValue, int maxValue);
        bool RandomTrueFalse();
    }
}

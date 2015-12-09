using System;

namespace P10Gen.Core.UtilAdapter
{
    public class RandomAdapter : IRandomAdapter
    {
        private Random random; 

        public RandomAdapter()
        {
            random = new Random();
        }

        int IRandomAdapter.GetRandomInt(int minValue, int maxValue)
        {
            return random.Next(minValue, maxValue);
        }

        bool IRandomAdapter.RandomTrueFalse()
        {
            return ((IRandomAdapter)this).GetRandomInt(0, 1) == 1 ? true : false;
        }
    }
}

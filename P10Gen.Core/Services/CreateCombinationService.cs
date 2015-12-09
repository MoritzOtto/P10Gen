using System;
using P10Gen.Core.Model;
using P10Gen.Core.UtilAdapter;

namespace P10Gen.Core.Services
{
    public class CreateCombinationService : ICreateCombinationService
    {
        public IRandomAdapter randomAdapter;

        public CreateCombinationService(IRandomAdapter randomAdapter)
        {
            this.randomAdapter = randomAdapter;
        }

        public Combination Execute(int maxCards)
        {
            Aufgabe aufgabe = GetRandomAufgabe();
            bool sameColor = GetIsSameColor();
            int count = GetCount(aufgabe, maxCards);

            return CreateCombination(aufgabe, sameColor, count);
        }

        private Combination CreateCombination(Aufgabe aufgabe, bool sameColor, int count)
        {
            switch (aufgabe)
            {
                case Aufgabe.Color:
                    return new CombinationColor(count);
                case Aufgabe.Row:
                    return new CombinationRow(count, sameColor);
                case Aufgabe.Type:
                    return new CombinationType(count, sameColor);
                default:
                    return null;
            }
        }

        private int GetCount(Aufgabe aufgabe, int maxCards)
        {
            switch (aufgabe)
            {
                case Aufgabe.Color:
                case Aufgabe.Row:
                    return randomAdapter.GetRandomInt(2, maxCards);
                case Aufgabe.Type:
                    return randomAdapter.GetRandomInt(2, maxCards < 8 ? maxCards : 8);
                default:
                    return 0;
            }
        }

        private bool GetIsSameColor()
        {
            return randomAdapter.GetRandomInt(0, 4) == 0;
        }

        private Aufgabe GetRandomAufgabe()
        {
            return (Aufgabe)(randomAdapter.GetRandomInt(0, 2));
        }
    }
}

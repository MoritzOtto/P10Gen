using System.Collections.Generic;
using P10Gen.Core.Model;
using P10Gen.Core.UtilAdapter;

namespace P10Gen.Core.Services
{
    public class CreatePhaseService : ICreatePhaseService
    {
        private readonly IRandomAdapter randomAdapter;
        private readonly ICreateCombinationService createCombinationService;

        public CreatePhaseService(IRandomAdapter randomAdapter, ICreateCombinationService createCombinationService)
        {
            this.randomAdapter = randomAdapter;
            this.createCombinationService = createCombinationService;
        }

        public Phase Execute(int maxCards, decimal maxComplexity)
        {
            int numberOfCombinations = randomAdapter.GetRandomInt(1, 3);
            Phase phase = null;
            int tries = 0;
            while (PhaseIsInvalid(phase, maxComplexity) && tries < 3)
            {
                phase = CreatePhase(maxCards, maxComplexity, numberOfCombinations);
                tries++;
            }

            if (tries == 3)
            {
                phase = CreateFallbackPhase();
            }
            return phase;
        }

        private static Phase CreateFallbackPhase()
        {
            return new Phase(new List<Combination> {new CombinationColor(1)});
        }

        private static bool PhaseIsInvalid(Phase phase, decimal maxComplexity)
        {
            return phase == null || maxComplexity - phase.CalculateComplexity() < 0;
        }

        private Phase CreatePhase(int maxCards, decimal maxComplexity, int numberOfCombinations)
        {
            List<Combination> combinationList = new List<Combination>();
            int i = 0;
            while (i < numberOfCombinations)
            {
                i++;
                var initialMaxCards = CalculateInitialMaxCards(maxCards, numberOfCombinations - i);
                var combination =
                    createCombinationService.Execute(initialMaxCards);
                maxCards = maxCards - combination.Count;
                maxComplexity = maxComplexity - combination.CalculateComplexity();
                combinationList.Add(combination);
            }

            var phase = new Phase(combinationList);
            return phase;
        }

        private int CalculateInitialMaxCards(int maxCardsParam, int neededCombinations)
        {
            return maxCardsParam - neededCombinations * 2;
        }
    }
}

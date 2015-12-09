using System;
using System.Collections.Generic;
using System.Linq;
using P10Gen.Core.Model;

namespace P10Gen.Core.Services
{
    public class CreateTenPhases : ICreateTenPhases
    {
        private readonly ICreatePhaseService createPhaseService;

        public CreateTenPhases(ICreatePhaseService createPhaseService)
        {
            this.createPhaseService = createPhaseService;
        }

        public IEnumerable<Phase> Execute(decimal maxComplexity)
        {
            List<Phase> phases = new List<Phase>();
            int i = 0;
            while (i < 10)
            {
                i++;
                var calculateMaxComplexityForPhase = CalculateMaxComplexityForPhase(phases, maxComplexity, i);
                Phase phase = createPhaseService.Execute(10, calculateMaxComplexityForPhase);
                if (phase == null)
                {
                    throw new Exception();
                }
                phases.Add(phase);
            }

            return phases;
        }

        private decimal CalculateMaxComplexityForPhase(IEnumerable<Phase> phases, decimal maxComplexity, int numberOfPhase)
        {
            return maxComplexity - (10-numberOfPhase)*5 - ComplexityForPhases(phases);
        }

        private decimal ComplexityForPhases(IEnumerable<Phase> phases)
        {
            return phases.Aggregate<Phase, decimal>(0, (current, phase) => current + phase.CalculateComplexity());
        }
    }
}
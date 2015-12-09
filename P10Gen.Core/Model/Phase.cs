using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P10Gen.Core.Model
{
    public class Phase
    {
        public IEnumerable<Combination> Combinations { get; }

        public Phase(IEnumerable<Combination> combinations)
        {
            Combinations = combinations;
        }

        public decimal CalculateComplexity()
        {
            return Combinations.Aggregate(0m, (current, combination) => current + combination.CalculateComplexity());
        }

        public override string ToString()
        {
            List<String> parts = new List<string>();
            foreach (Combination combination in Combinations)
            {
                string aufgabenText = string.Empty;
                switch (combination.Aufgabe)
                {
                    case Aufgabe.Color:
                        aufgabenText = "einer Farbe";
                        break;
                    case Aufgabe.Row:
                        aufgabenText = "in einer Reihe";
                        break;
                    case Aufgabe.Type:
                        aufgabenText = "einer Art";
                        break;
                }

                string colorText = combination.SameColor ? " in der gleichen Farbe" : string.Empty;
                parts.Add($"{combination.Count} {aufgabenText}{colorText}");
            }

            return string.Join(" + ", parts);
        }
    }
}

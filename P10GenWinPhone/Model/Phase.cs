using System;
using System.Collections.Generic;
using System.Linq;

namespace P10GenContracts.Model
{
    public class Phase
    {
        public IEnumerable<Combination> Combinations { get; set; }

        public Phase(IEnumerable<Combination> combinations)
        {
            Combinations = combinations;
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

using System.Collections.Generic;
using System.Linq;
using P10Gen.Core.Model;

namespace P10Gen.Core.Services
{
    public interface ICreateTenPhases
    {
        IEnumerable<Phase> Execute(decimal maxComplexity);
    }
}
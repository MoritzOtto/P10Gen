using P10Gen.Core.Model;

namespace P10Gen.Core.Services
{
    public interface ICreatePhaseService
    {
        Phase Execute(int maxCards, decimal maxComplexity);
    }
}

using P10Gen.Core.Model;

namespace P10Gen.Core.Services
{
    public interface ICreateCombinationService
    {
        Combination Execute(int maxCards);
    }
}

using Moq;
using NUnit.Framework;
using P10Gen.Core.Model;
using P10Gen.Core.Services;
using P10Gen.Core.UtilAdapter;

namespace G10Gen.Core.Tests
{
    [TestFixture]
    class CreateCombinationServiceTest
    {
        private ICreateCombinationService createPhaseService;
        private Mock<IRandomAdapter> randomAdapterRepo;

        [SetUp]
        public void BeforeTests()
        {
            randomAdapterRepo = new Mock<IRandomAdapter>();
            createPhaseService = new CreateCombinationService(randomAdapterRepo.Object);
        }

        [TestCase(0, ExpectedResult = Aufgabe.Type)]
        [TestCase(1, ExpectedResult = Aufgabe.Color)]
        [TestCase(2, ExpectedResult = Aufgabe.Row)]
        public Aufgabe Execute_RandomReturns_AufgabenType(int randomValue)
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(0, 2)).Returns(randomValue);
           
            var phase = createPhaseService.Execute(10);

            return phase.Aufgabe;
        }

        [TestCase(0, 1, 2, 3, ExpectedResult = 1)]
        [TestCase(1, 1, 2, 3, ExpectedResult = 2)]
        [TestCase(2, 1, 2, 3, ExpectedResult = 2)]
        [TestCase(0, 7, 8, 9, ExpectedResult = 7)]
        [TestCase(1, 5, 6, 7, ExpectedResult = 6)]
        [TestCase(2, 4, 3, 2, ExpectedResult = 3)]
        public int Execute_RandomReturns_Count(int aufgabenValue, int randomValue18, int randomValue124, int randomValue112)
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(0, 2)).Returns(aufgabenValue);
            randomAdapterRepo.Setup(x => x.GetRandomInt(2, 8)).Returns(randomValue18);
            randomAdapterRepo.Setup(x => x.GetRandomInt(1, 12)).Returns(randomValue112);
            randomAdapterRepo.Setup(x => x.GetRandomInt(2, 10)).Returns(randomValue124);

            var phase = createPhaseService.Execute(10);

            return phase.Count;
        }

        [TestCase(0, 1, 2, 3, ExpectedResult = 1)]
        [TestCase(1, 1, 2, 3, ExpectedResult = 1)]
        [TestCase(2, 1, 2, 3, ExpectedResult = 1)]
        [TestCase(0, 7, 8, 9, ExpectedResult = 7)]
        [TestCase(1, 5, 6, 7, ExpectedResult = 5)]
        [TestCase(2, 4, 3, 2, ExpectedResult = 4)]
        public int Execute_RandomReturnsMaxCards_Count(int aufgabenValue, int randomValue18, int randomValue124, int randomValue112)
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(0, 2)).Returns(aufgabenValue);
            randomAdapterRepo.Setup(x => x.GetRandomInt(2, 4)).Returns(randomValue18);

            var phase = createPhaseService.Execute(4);

            return phase.Count;
        }

        [TestCase(0, 0, ExpectedResult = true)]
        [TestCase(0, 1, ExpectedResult = false)]
        [TestCase(0, 2, ExpectedResult = false)]
        [TestCase(0, 3, ExpectedResult = false)]
        [TestCase(1, 0, ExpectedResult = false)]
        [TestCase(1, 1, ExpectedResult = false)]
        [TestCase(1, 2, ExpectedResult = false)]
        [TestCase(1, 3, ExpectedResult = false)]
        [TestCase(2, 0, ExpectedResult = true)]
        [TestCase(2, 1, ExpectedResult = false)]
        [TestCase(2, 2, ExpectedResult = false)]
        [TestCase(2, 3, ExpectedResult = false)]
        public bool Execute_RandomReturns_Color(int aufgabenValue, int isColorRandom)
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(0, 2)).Returns(aufgabenValue);
            randomAdapterRepo.Setup(x => x.GetRandomInt(0, 4)).Returns(isColorRandom);

            var phase = createPhaseService.Execute(10);

            return phase.SameColor;
        }
    }
}

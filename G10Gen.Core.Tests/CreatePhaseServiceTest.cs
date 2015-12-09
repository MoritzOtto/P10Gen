using System;
using System.Linq;
using G10Gen.Core.Tests.Impls;
using Moq;
using NUnit.Framework;
using P10Gen.Core.Model;
using P10Gen.Core.Services;
using P10Gen.Core.UtilAdapter;

namespace G10Gen.Core.Tests
{
    [TestFixture]
    class CreatePhaseServiceTest
    {
        private ICreatePhaseService createPhaseService;
        private Mock<ICreateCombinationService> createCombinationService;
        private Mock<IRandomAdapter> randomAdapterRepo;

        [SetUp]
        public void BeforeTests()
        {
            createCombinationService = new Mock<ICreateCombinationService>();
            randomAdapterRepo = new Mock<IRandomAdapter>();
            createPhaseService = new CreatePhaseService(randomAdapterRepo.Object, createCombinationService.Object);
        }

        [Test]
        public void Execute_RandomAdapterOne_CallCombinationServiceResult()
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(1, 3)).Returns(1);
            var combinationForTest = new CombinationForTest(Aufgabe.Color, 1, false);
            createCombinationService.Setup(x => x.Execute(10)).Returns(combinationForTest);

            Phase result = createPhaseService.Execute(10, 10);

            Assert.AreEqual(combinationForTest, result.Combinations.FirstOrDefault());
        }

        [Test]
        public void Execute_RandomAdapterOneTooComplex_Fallback()
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(1, 3)).Returns(1);
            var combinationForTest = new CombinationForTest(Aufgabe.Row, 3, true) {Complexity = 20};
            createCombinationService.Setup(x => x.Execute(10)).Returns(combinationForTest);

            Phase result = createPhaseService.Execute(10, 10);

            Assert.IsNotNull(
                result.Combinations.FirstOrDefault(
                    x => x.SameColor == false && x.Aufgabe == Aufgabe.Color && x.Count == 1));
        }

        [Test]
        public void Execute_RandomAdapterThree_ContainsThreeElements()
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(1, 3)).Returns(3);
            var combinationForTest = new CombinationForTest(Aufgabe.Color, 1, false);
            createCombinationService.Setup(x => x.Execute(It.IsAny<int>())).Returns(combinationForTest);

            Phase result = createPhaseService.Execute(10, 10);

            Assert.AreEqual(3, result.Combinations.Count());
        }

        [Test]
        public void Execute_RandomAdapter_CardsCountedDown()
        {
            randomAdapterRepo.Setup(x => x.GetRandomInt(1, 3)).Returns(3);
            var combinationForTest = new CombinationForTest(Aufgabe.Color, 1, false);
            var combinationForTest2 = new CombinationForTest(Aufgabe.Color, 4, false);
            var combinationForTest3 = new CombinationForTest(Aufgabe.Color, 4, false);
            createCombinationService.Setup(x => x.Execute(6)).Returns(combinationForTest);
            createCombinationService.Setup(x => x.Execute(7)).Returns(combinationForTest2);
            createCombinationService.Setup(x => x.Execute(5)).Returns(combinationForTest3);

            Phase result = createPhaseService.Execute(10, 10);

            Assert.IsTrue(result.Combinations.Any(x => x == combinationForTest));
            Assert.IsTrue(result.Combinations.Any(x => x == combinationForTest2));
            Assert.IsTrue(result.Combinations.Any(x => x == combinationForTest3));
        }
    }
}

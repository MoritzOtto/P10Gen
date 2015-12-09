using System.Collections.Generic;
using System.Linq;
using G10Gen.Core.Tests.Impls;
using Moq;
using NUnit.Framework;
using P10Gen.Core.Model;
using P10Gen.Core.Services;

namespace G10Gen.Core.Tests
{
    [TestFixture]
    public class CreateTenPhasesTest
    {
        private ICreateTenPhases createTenPhases;
        private Mock<ICreatePhaseService> createPhaseServiceRepo;

        [SetUp]
        public void BeforeTests()
        {
            createPhaseServiceRepo = new Mock<ICreatePhaseService>();
            createTenPhases = new CreateTenPhases(createPhaseServiceRepo.Object);
        }

        [TestCase(75.1)]
        public void Execute_Called_HaveTenPhases(decimal maxComplexity)
        {
            var phase1 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 30.1m)).Returns(phase1);
            var phase2 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 35.1m)).Returns(phase2);
            var phase3 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 40.1m)).Returns(phase3);
            var phase4 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 45.1m)).Returns(phase4);
            var phase5 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 50.1m)).Returns(phase5);
            var phase6 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 55.1m)).Returns(phase6);
            var phase7 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 60.1m)).Returns(phase7);
            var phase8 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 65.1m)).Returns(phase8);
            var phase9 = new Phase(new List<Combination> { new CombinationForTest(Aufgabe.Row, 1, false) {Complexity = 9}});
            createPhaseServiceRepo.Setup(x => x.Execute(10, 70.1m)).Returns(phase9);
            var phase10 = new Phase(new List<Combination>());
            createPhaseServiceRepo.Setup(x => x.Execute(10, 66.1m)).Returns(phase10);

            var result = createTenPhases.Execute(maxComplexity);

            Assert.IsTrue(result.Any(x => x == phase1));
            Assert.IsTrue(result.Any(x => x == phase2));
            Assert.IsTrue(result.Any(x => x == phase3));
            Assert.IsTrue(result.Any(x => x == phase4));
            Assert.IsTrue(result.Any(x => x == phase5));
            Assert.IsTrue(result.Any(x => x == phase6));
            Assert.IsTrue(result.Any(x => x == phase7));
            Assert.IsTrue(result.Any(x => x == phase8));
            Assert.IsTrue(result.Any(x => x == phase9));
            Assert.IsTrue(result.Any(x => x == phase10));
        }

        [TestCase(90.1)]
        public void Execute_Called90_HaveTenPhases(decimal maxComplexity)
        {
            var phase1 = new Phase(new List<Combination> { new CombinationForTest(Aufgabe.Row, 1, false) { Complexity = 45.1m } });
            createPhaseServiceRepo.Setup(x => x.Execute(10, 45.1m)).Returns(phase1);
            var phase2 = new Phase(new List<Combination> { new CombinationForTest(Aufgabe.Row, 1, false) { Complexity = 5m } });
            createPhaseServiceRepo.Setup(x => x.Execute(10, 5m)).Returns(phase2);

            var result = createTenPhases.Execute(maxComplexity);

            Assert.IsTrue(result.Any(x => x == phase1));
            Assert.IsTrue(result.Any(x => x == phase2));
            Assert.AreEqual(10, result.Count());
        }
    }
}
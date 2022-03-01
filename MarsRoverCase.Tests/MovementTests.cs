using MarsRoverCase.Domain;
using MarsRoverCase.Domain.Enums;
using NUnit.Framework;

namespace MarsRoverCase.Tests
{
    public class MovementTests
    {
        Plateau plateau;
        [SetUp]
        public void Setup()
        {
            plateau = Plateau.Create(5, 5);
        }

        [Test]
        public void Move_1_2_N_LMLMLMLMM_1_3_N()
        {
            Rover rover = Rover.Create(plateau, 1, 2, Directions.N);

            var movesOfRover = "LMLMLMLMM";

            var expectedResultOfRover = "1 3 N";

            rover.Start(movesOfRover);

            var result = rover.GetPositionInformation();

            Assert.AreEqual(expectedResultOfRover, result);
        }

        [Test]
        public void Move_3_3_E_MMRMMRMRRM_5_1_E()
        {
            Rover rover = Rover.Create(plateau, 3, 3, Directions.E);

            var movesOfRover = "MMRMMRMRRM";

            var expectedResultOfRover = "5 1 E";

            rover.Start(movesOfRover);

            var result = rover.GetPositionInformation();

            Assert.AreEqual(expectedResultOfRover, result);
        }
    }
}
using System;
using System.Drawing;
using NUnit.Framework;

namespace BrightPixel.MarsRover.Test
{
    /// <summary>
    /// Tests the plateau class.
    /// </summary>
    [TestFixture]
    public class RoverTest
    {
        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorNullTest()
        {
            Rover rover = new Rover(null, null);

            Assert.IsNotNull(rover);
            Assert.IsNull(rover.Plateau);

            Assert.IsFalse(rover.CurrentHeading.HasValue);
            Assert.IsFalse(rover.CurrentPosition.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorNullPositionTest()
        { 
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover(null, testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);
            
            Assert.IsFalse(rover.CurrentHeading.HasValue);

            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.X == xCoordinate);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.Y == yCoordinate);

            Assert.IsFalse(rover.CurrentPosition.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorNullPlateauTest()
        {
            Rover rover = new Rover("1 2 N", null);

            Assert.IsNotNull(rover);
            Assert.IsNull(rover.Plateau);
            
            Assert.IsTrue(rover.CurrentHeading.HasValue);
            Assert.IsTrue(rover.CurrentHeading.Value == Heading.North);

            Assert.IsTrue(rover.CurrentPosition.HasValue);
            Assert.IsTrue(rover.CurrentPosition.Value.X == 1);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == 2);
        }

        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorInvalidTest()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("asdsdsdsdssadasda", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.X == xCoordinate);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.Y == yCoordinate);

            Assert.IsFalse(rover.CurrentHeading.HasValue);
            Assert.IsFalse(rover.CurrentPosition.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorLargeTest()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("12987231938721731289371298739128738912312 12987231938721731289371298739128738912312", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.X == xCoordinate);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.Y == yCoordinate);

            Assert.IsFalse(rover.CurrentHeading.HasValue);
            Assert.IsFalse(rover.CurrentPosition.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorTest()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("2 3 W", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.X == xCoordinate);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.Value.Y == yCoordinate);

            Assert.IsTrue(rover.CurrentHeading.HasValue);
            Assert.IsTrue(rover.CurrentHeading.Value == Heading.West);

            Assert.IsTrue(rover.CurrentPosition.Value.X == 2);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == 3);
        }

        [Test]
        public void TestNullInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("3 4 E", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;

            rover.ProcessInstructions(null);

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y);
            Assert.IsTrue(rover.CurrentHeading == currentHeading);
        }

        [Test]
        public void TestNullPlateauInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("3 4 E", null);

            Assert.IsNotNull(rover);
            Assert.IsNull(rover.Plateau);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;

            rover.ProcessInstructions("MLR");

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y);
            Assert.IsTrue(rover.CurrentHeading == currentHeading);
        }

        [Test]
        public void TestInvalidInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("4 5 S", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;

            rover.ProcessInstructions("XXXXX");

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y);
            Assert.IsTrue(rover.CurrentHeading == currentHeading);
        }

        [Test]
        public void TestMoveInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("0 0 N", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;

            rover.ProcessInstructions("M");

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y + 1);
            Assert.IsTrue(rover.CurrentHeading == currentHeading);
        }

        [Test]
        public void TestLeftInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("0 0 N", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;
            Heading? expectedHeading = Heading.West;

            rover.ProcessInstructions("L");

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y);
            Assert.IsFalse(rover.CurrentHeading == currentHeading);
            Assert.IsTrue(rover.CurrentHeading == expectedHeading);
        }

        [Test]
        public void TestRightInstruction()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("0 0 N", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point? currentPosition = rover.CurrentPosition;
            Heading? currentHeading = rover.CurrentHeading;
            Heading? expectedHeading = Heading.East;

            rover.ProcessInstructions("R");

            Assert.IsTrue(rover.CurrentPosition.Value.X == currentPosition.Value.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == currentPosition.Value.Y);
            Assert.IsFalse(rover.CurrentHeading == currentHeading);
            Assert.IsTrue(rover.CurrentHeading == expectedHeading);
        }

        [Test]
        public void TestOutputRover1()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("1 2 N", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point expectedPosition = new Point(1, 3);
            Heading? expectedHeading = Heading.North;

            rover.ProcessInstructions("LMLMLMLMM");

            Assert.IsTrue(rover.CurrentPosition.Value.X == expectedPosition.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == expectedPosition.Y);
            Assert.IsTrue(rover.CurrentHeading == expectedHeading);
        }

        [Test]
        public void TestOutputRover2()
        {
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();

            Plateau testPlateau = new Plateau(xCoordinate + " " + yCoordinate);

            Rover rover = new Rover("3 3 E", testPlateau);

            Assert.IsNotNull(rover);
            Assert.IsNotNull(rover.Plateau);
            Assert.IsTrue(rover.Plateau.UpperRightCoordinates.HasValue);

            Point expectedPosition = new Point(5, 1);
            Heading? expectedHeading = Heading.East;

            rover.ProcessInstructions("MMRMMRMRRM");

            Assert.IsTrue(rover.CurrentPosition.Value.X == expectedPosition.X);
            Assert.IsTrue(rover.CurrentPosition.Value.Y == expectedPosition.Y);
            Assert.IsTrue(rover.CurrentHeading == expectedHeading);
        }
    }
}

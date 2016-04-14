using System;
using System.Drawing;
using NUnit.Framework;

namespace BrightPixel.MarsRover.Test
{
    /// <summary>
    /// Tests the plateau class.
    /// </summary>
    [TestFixture]
    public class PlateauTest
    {
        /// <summary>
        /// Tests that the constructor works as expected.
        /// </summary>
        [Test]
        public void ConstructorTest()
        { 
            int xCoordinate = new Random().Next();
            int yCoordinate = new Random().Next();
            
            Plateau plateau = new Plateau(xCoordinate + " " + yCoordinate);

            Assert.IsNotNull(plateau);
            Assert.IsTrue(plateau.UpperRightCoordinates.HasValue);

            Assert.IsTrue(plateau.UpperRightCoordinates.Value.X == xCoordinate);
            Assert.IsTrue(plateau.UpperRightCoordinates.Value.Y == yCoordinate);
        }

        /// <summary>
        /// Tests that the constructor works as expected with null coordinate data.
        /// </summary>
        [Test]
        public void ConstructorNullTest()
        {
            Plateau plateau = new Plateau(null);

            Assert.IsNotNull(plateau);
            Assert.IsFalse(plateau.UpperRightCoordinates.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected with invalid coordinate data.
        /// </summary>
        [Test]
        public void ConstructorInvalidTest()
        {
            Plateau plateau = new Plateau("asddasdds");

            Assert.IsNotNull(plateau);
            Assert.IsFalse(plateau.UpperRightCoordinates.HasValue);
        }

        /// <summary>
        /// Tests that the constructor works as expected with invalid coordinate data.
        /// </summary>
        [Test]
        public void ConstructorTooLargeTest()
        {
            Plateau plateau = new Plateau("12312131313112313231321231321123 21331212312123123123123123123123312123123123");

            Assert.IsNotNull(plateau);
            Assert.IsFalse(plateau.UpperRightCoordinates.HasValue);
        }
    }
}

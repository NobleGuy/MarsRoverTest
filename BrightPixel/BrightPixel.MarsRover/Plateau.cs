using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BrightPixel.MarsRover
{
    public class Plateau
    {
        private Point? _upperRightCoordinates = null;

        /// <summary>
        /// Constructor that receives an input containing the upper right co-ordinates of the plateau
        /// </summary>
        /// <param name="upperRightCoordinateData">A string in the form "x y" defining the co-ordinates of the upper right co-ordinates of the plateau.</param>
        public Plateau(string upperRightCoordinateData)
        {
            try
            {
                this.PopulateUpperRightCoordinates(upperRightCoordinateData);
            }
            catch 
            {
                // Do some logging of some kind
            }
        }

        /// <summary>
        /// Parses the upper right coordinates string provided and, if valid, populates the upper right coordinates.
        /// </summary>
        /// <param name="upperRightCoordinateData">A string in the form "x y" defining the co-ordinates of the upper right co-ordinates of the plateau.</param>
        private void PopulateUpperRightCoordinates(string upperRightCoordinateData)
        {
            if(String.IsNullOrWhiteSpace(upperRightCoordinateData))
            {
                return;
            }

            // The coordinates should be supplied in "x y" form
            string[] data = upperRightCoordinateData.Split(' ');

            // Do some basic data checking
            if (data.Length == 2)
            {
                int x;
                int y;

                // Populate the coordinates if possible
                if (int.TryParse(data[0], out x) && int.TryParse(data[1], out y))
                {
                    this._upperRightCoordinates = new Point(x, y);
                }
            }
        }

        /// <summary>
        /// The upper right coordinates of the plateau.
        /// </summary>
        public Point? UpperRightCoordinates
        {
            get
            {
                return _upperRightCoordinates;
            }
        }
    }
}

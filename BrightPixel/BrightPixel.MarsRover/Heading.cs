using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightPixel.MarsRover
{
    /// <summary>
    /// An enum describing all the valid headings for the rover.
    /// </summary>
    public enum Heading
    {
        North = 0,
        Min = 0,
	NorthEast = 1,
        East = 2,
        SouthEast = 3,
        South = 4,
        SouthWest = 5,
        West = 6,
	NorthWest = 7
        Max = 7
    }
}

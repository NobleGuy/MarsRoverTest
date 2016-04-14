using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightPixel.MarsRover
{
    public class Rover
    {
        private Plateau _plateau = null;
        private Point? _currentPosition = null;
        private Heading? _currentHeading = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="defaultPosition">A string in the form "x y A" defining the co-ordinates of the rover's initial position and heading.</param>
        /// <param name="plateau">A Plateau object defining the extent of the plateau on which the rover is to be manoeuvred.</param>
        public Rover(string defaultPosition, Plateau plateau)
        {
            try
            {
                _plateau = plateau;

                this.PopulateDefaultPosition(defaultPosition);
                this.PopulateDefaultHeading(defaultPosition);
            }
            catch 
            {
                // Do some logging of some kind
            }
        }


        /// <summary>
        /// Parses the default heading data string provided and, if valid, populates the default heading.
        /// </summary>
        /// <param name="defaultPosition">A string in the form "x y A" defining the co-ordinates of the rover's initial position and heading.</param>
        private void PopulateDefaultHeading(string defaultPosition)
        {
            if (String.IsNullOrWhiteSpace(defaultPosition))
            {
                return;
            }

            // The coordinates should be supplied in "x y" form
            string[] positionData = defaultPosition.Split(' ');
            
            // Do some basic data checking
            if (positionData.Length == 3)
            {
                 // Populate the coordinates if possible
                if ("NESW".Contains(positionData[2]))
                {
                    switch(positionData[2])
                    {
                        case "N":
                            _currentHeading = Heading.North;
                            break;
                        case "E":
                            _currentHeading = Heading.East;
                            break;
                        case "S":
                            _currentHeading = Heading.South;
                            break;
                        case "W":
                            _currentHeading = Heading.West;
                            break;
                    }

                }   
            }
        }

        /// <summary>
        /// Parses the default position data string provided and, if valid, populates the default position coordinates.
        /// </summary>
        /// <param name="defaultPosition">A string in the form "x y A" defining the co-ordinates of the rover's initial position and heading.</param>
        private void PopulateDefaultPosition(string defaultPosition)
        {
            if (String.IsNullOrWhiteSpace(defaultPosition))
            {
                return;
            }

            // The coordinates should be supplied in "x y" form
            string[] positionData = defaultPosition.Split(' ');

            // Do some basic data checking
            if (positionData.Length == 3)
            {
                int defaultX;
                int defaultY;

                // Populate the coordinates if possible
                if (int.TryParse(positionData[0], out defaultX) && int.TryParse(positionData[1], out defaultY))
                {
                    _currentPosition = new Point(defaultX, defaultY);
                }
            }
        }

        /// <summary>
        /// Defines the plateau on which the rover is to be manoeuvred.
        /// </summary>
        public Plateau Plateau
        {
            get
            {
                return _plateau;
            }
        }

        /// <summary>
        /// Defines the rover's current position.
        /// </summary>
        public Point? CurrentPosition
        {
            get
            {
                return _currentPosition;
            }
        }

        /// <summary>
        /// Defines the rover's current position.
        /// </summary>
        public Heading? CurrentHeading
        {
            get
            {
                return _currentHeading;
            }
        }

        /// <summary>
        /// Processes the supplied instructions.
        /// </summary>
        /// <param name="instructions">The instructions to process.</param>
        /// <remarks>Instructions are provided as a string in which only 'M', 'L' and 'R' are valid characters.</remarks>
        public void ProcessInstructions(string instructions)
        {
            try
            {
                if (this._currentHeading.HasValue && this._currentPosition.HasValue
                        && _plateau != null && !String.IsNullOrWhiteSpace(instructions))
                {
                    char[] instructionList = instructions.ToCharArray();
                    foreach (char instruction in instructionList)
                    {
                        switch (instruction)
                        {
                            case 'M':
                                // Move the rover 1 point forward in the direction in which it is pointing
                                MoveForward();
                                break;
                            case 'R':
                                // Rotate the rover 90 degrees to the right
                                this.RotateRight();
                                break;
                            case 'L':
                                this.RotateLeft();
                                // Rotate the rover 90 degrees to the left
                                break;
                            default:
                                // It wasn't clear whether to ignore non-valid characters or to throw some kind of error.
                                break;
                        }
                    }
                }
            }
            catch
            { 
                // Do some logging of some kind
            }
        }

        /// <summary>
        /// Moves the rover forwards 1 point in the direction it is facing.
        /// </summary>
        private void MoveForward()
        {
            Point p = this._currentPosition.Value;
            switch (this._currentHeading.Value)
            {
                case Heading.North:
                    p.Y++;
                    break;
                case Heading.South:
                    p.Y--;
                    break;
                case Heading.East:
                    p.X++;
                    break;
                case Heading.West:
                    p.X--;
                    break;
                default:
                    // It wasn't clear whether to ignore non-valid characters or to throw some kind of error.
                    break;
            }

            this._currentPosition = p;
        }

        /// <summary>
        /// Rotates the rover 90 degrees to the right
        /// </summary>
        private void RotateRight()
        {
            this._currentHeading = (Heading?)(this._currentHeading.Value + 1);
            if (this._currentHeading.Value == Heading.Max + 1)
            {
                this._currentHeading = Heading.Min;
            }
        }

        /// <summary>
        /// Rotates the rover 90 degrees to the left.
        /// </summary>
        private void RotateLeft()
        {
            this._currentHeading = (Heading?)(this._currentHeading.Value - 1);
            if (this._currentHeading.Value == (Heading?)-1)
            {
                this._currentHeading = Heading.Max;
            }
        }
    }
}

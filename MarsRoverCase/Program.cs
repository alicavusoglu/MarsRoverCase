using MarsRoverCase.Application;
using MarsRoverCase.Domain.Enums;
using MarsRoverCase.ViewModels;
using System;
using System.Linq;

namespace MarsRoverCase
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creates a Rover Handler Instance
            RoverMovementHandler roverMovementHandler = new RoverMovementHandler();

            // Gets Plateau Field Info from UI
            PlateauViewModel plateauViewModel = TakePlateauInformation();

            //Gets rover Information, starts movement and gets position info sequentially in a loop 
            while (true)
            {
                // Gets Rover Info from UI
                RoverMovementViewModel roverMovementViewModel = TakeRoverInformation();

                //Handle the movement
                roverMovementHandler.Handle(plateauViewModel, roverMovementViewModel);
            }
        }

        /// <summary>
        /// Takes Plateau information from UI and return as a ViewModel
        /// </summary>
        /// <returns></returns>
        static PlateauViewModel TakePlateauInformation()
        {
            var inputOfUpperRightPoints = Console.ReadLine().Trim().Split(' ');
            int upperRightPointX;
            int upperRightPointY;

            //Checks Validity
            if (!(inputOfUpperRightPoints.Count() == 2
                && int.TryParse(inputOfUpperRightPoints[0], out upperRightPointX)
                && int.TryParse(inputOfUpperRightPoints[1], out upperRightPointY)))
            {
                //If any input invalid, returns back and pass information to UI
                Console.WriteLine("Wrong input format. Please try again");

                //Takes information again
                return TakePlateauInformation();
            }
            else
            {
                return new PlateauViewModel()
                {
                    UpperRightPointX = upperRightPointX,
                    UpperRightPointY = upperRightPointY
                };
            }
        }

        /// <summary>
        /// Takes Rover information from UI and return as a ViewModel
        /// </summary>
        /// <returns></returns>
        static RoverMovementViewModel TakeRoverInformation()
        {
            int roverPositionX, roverPositionY;
            string direction;
            var inputOfRoverInitialValues = Console.ReadLine().Trim().Split(' ');

            //Checks Validity
            if (!(inputOfRoverInitialValues.Count() == 3
                && int.TryParse(inputOfRoverInitialValues[0], out roverPositionX)
                && int.TryParse(inputOfRoverInitialValues[1], out roverPositionY)
                && "NSEW".Contains(inputOfRoverInitialValues[2]))) // Validate for direction input with "NSEW" string
            {
                //If any input invalid, returns back and pass information to UI
                Console.WriteLine("Wrong input format. Please try again");

                //Takes information again
                return TakeRoverInformation();
            }
            else
            {
                direction = inputOfRoverInitialValues[2];

                //Takes Moves
                var inputOfMoves = Console.ReadLine().Trim();

                return new RoverMovementViewModel()
                {
                    Direction = (Directions)Enum.Parse(typeof(Directions), direction),
                    RoverPositionX = roverPositionX,
                    RoverPositionY = roverPositionY,
                    Moves = inputOfMoves
                };
            }
        }
    }
}
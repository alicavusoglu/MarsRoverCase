using MarsRoverCase.Domain;
using MarsRoverCase.ViewModels;
using System;

namespace MarsRoverCase.Application
{
    public class RoverMovementHandler
    {
        public void Handle(PlateauViewModel plateauViewModel, RoverMovementViewModel roverMovementViewModel)
        {
            Plateau plateau = Plateau.Create(plateauViewModel.UpperRightPointX,
                                            plateauViewModel.UpperRightPointY);

            Rover rover = Rover.Create(plateau,
                                   roverMovementViewModel.RoverPositionX,
                                   roverMovementViewModel.RoverPositionY,
                                   roverMovementViewModel.Direction);

            rover.Start(roverMovementViewModel.Moves);
            Console.WriteLine(rover.GetPositionInformation());

            //Inserts empty line for separated visibility
            Console.WriteLine("");
        }
    }
}

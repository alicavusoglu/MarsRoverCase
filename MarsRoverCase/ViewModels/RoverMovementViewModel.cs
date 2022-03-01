using MarsRoverCase.Domain.Enums;

namespace MarsRoverCase.ViewModels
{
    public class RoverMovementViewModel
    {
        public int RoverPositionX { get; set; }
        public int RoverPositionY { get; set; }
        public Directions Direction { get; set; }
        public string Moves { get; set; }
    }
}

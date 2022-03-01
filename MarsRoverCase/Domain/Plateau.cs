using System;

namespace MarsRoverCase.Domain
{
    public class Plateau
    {
        private int _upperRightX;
        private int _upperRightY;

        public int UpperRightX { get => _upperRightX; }
        public int UpperRightY { get => _upperRightY; }

        private Plateau(int upperRightX, int upperRightY)
        {
            _upperRightX = upperRightX;
            _upperRightY = upperRightY;
        }

        public static Plateau Create(int upperRightX, int upperRightY)
        {
            if (upperRightY <= 0 || upperRightX <= 0)
            {
                throw new Exception($"Wrong upper right points. They must be greater than zero");
            }

            return new Plateau(upperRightX, upperRightY);
        }
    }
}
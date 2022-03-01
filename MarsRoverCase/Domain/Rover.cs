using MarsRoverCase.Domain.Enums;
using System;

namespace MarsRoverCase.Domain
{
    public class Rover
    {
        private int _x;
        public int X { get => _x; }

        private int _y;
        public int Y { get => _y; }

        private Directions _direction;
        public Directions Direction { get => _direction; }

        private Plateau _plateau;
        public Plateau Plateau { get => _plateau; }

        private Rover(Plateau plateau, int x, int y, Directions direction)
        {
            _plateau = plateau;
            _x = x;
            _y = y;
            _direction = direction;
        }

        public static Rover Create(Plateau plateau, int x, int y, Directions direction)
        {
            return new Rover(plateau, x, y, direction);
        }

        private void TurnLeft()
        {
            var currentDirection = (int)this._direction;
            switch (currentDirection)
            {
                case 1:
                    this._direction = (Directions)Enum.Parse(typeof(Directions), 4.ToString());
                    break;
                default:
                    this._direction = (Directions)Enum.Parse(typeof(Directions), (currentDirection - 1).ToString());
                    break;
            }
        }

        private void TurnRight()
        {
            var currentDirection = (int)this._direction;
            switch (currentDirection)
            {
                case 4:
                    this._direction = (Directions)Enum.Parse(typeof(Directions), 1.ToString());
                    break;
                default:
                    this._direction = (Directions)Enum.Parse(typeof(Directions), (currentDirection + 1).ToString());
                    break;
            }
        }

        private void Move()
        {
            switch (this._direction)
            {
                case Directions.N:
                    this._y += 1;
                    break;
                case Directions.S:
                    this._y -= 1;
                    break;
                case Directions.E:
                    this._x += 1;
                    break;
                case Directions.W:
                    this._x -= 1;
                    break;
                default:
                    break;
            }
        }

        public void Start(string actions)
        {
            foreach (var action in actions)
            {
                switch (action)
                {
                    case 'M':
                        this.Move();
                        break;
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    default:
                        Console.WriteLine($"{action} is not an action");
                        break;
                }

                if (this._x < 0 || this._x > _plateau.UpperRightX || this._y < 0 || this._y > _plateau.UpperRightY)
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({_plateau.UpperRightX} , {_plateau.UpperRightY})");
                }
            }
        }

        public string GetPositionInformation()
        {
            return $"{_x} {_y} {_direction}";
        }
    }
}

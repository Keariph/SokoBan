using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBan
{
    public abstract class GameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        protected GameObject(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void MoveTo(Direction direction, int x, int y)
        {
            switch (direction)
            {
                case Direction.Up:  y++; break;
                case Direction.Down: y--; break;
                case Direction.Left: x--; break;
                case Direction.Right: x++; break;
            }
        }
    }

    public enum Direction { Left, Up, Right, Down };
}

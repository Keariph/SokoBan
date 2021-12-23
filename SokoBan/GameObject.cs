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


        public void MoveTo(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow: Y--; break;
                case ConsoleKey.DownArrow: Y++; break;
                case ConsoleKey.LeftArrow: X--; break;
                case ConsoleKey.RightArrow: X++; break;
            }
        }
    }
}

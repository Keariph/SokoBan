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


        public Tuple<int, int> MoveTo(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow: return Tuple.Create(X, Y++);
                case ConsoleKey.DownArrow: return Tuple.Create(X, Y--);
                case ConsoleKey.LeftArrow: return Tuple.Create(X--, Y);
                case ConsoleKey.RightArrow: return Tuple.Create(X++, Y);
                default: return Tuple.Create(X, Y);
            }
        }
    }
}

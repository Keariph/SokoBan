using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBan
{
    interface GameObjectMovement
    {
        public void MoveTo(string direction);
        public bool IsTakenHere(int x, int y);
    }
}

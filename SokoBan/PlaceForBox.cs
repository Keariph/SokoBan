using System;
using System.Collections.Generic;
using System.Text;

namespace SokoBan
{
    class PlaceForBox : GameObject
    {
        public bool IsOpen;

        public PlaceForBox(int x, int y, bool isOpen) : base(x, y)
        {
            this.IsOpen = isOpen;
        }
    }
}

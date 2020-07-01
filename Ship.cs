using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGame
{
    class Ship
    {
        public int shipLocationTop;
        public int shipLocationLeft;
        public int shipWidth;
        public int shipHeight;
        public bool orientation;

      
        public Ship(int left, int top, int width, int height, bool ori)
        {
            shipLocationLeft = left;
            shipLocationTop = top;
            shipWidth = width;
            shipHeight = height;
            orientation = ori;
        }




    }
}

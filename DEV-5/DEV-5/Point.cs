using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_5
{
    public struct Point
    {
        public int coordinate_x;
        public int coordinate_y;
        public int coordinate_z; 

        public Point(int x, int y, int z)
        {
            this.coordinate_x = x;
            this.coordinate_y = y;
            this.coordinate_z = z;
        }
    }
}

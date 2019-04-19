using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_5
{
    class Bird : IFlyable
    {
        protected int coordinate_x = 0;
        protected int coordinate_y = 0;
        protected int coordinate_z = 0;

        public void FlyTo(Point newPoint)
        {
            coordinate_x = newPoint.coordinate_x;
            coordinate_y = newPoint.coordinate_y;
            coordinate_z = newPoint.coordinate_z;
        }

        public double GetFlyTime()
        {
            int finish_coordinate_x = 100;
            int finish_coordinate_y = 200;
            int finish_coordinate_z = 800;
            double flight_time = 0;
            double distance = Math.Sqrt((finish_coordinate_x - coordinate_x) ^ 2 + (finish_coordinate_y - coordinate_y) ^ 2 + (finish_coordinate_z - coordinate_z) ^ 2);
            Random random = new Random((DateTime.Now.Millisecond));
            double speed = random.Next(0, 20);
            flight_time = distance / speed;
            return flight_time*3600;
        }

        public string WhoAmI()
        {
            return "I'm a bird";
        }
    }
}


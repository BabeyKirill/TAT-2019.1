using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_5
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            var flying_objects = new List<IFlyable>();
            Bird bird = new Bird();
            Plane plane = new Plane();
            SpaceShip space_ship = new SpaceShip();
            flying_objects.Add(bird);
            flying_objects.Add(plane);
            flying_objects.Add(space_ship);

            Point newPoint = new Point(50, 100 ,400);
            foreach(var fly_obj in flying_objects)
            {
                Console.WriteLine(fly_obj.WhoAmI());
                Console.WriteLine($"Flight time is {fly_obj.GetFlyTime()} seconds");
                fly_obj.FlyTo(newPoint);
                Console.WriteLine($"Flight time is {fly_obj.GetFlyTime()} seconds");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_5
{
    interface IFlyable
    {
        void FlyTo(Point newPoint);
        string WhoAmI();
        double GetFlyTime();
    }
}

using System;
using System.Collections.Generic;

namespace DEV_7
{
    /// <summary>
    /// Set operations from console
    /// </summary>
    class OperationSetter
    {
        private CarList carlist;
        private TruckList trucklist;

        public OperationSetter(CarList carlist, TruckList trucklist)
        {
            this.carlist = carlist;
            this.trucklist = trucklist;
        }

        /// <summary>
        /// Uses console to set operations for TruckList and CarList
        /// </summary>
        public void SetOperations(List<Invoker> invoker)
        {
            while (true)
            {
                Console.Write("Write command: ");
                string OperationName = Console.ReadLine();
                int i = invoker.Count;
                if (OperationName.Contains("car"))
                {
                    invoker.Add(new Invoker());
                    invoker[i].SetCommand(new CarListCommand(carlist, OperationName));
                    i++;
                }
                else if (OperationName.Contains("truck"))
                {
                    invoker.Add(new Invoker());
                    invoker[i].SetCommand(new TruckListCommand(trucklist, OperationName));
                    i++;
                }
                else if (OperationName == "execute")
                {
                    foreach (Invoker inv in invoker)
                    {
                        inv.ExecuteCommand();
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }
    }
}

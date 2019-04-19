using System;
using System.Collections.Generic;

// This programm works with XML data bases of cars and trucks
namespace DEV_7
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            List<Invoker> invoker = new List<Invoker>();

            try
            {
                CarList carlist = CarList.GetInstance(args[0]);
                TruckList trucklist = TruckList.GetInstance(args[1]);

                OperationSetter OpSetter = new OperationSetter(carlist, trucklist);
                OpSetter.SetOperations(invoker);            
            }
            catch when (args.Length < 2)
            {
                Console.WriteLine("Command line must contains 2 arguments.");
            }
            catch
            {
                Console.WriteLine("Unexpected error");
            }
        }
    }
}

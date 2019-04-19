using System;

namespace DEV_6
{
    //This program works with the list of cars 

    class EntryPoint
    {
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();

            try
            {
                CarList carlist = new CarList(args[0]);
                invoker.SetCommand(new CarListCommandChoosing(carlist));
                invoker.ExecuteCommand();
            }
            catch when (args.Length == 0)
            {
                Console.WriteLine("Command line parameter is not set.");
            }
            catch
            {
                Console.WriteLine("Unexpected error");
            }
        }       
    }
}

using System;

namespace DEV_6
{
    /// <summary>
    /// Concrete command for car list
    /// </summary>
    class CarListCommandChoosing : ICommand
    {
        CarList carlist;

        public CarListCommandChoosing(CarList carlist)
        {
            this.carlist = carlist;
        }

        /// <summary>
        /// Calls the command specified in the console
        /// </summary>
        public void Execute()
        {
            while (true)
            {
                Console.Write("Write command: ");
                string CommandName = Console.ReadLine();

                if (CommandName == "count types")
                {
                    Console.WriteLine($"Number of brands is {carlist.GetCountTypes()}");
                }
                else if (CommandName == "count all")
                {
                    Console.WriteLine($"Total number of cars is {carlist.GetCountAll()}");
                }
                else if (CommandName == "average price")
                {
                    Console.WriteLine($"Average price of all cars is {carlist.GetAveragePrice()}");
                }
                else if (CommandName.IndexOf("average price") == 0 && CommandName.Length > ("average price ").Length)
                {
                    Console.WriteLine($"Average price of cars of brand is {carlist.GetAveragePriceType(CommandName)}");
                }
                else if (CommandName == "exit")
                {
                    Console.WriteLine("Programm was completed by your command");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Unknown Command");
                }
            }
        }
    }
}
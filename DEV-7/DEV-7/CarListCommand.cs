using System;

namespace DEV_7
{
    /// <summary>
    /// Concrete command for car list
    /// </summary>
    class CarListCommand : ICommand
    {
        private CarList carlist;
        public string OperationName { get; set; }

        public CarListCommand(CarList carlist, string OperationName)
        {
            this.carlist = carlist;
            this.OperationName = OperationName;
        }

        /// <summary>
        /// Calls the operation specified in the console
        /// </summary>
        public void Execute()
        {
            if (OperationName == "count types car")
            {
                Console.WriteLine($"Number of brands of cars is {carlist.GetCountTypes()}");
            }
            else if (OperationName == "count all car")
            {
                Console.WriteLine($"Total number of cars is {carlist.GetCountAll()}");
            }
            else if (OperationName == "average price car")
            {
                Console.WriteLine($"Average price of all cars is {carlist.GetAveragePrice()}");
            }
            else if (OperationName.IndexOf("average price car") == 0 && OperationName.Length > ("average price car ").Length)
            {
                Console.WriteLine($"Average price of cars of brand is {carlist.GetAveragePriceType(OperationName)}");
            }
            else
            {
                Console.WriteLine("Unknown Command");
            }
        }
    }
}

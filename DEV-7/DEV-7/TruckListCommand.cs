using System;

namespace DEV_7
{
    /// <summary>
    /// Concrete command for truck list
    /// </summary>
    class TruckListCommand : ICommand
    {
        TruckList trucklist;
        public string OperationName { get; set; }

        public TruckListCommand(TruckList trucklist, string OperationName)
        {
            this.trucklist = trucklist;
            this.OperationName = OperationName;
        }

        /// <summary>
        /// Calls the operation specified in the console
        /// </summary>
        public void Execute()
        {
            if (OperationName == "count types truck")
            {
                Console.WriteLine($"Number of brands of trucks is {trucklist.GetCountTypes()}");
            }
            else if (OperationName == "count all truck")
            {
                Console.WriteLine($"Total number of trucks is {trucklist.GetCountAll()}");
            }
            else if (OperationName == "average price truck")
            {
                Console.WriteLine($"Average price of all trucks is {trucklist.GetAveragePrice()}");
            }
            else if (OperationName.IndexOf("average price truck") == 0 && OperationName.Length > ("average price truck ").Length)
            {
                Console.WriteLine($"Average price of trucks of brand is {trucklist.GetAveragePriceType(OperationName)}");
            }
            else
            {
                Console.WriteLine("Unknown Command");
            }
        }
    }
}

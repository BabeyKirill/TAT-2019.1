using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DEV_10
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            JsonCreator.CreateProductsJSON();
            JsonCreator.CreateManufacturersJSON();
            JsonCreator.CreateWarehousesJSON();
            JsonCreator.CreateSuppliesJSON();
            JsonCreator.CreateAddressesJSON();
        }       
    }
}

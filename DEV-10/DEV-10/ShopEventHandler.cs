using Newtonsoft.Json;
using System.IO;

namespace DEV_10
{
    class ShopEventHandler
    {
        Shop shop { get; set; }

        public ShopEventHandler (Shop shop)
        {
            this.shop = shop;
        }

        public void UpdateProductsJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/products.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, shop.products);
            }
        }

        public void UpdateSuppliesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/supplies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, shop.supplies);
            }
        }

        public void UpdateAddressesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/addresses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, shop.addresses);
            }
        }

        public void UpdateManufacturersJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/manufacturers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, shop.manufacturers);
            }
        }

        public void UpdateWarehousesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/warehouses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, shop.warehouses);
            }
        }
    }
}

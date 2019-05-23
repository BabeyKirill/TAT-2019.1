using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_10
{
    class JsonCreator
    {
        public static void CreateManufacturersJSON()
        {
            Manufacturer[] Manufacturers = new Manufacturer[3];

            Manufacturers[0] = new Manufacturer()
            {
                Id = "manufacturer-1",
                Name = "Manufacturer1",
                AdressId = "address-1",
                CountryName = "Country1"
            };

            Manufacturers[1] = new Manufacturer()
            {
                Id = "manufacturer-2",
                Name = "Manufacturer2",
                AdressId = "address-2",
                CountryName = "Country2"
            };

            Manufacturers[2] = new Manufacturer()
            {
                Id = "manufacturer-3",
                Name = "Manufacturer3",
                AdressId = "address-3",
                CountryName = "Country3"
            };

            using (StreamWriter file = File.CreateText(@"C:\Users\mrKPb\source\repos\DEV-10\DEV-10\DataBase\Manufacturers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Manufacturers);
            }
        }

        public static void CreateWarehousesJSON()
        {
            Warehouse[] Warehouses = new Warehouse[2];

            Warehouses[0] = new Warehouse()
            {
                Id = "warehouse-1",
                Name = "Warehouse1",
                WarehouseAddress = new Address()
                {
                    Id = "adress-4",
                    CityName = "City4",
                    StreetName = "Street4",
                    HouseNumber = "4",
                    CountryName = "Country4"
                }
            };

            Warehouses[1] = new Warehouse()
            {
                Id = "warehouse-2",
                Name = "Warehouse2",
                WarehouseAddress = new Address()
                {
                    Id = "adress-5",
                    CityName = "City5",
                    StreetName = "Street5",
                    HouseNumber = "5",
                    CountryName = "Country4"
                }
            };

            using (StreamWriter file = File.CreateText(@"C:\Users\mrKPb\source\repos\DEV-10\DEV-10\DataBase\Warehouses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Warehouses);
            }
        }

        public static void CreateAddressesJSON()
        {
            Address[] Addresses = new Address[5];

            Addresses[0] = new Address()
            {
                Id = "adress-1",
                CityName = "City1",
                StreetName = "Street1",
                HouseNumber = "1",
                CountryName = "Country1"
            };

            Addresses[1] = new Address()
            {
                Id = "adress-2",
                CityName = "City2",
                StreetName = "Street2",
                HouseNumber = "2",
                CountryName = "Country2"
            };

            Addresses[2] = new Address()
            {
                Id = "adress-3",
                CityName = "City3",
                StreetName = "Street3",
                HouseNumber = "3",
                CountryName = "Country3"
            };

            Addresses[3] = new Address()
            {
                Id = "adress-4",
                CityName = "City4",
                StreetName = "Street4",
                HouseNumber = "4",
                CountryName = "Country4"
            };

            Addresses[4] = new Address()
            {
                Id = "adress-5",
                CityName = "City5",
                StreetName = "Street5",
                HouseNumber = "5",
                CountryName = "Country4"
            };

            using (StreamWriter file = File.CreateText(@"C:\Users\mrKPb\source\repos\DEV-10\DEV-10\DataBase\Addresses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Addresses);
            }
        }
        public static void CreateProductsJSON()
        {
            Product[] Products = new Product[9];

            Products[0] = new Product()
            {
                Id = "product-1",
                Name = "Product1",
                Amount = "11",
                ManufacturerId = "manufacture-1",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-1",
                ProductionDate = "01.11.2010"
            };

            Products[1] = new Product()
            {
                Id = "product-2",
                Name = "Product2",
                Amount = "12",
                ManufacturerId = "manufacture-3",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-2",
                ProductionDate = "01.12.2010"
            };

            Products[2] = new Product()
            {
                Id = "product-3",
                Name = "Product3",
                Amount = "13",
                ManufacturerId = "manufacture-3",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-3",
                ProductionDate = "01.13.2010"
            };

            Products[3] = new Product()
            {
                Id = "product-4",
                Name = "Product4",
                Amount = "14",
                ManufacturerId = "manufacture-1",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-4",
                ProductionDate = "01.14.2010"
            };

            Products[4] = new Product()
            {
                Id = "product-5",
                Name = "Product5",
                Amount = "15",
                ManufacturerId = "manufacture-2",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-5",
                ProductionDate = "01.15.2010"
            };

            Products[5] = new Product()
            {
                Id = "product-6",
                Name = "Product6",
                Amount = "16",
                ManufacturerId = "manufacture-2",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-6",
                ProductionDate = "01.16.2010"
            };

            Products[6] = new Product()
            {
                Id = "product-7",
                Name = "Product7",
                Amount = "17",
                ManufacturerId = "manufacture-1",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-7",
                ProductionDate = "01.17.2010"
            };

            Products[7] = new Product()
            {
                Id = "product-8",
                Name = "Product8",
                Amount = "18",
                ManufacturerId = "manufacture-3",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-8",
                ProductionDate = "01.18.2010"
            };

            Products[8] = new Product()
            {
                Id = "product-9",
                Name = "Product9",
                Amount = "19",
                ManufacturerId = "manufacture-2",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-9",
                ProductionDate = "01.19.2010"
            };

            using (StreamWriter file = File.CreateText(@"C:\Users\mrKPb\source\repos\DEV-10\DEV-10\DataBase\Products.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Products);
            }
        }

        public static void CreateSuppliesJSON()
        {
            Supply[] Supplies = new Supply[9];

            Supplies[0] = new Supply()
            {
                Id = "supply-1",
                Description = "Supply of Products1",
                Date = "02.11.2010"
            };

            Supplies[1] = new Supply()
            {
                Id = "supply-2",
                Description = "Supply of Products2",
                Date = "02.12.2010"
            };

            Supplies[2] = new Supply()
            {
                Id = "supply-3",
                Description = "Supply of Products3",
                Date = "02.13.2010"
            };

            Supplies[3] = new Supply()
            {
                Id = "supply-4",
                Description = "Supply of Products4",
                Date = "02.14.2010"
            };

            Supplies[4] = new Supply()
            {
                Id = "supply-5",
                Description = "Supply of Products5",
                Date = "02.15.2010"
            };

            Supplies[5] = new Supply()
            {
                Id = "supply-6",
                Description = "Supply of Products6",
                Date = "02.16.2010"
            };

            Supplies[6] = new Supply()
            {
                Id = "supply-7",
                Description = "Supply of Products7",
                Date = "02.17.2010"
            };

            Supplies[7] = new Supply()
            {
                Id = "supply-8",
                Description = "Supply of Products8",
                Date = "02.18.2010"
            };

            Supplies[8] = new Supply()
            {
                Id = "supply-9",
                Description = "Supply of Products9",
                Date = "02.19.2010"
            };

            using (StreamWriter file = File.CreateText(@"C:\Users\mrKPb\source\repos\DEV-10\DEV-10\DataBase\Supplies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, Supplies);
            }
        }
    }
}

using Newtonsoft.Json;
using System.IO;

namespace DEV_10
{
    class JsonsForTests
    {
        /// <summary>
        /// Сreating files for tests
        /// </summary>
        public static void CreateAllJsons()
        {
            CreateProductsJson();
            CreateManufacturersJson();
            CreateWarehousesJson();
            CreateSuppliesJson();
            CreateAddressesJson();
        }

        public static void CreateManufacturersJson()
        {
            Manufacturer[] manufacturers = new Manufacturer[3];

            manufacturers[0] = new Manufacturer()
            {
                Id = "manufacturer-1",
                Name = "Manufacturer1",
                AdressId = "WarehouseAddress-1",
                CountryName = "Country1"
            };

            manufacturers[1] = new Manufacturer()
            {
                Id = "manufacturer-2",
                Name = "Manufacturer2",
                AdressId = "WarehouseAddress-2",
                CountryName = "Country2"
            };

            manufacturers[2] = new Manufacturer()
            {
                Id = "manufacturer-3",
                Name = "Manufacturer3",
                AdressId = "WarehouseAddress-3",
                CountryName = "Country3"
            };

            using (StreamWriter file = File.CreateText(@"../../DataBase/manufacturers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, manufacturers);
            }
        }

        public static void CreateWarehousesJson()
        {
            Warehouse[] warehouses = new Warehouse[2];

            warehouses[0] = new Warehouse()
            {
                Id = "warehouse-1",
                Name = "Warehouse1",
                WarehouseAddress = new Address()
                {
                    Id = "address-4",
                    CityName = "City4",
                    StreetName = "Street4",
                    HouseNumber = "4",
                    CountryName = "Country4"
                }
            };

            warehouses[1] = new Warehouse()
            {
                Id = "warehouse-2",
                Name = "Warehouse2",
                WarehouseAddress = new Address()
                {
                    Id = "address-5",
                    CityName = "City5",
                    StreetName = "Street5",
                    HouseNumber = "5",
                    CountryName = "Country4"
                }
            };

            using (StreamWriter file = File.CreateText(@"../../DataBase/warehouses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, warehouses);
            }
        }

        public static void CreateAddressesJson()
        {
            Address[] addresses = new Address[5];

            addresses[0] = new Address()
            {
                Id = "address-1",
                CityName = "City1",
                StreetName = "Street1",
                HouseNumber = "1",
                CountryName = "Country1"
            };

            addresses[1] = new Address()
            {
                Id = "address-2",
                CityName = "City2",
                StreetName = "Street2",
                HouseNumber = "2",
                CountryName = "Country2"
            };

            addresses[2] = new Address()
            {
                Id = "address-3",
                CityName = "City3",
                StreetName = "Street3",
                HouseNumber = "3",
                CountryName = "Country3"
            };

            addresses[3] = new Address()
            {
                Id = "address-4",
                CityName = "City4",
                StreetName = "Street4",
                HouseNumber = "4",
                CountryName = "Country4"
            };

            addresses[4] = new Address()
            {
                Id = "address-5",
                CityName = "City5",
                StreetName = "Street5",
                HouseNumber = "5",
                CountryName = "Country4"
            };

            using (StreamWriter file = File.CreateText(@"../../DataBase/addresses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, addresses);
            }
        }
        public static void CreateProductsJson()
        {
            Product[] products = new Product[9];

            products[0] = new Product()
            {
                Id = "product-1",
                Name = "Product1",
                Amount = "11",
                ManufacturerId = "manufacturer-1",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-1",
                ProductionDate = "01.11.2010"
            };

            products[1] = new Product()
            {
                Id = "product-2",
                Name = "Product2",
                Amount = "12",
                ManufacturerId = "manufacturer-3",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-2",
                ProductionDate = "01.12.2010"
            };

            products[2] = new Product()
            {
                Id = "product-3",
                Name = "Product3",
                Amount = "13",
                ManufacturerId = "manufacturer-3",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-3",
                ProductionDate = "01.13.2010"
            };

            products[3] = new Product()
            {
                Id = "product-4",
                Name = "Product4",
                Amount = "14",
                ManufacturerId = "manufacturer-1",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-4",
                ProductionDate = "01.14.2010"
            };

            products[4] = new Product()
            {
                Id = "product-5",
                Name = "Product5",
                Amount = "15",
                ManufacturerId = "manufacturer-2",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-5",
                ProductionDate = "01.15.2010"
            };

            products[5] = new Product()
            {
                Id = "product-6",
                Name = "Product6",
                Amount = "16",
                ManufacturerId = "manufacturer-2",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-6",
                ProductionDate = "01.16.2010"
            };

            products[6] = new Product()
            {
                Id = "product-7",
                Name = "Product7",
                Amount = "17",
                ManufacturerId = "manufacturer-1",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-7",
                ProductionDate = "01.17.2010"
            };

            products[7] = new Product()
            {
                Id = "product-8",
                Name = "Product8",
                Amount = "18",
                ManufacturerId = "manufacturer-3",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-8",
                ProductionDate = "01.18.2010"
            };

            products[8] = new Product()
            {
                Id = "product-9",
                Name = "Product9",
                Amount = "19",
                ManufacturerId = "manufacturer-2",
                WarehouseId = "warehouse-1",
                SupplyId = "supply-9",
                ProductionDate = "01.19.2010"
            };

            using (StreamWriter file = File.CreateText(@"../../DataBase/products.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, products);
            }
        }

        public static void CreateSuppliesJson()
        {
            Supply[] supplies = new Supply[9];

            supplies[0] = new Supply()
            {
                Id = "supply-1",
                Description = "Supply of Products1",
                Date = "02.11.2010"
            };

            supplies[1] = new Supply()
            {
                Id = "supply-2",
                Description = "Supply of Products2",
                Date = "02.12.2010"
            };

            supplies[2] = new Supply()
            {
                Id = "supply-3",
                Description = "Supply of Products3",
                Date = "02.13.2010"
            };

            supplies[3] = new Supply()
            {
                Id = "supply-4",
                Description = "Supply of Products4",
                Date = "02.14.2010"
            };

            supplies[4] = new Supply()
            {
                Id = "supply-5",
                Description = "Supply of Products5",
                Date = "02.15.2010"
            };

            supplies[5] = new Supply()
            {
                Id = "supply-6",
                Description = "Supply of Products6",
                Date = "02.16.2010"
            };

            supplies[6] = new Supply()
            {
                Id = "supply-7",
                Description = "Supply of Products7",
                Date = "02.17.2010"
            };

            supplies[7] = new Supply()
            {
                Id = "supply-8",
                Description = "Supply of Products8",
                Date = "02.18.2010"
            };

            supplies[8] = new Supply()
            {
                Id = "supply-9",
                Description = "Supply of Products9",
                Date = "02.19.2010"
            };

            using (StreamWriter file = File.CreateText(@"../../DataBase/supplies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, supplies);
            }
        }
    }
}

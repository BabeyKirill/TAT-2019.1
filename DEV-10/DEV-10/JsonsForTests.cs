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
                id = "manufacturer-1",
                name = "Manufacturer1",
                adressId = "address-1",
                countryName = "Country1"
            };

            manufacturers[1] = new Manufacturer()
            {
                id = "manufacturer-2",
                name = "Manufacturer2",
                adressId = "address-2",
                countryName = "Country2"
            };

            manufacturers[2] = new Manufacturer()
            {
                id = "manufacturer-3",
                name = "Manufacturer3",
                adressId = "address-3",
                countryName = "Country3"
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
                id = "warehouse-1",
                name = "Warehouse1",
                address = new Address()
                {
                    id = "adress-4",
                    cityName = "City4",
                    streetName = "Street4",
                    houseNumber = "4",
                    countryName = "Country4"
                }
            };

            warehouses[1] = new Warehouse()
            {
                id = "warehouse-2",
                name = "Warehouse2",
                address = new Address()
                {
                    id = "adress-5",
                    cityName = "City5",
                    streetName = "Street5",
                    houseNumber = "5",
                    countryName = "Country4"
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
                id = "adress-1",
                cityName = "City1",
                streetName = "Street1",
                houseNumber = "1",
                countryName = "Country1"
            };

            addresses[1] = new Address()
            {
                id = "adress-2",
                cityName = "City2",
                streetName = "Street2",
                houseNumber = "2",
                countryName = "Country2"
            };

            addresses[2] = new Address()
            {
                id = "adress-3",
                cityName = "City3",
                streetName = "Street3",
                houseNumber = "3",
                countryName = "Country3"
            };

            addresses[3] = new Address()
            {
                id = "adress-4",
                cityName = "City4",
                streetName = "Street4",
                houseNumber = "4",
                countryName = "Country4"
            };

            addresses[4] = new Address()
            {
                id = "adress-5",
                cityName = "City5",
                streetName = "Street5",
                houseNumber = "5",
                countryName = "Country4"
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
                id = "product-1",
                name = "Product1",
                amount = "11",
                manufacturerId = "manufacturer-1",
                warehouseId = "warehouse-1",
                supplyId = "supply-1",
                productionDate = "01.11.2010"
            };

            products[1] = new Product()
            {
                id = "product-2",
                name = "Product2",
                amount = "12",
                manufacturerId = "manufacturer-3",
                warehouseId = "warehouse-1",
                supplyId = "supply-2",
                productionDate = "01.12.2010"
            };

            products[2] = new Product()
            {
                id = "product-3",
                name = "Product3",
                amount = "13",
                manufacturerId = "manufacturer-3",
                warehouseId = "warehouse-2",
                supplyId = "supply-3",
                productionDate = "01.13.2010"
            };

            products[3] = new Product()
            {
                id = "product-4",
                name = "Product4",
                amount = "14",
                manufacturerId = "manufacturer-1",
                warehouseId = "warehouse-2",
                supplyId = "supply-4",
                productionDate = "01.14.2010"
            };

            products[4] = new Product()
            {
                id = "product-5",
                name = "Product5",
                amount = "15",
                manufacturerId = "manufacturer-2",
                warehouseId = "warehouse-2",
                supplyId = "supply-5",
                productionDate = "01.15.2010"
            };

            products[5] = new Product()
            {
                id = "product-6",
                name = "Product6",
                amount = "16",
                manufacturerId = "manufacturer-2",
                warehouseId = "warehouse-1",
                supplyId = "supply-6",
                productionDate = "01.16.2010"
            };

            products[6] = new Product()
            {
                id = "product-7",
                name = "Product7",
                amount = "17",
                manufacturerId = "manufacturer-1",
                warehouseId = "warehouse-1",
                supplyId = "supply-7",
                productionDate = "01.17.2010"
            };

            products[7] = new Product()
            {
                id = "product-8",
                name = "Product8",
                amount = "18",
                manufacturerId = "manufacturer-3",
                warehouseId = "warehouse-2",
                supplyId = "supply-8",
                productionDate = "01.18.2010"
            };

            products[8] = new Product()
            {
                id = "product-9",
                name = "Product9",
                amount = "19",
                manufacturerId = "manufacturer-2",
                warehouseId = "warehouse-1",
                supplyId = "supply-9",
                productionDate = "01.19.2010"
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
                id = "supply-1",
                description = "Supply of Products1",
                date = "02.11.2010"
            };

            supplies[1] = new Supply()
            {
                id = "supply-2",
                description = "Supply of Products2",
                date = "02.12.2010"
            };

            supplies[2] = new Supply()
            {
                id = "supply-3",
                description = "Supply of Products3",
                date = "02.13.2010"
            };

            supplies[3] = new Supply()
            {
                id = "supply-4",
                description = "Supply of Products4",
                date = "02.14.2010"
            };

            supplies[4] = new Supply()
            {
                id = "supply-5",
                description = "Supply of Products5",
                date = "02.15.2010"
            };

            supplies[5] = new Supply()
            {
                id = "supply-6",
                description = "Supply of Products6",
                date = "02.16.2010"
            };

            supplies[6] = new Supply()
            {
                id = "supply-7",
                description = "Supply of Products7",
                date = "02.17.2010"
            };

            supplies[7] = new Supply()
            {
                id = "supply-8",
                description = "Supply of Products8",
                date = "02.18.2010"
            };

            supplies[8] = new Supply()
            {
                id = "supply-9",
                description = "Supply of Products9",
                date = "02.19.2010"
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

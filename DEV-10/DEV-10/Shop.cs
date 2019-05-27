using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

using System.Xml.Linq;

namespace DEV_10
{
    class Shop
    {
        public List<Product> products { get; set; }
        public List<Supply> supplies { get; set; }
        public List<Address> addresses { get; set; }
        public List<Manufacturer> manufacturers { get; set; }
        public List<Warehouse> warehouses { get; set; }

        /// <summary>
        /// Сonstructor initializing lists of objects using JSON files and subcscribe them to events
        /// </summary>
        public Shop()
        {
            string productsJson = File.ReadAllText(@"../../DataBase/products.json");
            this.products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
            foreach (Product prod in products)
            {
                prod.ProductChanged += UpdateProductsJson;
            }

            string suppliesJson = File.ReadAllText(@"../../DataBase/supplies.json");
            this.supplies = JsonConvert.DeserializeObject<List<Supply>>(suppliesJson);
            foreach (Supply supp in supplies)
            {
                supp.SupplyChanged += UpdateSuppliesJson;
            }

            string addressesJson = File.ReadAllText(@"../../DataBase/addresses.json");
            this.addresses = JsonConvert.DeserializeObject<List<Address>>(addressesJson);
            foreach (Address addr in addresses)
            {
                addr.AddressChanged += UpdateAddressesJson;
            }

            string manufacturersJson = File.ReadAllText(@"../../DataBase/manufacturers.json");
            this.manufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(manufacturersJson);
            foreach (Manufacturer manuf in manufacturers)
            {
                manuf.ManufacturerChanged += UpdateManufacturersJson;
            }

            string warehousesJson = File.ReadAllText(@"../../DataBase/warehouses.json");
            this.warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(warehousesJson);
            foreach (Warehouse ware in warehouses)
            {
                ware.WarehouseChanged += UpdateWarehousesJson;
            }
        }

        public void UpdateProductsJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/products.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, this.products);
            }
        }

        public void UpdateSuppliesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/supplies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, this.supplies);
            }
        }

        public void UpdateAddressesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/addresses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, this.addresses);
            }
        }

        public void UpdateManufacturersJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/manufacturers.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, this.manufacturers);
            }
        }

        public void UpdateWarehousesJson()
        {
            using (StreamWriter file = File.CreateText(@"../../DataBase/warehouses.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, this.warehouses);
            }
        }

        /// <summary>
        /// adds Product object to list of products and JSON file
        /// </summary>
        public void AddProduct(Product newProduct)
        {
            this.products.Add(newProduct);
            this.products[products.Count - 1].ProductChanged += UpdateProductsJson;

            UpdateProductsJson();
        }

        /// <summary>
        /// Removes Product object from list of products and JSON file
        /// </summary>
        public void DeleteProduct(string productName)
        {
            Product removingProduct = products.Find(obj => obj.name == productName);
            this.products.Remove(removingProduct);

            UpdateProductsJson();
        }

        /// <summary>
        /// Changes warehouse address to a new one.
        /// </summary>
        public void ChangeWarehouseAddress(string warehouseName, Address newAddress)
        {
            int warehousesIndex = warehouses.FindIndex(obj => obj.name == warehouseName);
            string warehouseAddressId = this.warehouses[warehousesIndex].address.id;
            int addressesIndex = addresses.FindIndex(obj => obj.id == warehouseAddressId);
            this.addresses[addressesIndex] = newAddress;
            this.warehouses[warehousesIndex].address = newAddress;

            UpdateAddressesJson();
            UpdateWarehousesJson();
        }

        /// <summary>
        /// adds Warehouse object to list of warehouses and JSON file
        /// </summary>
        public void AddWarehouse(Warehouse newWarehouse)
        {
            this.warehouses.Add(newWarehouse);
            this.warehouses[warehouses.Count - 1].WarehouseChanged += UpdateWarehousesJson;

            UpdateWarehousesJson();
        }

        /// <summary>
        /// Removes Warehouse object from list of warehouses and JSON file
        /// </summary>
        public void DeleteWarehouse(string warehouseName)
        {
            Warehouse removingWarehouse = warehouses.Find(obj => obj.name == warehouseName);
            this.warehouses.Remove(removingWarehouse);

            UpdateWarehousesJson();
        }

        /// <summary>
        /// Writes all information about all products to the console from JSON files.
        /// </summary>
        public void ShowFullDescription()
        {
            foreach (Product prod in this.products)
            {
                Console.WriteLine($"Product name: {prod.name}");
                Console.WriteLine($"id: {prod.id}");
                Console.WriteLine($"amount: {prod.amount}");
                Console.WriteLine($"Production date: {prod.productionDate}");

                Manufacturer manufacturer = manufacturers.Find(obj => obj.id == prod.manufacturerId);
                Console.WriteLine($"Manufacturer name: {manufacturer.name}");
                Console.WriteLine($"Manufacturer id: {manufacturer.id}");
                Console.WriteLine($"Manufacturer country: {manufacturer.countryName}");

                Warehouse warehouse = warehouses.Find(obj => obj.id == prod.warehouseId);
                Console.WriteLine($"Warehouse name: {warehouse.name}");
                Console.WriteLine($"Warehouse id: {warehouse.id}");
                Console.WriteLine($"Warehouse address: {warehouse.address.countryName}/{warehouse.address.cityName}/{warehouse.address.streetName}/{warehouse.address.houseNumber}");

                Supply supply = supplies.Find(obj => obj.id == prod.supplyId);
                Console.WriteLine($"Supply id: {supply.id}");
                Console.WriteLine($"Supply description: {supply.description}");
                Console.WriteLine($"Supply date: {supply.date}");

                Console.WriteLine("-----------------------------------------------");
            }
        }

        /// <summary>
        /// Writes all information about all products to the xml file from JSON files.
        /// </summary>
        public void WriteFullDescription()
        {
            XDocument xdoc = new XDocument();
            XElement rootElem = new XElement("products");

            foreach (Product prod in this.products)
            {
                XElement product = new XElement("product");
                XAttribute productNameAttr = new XAttribute("name", prod.name);
                XElement productIdElem = new XElement("id", prod.id);
                XElement amountElem = new XElement("amount", prod.amount);
                XElement productionDateElem = new XElement("productionDate", prod.productionDate);

                Manufacturer manufacturer = manufacturers.Find(obj => obj.id == prod.manufacturerId);
                XElement manufacturerElem = new XElement("manufacturer");
                XAttribute manufacturerNameAttr = new XAttribute("name", manufacturer.name);
                XElement manufacturerIdElem = new XElement("id", manufacturer.id);
                XElement manufacturerCountryElem = new XElement("country", manufacturer.countryName);
                manufacturerElem.Add(manufacturerNameAttr);
                manufacturerElem.Add(manufacturerIdElem);
                manufacturerElem.Add(manufacturerCountryElem);

                Warehouse warehouse = warehouses.Find(obj => obj.id == prod.warehouseId);
                XElement warehouseElem = new XElement("warehouse");
                XAttribute warehouseNameAttr = new XAttribute("name", warehouse.name);
                XElement warehouseIdElem = new XElement("id", warehouse.id);
                XElement warehouseAddressElem = new XElement("address");
                XElement warehouseAddressCountry = new XElement("countryName", warehouse.address.countryName);
                XElement warehouseAddressCity = new XElement("cityName", warehouse.address.cityName);
                XElement warehouseAddressStreet = new XElement("streetName", warehouse.address.streetName);
                XElement warehouseAddressHouse = new XElement("houseNumber", warehouse.address.houseNumber);
                warehouseAddressElem.Add(warehouseAddressCountry);
                warehouseAddressElem.Add(warehouseAddressCity);
                warehouseAddressElem.Add(warehouseAddressStreet);
                warehouseAddressElem.Add(warehouseAddressHouse);
                warehouseElem.Add(warehouseNameAttr);
                warehouseElem.Add(warehouseIdElem);
                warehouseElem.Add(warehouseAddressElem);

                Supply supply = supplies.Find(obj => obj.id == prod.supplyId);
                XElement supplyElem = new XElement("supply");
                XElement supplyIdElem = new XElement("id", supply.id);
                XElement supplyDescriptionElem = new XElement("description", supply.description);
                XElement supplyDateElem = new XElement("date", supply.date);
                supplyElem.Add(supplyIdElem);
                supplyElem.Add(supplyDescriptionElem);
                supplyElem.Add(supplyDateElem);

                product.Add(productNameAttr);
                product.Add(productIdElem);
                product.Add(amountElem);
                product.Add(productionDateElem);
                product.Add(manufacturerElem);
                product.Add(warehouseElem);
                product.Add(supplyElem);

                rootElem.Add(product);
            }

            xdoc.Add(rootElem);

            xdoc.Save(@"../../DataBase/products.xml");
        }
    }
}

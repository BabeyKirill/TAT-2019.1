using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

using System.Xml.Linq;

namespace DEV_10
{
    class Shop
    {
        /// <summary>
        /// delegate responsible for changing lists of objects
        /// </summary>
        public delegate void ShopStateHandler();
        public event ShopStateHandler ProductsListChanged;
        public event ShopStateHandler WarehousesListChanged;
        public event ShopStateHandler ManufacturersListChanged;
        public event ShopStateHandler SuppliesListChanged;
        public event ShopStateHandler AddressesListChanged;

        public List<Product> products { get; private set; }
        public List<Supply> supplies { get; private set; }
        public List<Address> addresses { get; private set; }
        public List<Manufacturer> manufacturers { get; private set; }
        public List<Warehouse> warehouses { get; private set; }

        /// <summary>
        /// initializing lists of objects using JSON files
        /// </summary>
        public void InitializeWithJson()
        {
            if (File.Exists(@"../../DataBase/products.json"))
            {
                string productsJson = File.ReadAllText(@"../../DataBase/products.json");
                this.products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
            }

            if (File.Exists(@"../../DataBase/supplies.json"))
            {
                string suppliesJson = File.ReadAllText(@"../../DataBase/supplies.json");
                this.supplies = JsonConvert.DeserializeObject<List<Supply>>(suppliesJson);
            }

            if (File.Exists(@"../../DataBase/addresses.json"))
            {
                string addressesJson = File.ReadAllText(@"../../DataBase/addresses.json");
                this.addresses = JsonConvert.DeserializeObject<List<Address>>(addressesJson);
            }

            if (File.Exists(@"../../DataBase/manufacturers.json"))
            {
                string manufacturersJson = File.ReadAllText(@"../../DataBase/manufacturers.json");
                this.manufacturers = JsonConvert.DeserializeObject<List<Manufacturer>>(manufacturersJson);
            }

            if (File.Exists(@"../../DataBase/warehouses.json"))
            {
                string warehousesJson = File.ReadAllText(@"../../DataBase/warehouses.json");
                this.warehouses = JsonConvert.DeserializeObject<List<Warehouse>>(warehousesJson);
            }
        }

        /// <summary>
        /// adds Product object to list of products
        /// </summary>
        public void AddProduct(Product newProduct)
        {
            if (newProduct.Id != null)
            {
                if (products.FindIndex(obj => obj.Id == newProduct.Id) < 0)
                {
                    products.Add(newProduct);
                    ProductsListChanged();
                }
            }
        }

        /// <summary>
        /// Removes Product object from list of products
        /// </summary>
        public void DeleteProduct(string productId)
        {
            int productIndex = products.FindIndex(obj => obj.Id == productId);

            if (productIndex >= 0)
            {
                products.RemoveAt(productIndex);
                ProductsListChanged();
            }
        }

        /// <summary>
        /// Changes warehouse WarehouseAddress to a new one.
        /// </summary>
        public void ChangeWarehouseAddress(string warehouseId, Address newAddress)
        {
            if (newAddress.Id != null)
            {
                int Index = warehouses.FindIndex(obj => obj.Id == warehouseId);

                if (Index >= 0)
                {
                    string oldAddressId = warehouses[Index].WarehouseAddress.Id;
                    warehouses[Index].WarehouseAddress = newAddress;
                    WarehousesListChanged();
                }
            }
        }

        /// <summary>
        /// adds Warehouse object to list of warehouses
        /// </summary>
        public void AddWarehouse(Warehouse newWarehouse)
        {
            if (newWarehouse.Id != null)
            {
                if (warehouses.FindIndex(obj => obj.Id == newWarehouse.Id) < 0)
                {
                    warehouses.Add(newWarehouse);
                    WarehousesListChanged();
                }
            }
        }

        /// <summary>
        /// Removes Warehouse object from list of warehouses
        /// </summary>
        public void DeleteWarehouse(string warehouseId)
        {
            int warehouseIndex = warehouses.FindIndex(obj => obj.Id == warehouseId);

            if (warehouseIndex >= 0)
            {
                warehouses.RemoveAt(warehouseIndex);
                WarehousesListChanged();
            }      
        }

        /// <summary>
        /// Adds Manufacturer object to list of warehouses
        /// </summary>
        public void AddManufacturer(Manufacturer newManufacturer)
        {
            if (newManufacturer.Id != null)
            {
                if (manufacturers.FindIndex(obj => obj.Id == newManufacturer.Id) < 0)
                {
                    manufacturers.Add(newManufacturer);
                    ManufacturersListChanged();
                }
            }
        }

        /// <summary>
        /// Removes Manufacturer object from list of warehouses
        /// </summary>
        public void DeleteManufacturer(string manufacturerId)
        {
            int manufacturerIndex = manufacturers.FindIndex(obj => obj.Id == manufacturerId);

            if (manufacturerIndex >= 0)
            {
                warehouses.RemoveAt(manufacturerIndex);
                ManufacturersListChanged();
            }
        }

        /// <summary>
        /// adds Supply object to list of warehouses
        /// </summary>
        public void AddSupply(Supply newSupply)
        {
            if (newSupply.Id != null)
            {
                if (supplies.FindIndex(obj => obj.Id == newSupply.Id) < 0)
                {
                    supplies.Add(newSupply);
                    SuppliesListChanged();
                }
            }
        }

        /// <summary>
        /// Removes Supply object from list of warehouses
        /// </summary>
        public void DeleteSupply(string supplyId)
        {
            int supplyIndex = supplies.FindIndex(obj => obj.Id == supplyId);

            if (supplyIndex >= 0)
            {
                warehouses.RemoveAt(supplyIndex);
                SuppliesListChanged();
            }
        }

        /// <summary>
        /// adds Address object to list of warehouses
        /// </summary>
        public void AddAddress(Address newAddress)
        {
            if (newAddress.Id != null)
            {
                if (addresses.FindIndex(obj => obj.Id == newAddress.Id) < 0)
                {
                    addresses.Add(newAddress);
                    AddressesListChanged();
                }
            }
        }

        /// <summary>
        /// Removes Address object from list of warehouses
        /// </summary>
        public void DeleteAddress(string addressId)
        {
            int addressIndex = addresses.FindIndex(obj => obj.Id == addressId);

            if (addressIndex >= 0)
            {
                addresses.RemoveAt(addressIndex);
                AddressesListChanged();
            }
        }

        /// <summary>
        /// Changes the address with the specified Id to another Address
        /// </summary>
        public void ChangeAddress(string addressId, Address newAddress)
        {
            if (newAddress.Id != null)
            {
                int addressIndex = addresses.FindIndex(obj => obj.Id == addressId);

                if (addressIndex >= 0)
                {
                    addresses[addressIndex] = newAddress;
                    AddressesListChanged();
                }
            }
        }

        /// <summary>
        /// Writes all information about all products to the console from shop object lists
        /// </summary>
        public void ShowFullDescription()
        {
            foreach (Product prod in this.products)
            {
                Console.WriteLine($"Product Name: {prod.Name}");
                Console.WriteLine($"Id: {prod.Id}");
                Console.WriteLine($"Amount: {prod.Amount}");
                Console.WriteLine($"Production Date: {prod.ProductionDate}");

                Manufacturer manufacturer = manufacturers.Find(obj => obj.Id == prod.ManufacturerId);
                Console.WriteLine($"Manufacturer Name: {manufacturer.Name}");
                Console.WriteLine($"Manufacturer Id: {manufacturer.Id}");
                Console.WriteLine($"Manufacturer country: {manufacturer.CountryName}");

                Warehouse warehouse = warehouses.Find(obj => obj.Id == prod.WarehouseId);
                Console.WriteLine($"Warehouse Name: {warehouse.Name}");
                Console.WriteLine($"Warehouse Id: {warehouse.Id}");
                Console.WriteLine($"Warehouse WarehouseAddress: {warehouse.WarehouseAddress.CountryName}/{warehouse.WarehouseAddress.CityName}/{warehouse.WarehouseAddress.StreetName}/{warehouse.WarehouseAddress.HouseNumber}");

                Supply supply = supplies.Find(obj => obj.Id == prod.SupplyId);
                Console.WriteLine($"Supply Id: {supply.Id}");
                Console.WriteLine($"Supply Description: {supply.Description}");
                Console.WriteLine($"Supply Date: {supply.Date}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        /// <summary>
        /// Writes all information about all products to the xml file from shop object lists
        /// </summary>
        public void WriteFullDescription()
        {
            XDocument xdoc = new XDocument();
            XElement rootElem = new XElement("products");

            foreach (Product prod in this.products)
            {
                XElement product = new XElement("product");
                XAttribute productNameAttr = new XAttribute("Name", prod.Name);
                XElement productIdElem = new XElement("Id", prod.Id);
                XElement amountElem = new XElement("Amount", prod.Amount);
                XElement productionDateElem = new XElement("ProductionDate", prod.ProductionDate);

                Manufacturer manufacturer = manufacturers.Find(obj => obj.Id == prod.ManufacturerId);
                XElement manufacturerElem = new XElement("manufacturer");
                XAttribute manufacturerNameAttr = new XAttribute("Name", manufacturer.Name);
                XElement manufacturerIdElem = new XElement("Id", manufacturer.Id);
                XElement manufacturerCountryElem = new XElement("country", manufacturer.CountryName);
                manufacturerElem.Add(manufacturerNameAttr);
                manufacturerElem.Add(manufacturerIdElem);
                manufacturerElem.Add(manufacturerCountryElem);

                Warehouse warehouse = warehouses.Find(obj => obj.Id == prod.WarehouseId);
                XElement warehouseElem = new XElement("warehouse");
                XAttribute warehouseNameAttr = new XAttribute("Name", warehouse.Name);
                XElement warehouseIdElem = new XElement("Id", warehouse.Id);
                XElement warehouseAddressElem = new XElement("WarehouseAddress");
                XElement warehouseAddressCountry = new XElement("CountryName", warehouse.WarehouseAddress.CountryName);
                XElement warehouseAddressCity = new XElement("CityName", warehouse.WarehouseAddress.CityName);
                XElement warehouseAddressStreet = new XElement("StreetName", warehouse.WarehouseAddress.StreetName);
                XElement warehouseAddressHouse = new XElement("HouseNumber", warehouse.WarehouseAddress.HouseNumber);
                warehouseAddressElem.Add(warehouseAddressCountry);
                warehouseAddressElem.Add(warehouseAddressCity);
                warehouseAddressElem.Add(warehouseAddressStreet);
                warehouseAddressElem.Add(warehouseAddressHouse);
                warehouseElem.Add(warehouseNameAttr);
                warehouseElem.Add(warehouseIdElem);
                warehouseElem.Add(warehouseAddressElem);

                Supply supply = supplies.Find(obj => obj.Id == prod.SupplyId);
                XElement supplyElem = new XElement("supply");
                XElement supplyIdElem = new XElement("Id", supply.Id);
                XElement supplyDescriptionElem = new XElement("Description", supply.Description);
                XElement supplyDateElem = new XElement("Date", supply.Date);
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

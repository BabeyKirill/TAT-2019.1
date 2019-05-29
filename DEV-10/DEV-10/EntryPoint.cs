namespace DEV_10
{
    class EntryPoint
    {
        //This program implements store for managing products
        static void Main(string[] args)
        {
            Shop myShop = new Shop();
            ShopEventHandler shopHandler= new ShopEventHandler(myShop);

            myShop.ProductsListChanged += shopHandler.UpdateProductsJson;
            myShop.WarehousesListChanged += shopHandler.UpdateWarehousesJson;
            myShop.ManufacturersListChanged += shopHandler.UpdateManufacturersJson;
            myShop.SuppliesListChanged += shopHandler.UpdateSuppliesJson;
            myShop.AddressesListChanged += shopHandler.UpdateAddressesJson;

            myShop.InitializeWithJson();

            myShop.ShowFullDescription();

            myShop.WriteFullDescription();

            Address myAddress1 = new Address()
            {
                Id = "my-WarehouseAddress",
                CityName = "myCity",
                StreetName = "myStreet",
                HouseNumber = "228",
                CountryName = "myCountry"
            };

            myShop.ChangeWarehouseAddress("warehouse-2", myAddress1);

            Address myAddress2 = new Address()
            {
                Id = "changed-address",
                CityName = "changed_City",
                StreetName = "changed_Street",
                HouseNumber = "1488",
                CountryName = "changed_Country"
            };

            myShop.ChangeAddress("address-4", myAddress2);

            Product myNewProduct = new Product()
            {
                Id = "product-10",
                Name = "myNewProduct",
                Amount = "100500",
                ManufacturerId = "manufacturer-3",
                WarehouseId = "warehouse-2",
                SupplyId = "supply-10",
                ProductionDate = "05.29.2019"
            };

            myShop.AddProduct(myNewProduct);            
        }       
    }
}

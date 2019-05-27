namespace DEV_10
{
    class EntryPoint
    {
        //This program implements store based on JSONs for managing products
        static void Main(string[] args)
        {
            /*
            // Creating test Jsons
            JsonsForTests.CreateAllJsons();
            */

            Shop myShop = new Shop();
            myShop.ShowFullDescription();
            myShop.WriteFullDescription();

            Address myAddress = new Address()
            {
                id = "my-address",
                cityName = "myCity",
                streetName = "myStreet",
                houseNumber = "228",
                countryName = "myCountry"
            };

            //After these changes, the files should be automatically regenerated.
            myShop.ChangeWarehouseAddress("Warehouse2", myAddress);

            Product myProduct = new Product()
            {
                id = "product-8080",
                name = "myProduct",
                amount = "100500",
                manufacturerId = "manufacturer-3",
                warehouseId = "warehouse-2",
                supplyId = "supply-7",
                productionDate = "05.20.2019"
            };

            myShop.AddProduct(myProduct);
            myShop.DeleteProduct("Product1");

            myShop.products[0].name = "megaProduct";
            myShop.warehouses[0].name = "megaWarehouse";
            myShop.warehouses[0].address.cityName = "megaCity";
        }       
    }
}

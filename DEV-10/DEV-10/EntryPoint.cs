namespace DEV_10
{
    class EntryPoint
    {
        //This program implements store based on JSONs for managing products
        static void Main(string[] args)
        {
            // Creating test Jsons
            JsonsForTests.CreateAllJsons();

            Shop myShop = new Shop();
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
        }       
    }
}

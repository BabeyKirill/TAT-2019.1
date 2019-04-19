using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DEV_7
{
    /// <summary>
    /// Class receiver
    /// </summary>
    class CarList
    {
        private static CarList instance;
        public string xmlFileName { get; set; }
        protected XDocument xDoc;

        /// <summary>
        /// Constructor for receiver class
        /// </summary>
        /// <param name="xmlFileName">The name of the xml file with which it will work</param>
        protected CarList(string xmlFileName)
        {
            this.xmlFileName = xmlFileName;

            try
            {
                xDoc = XDocument.Load($"../../{xmlFileName}.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        /// <summary>
        /// SingleTone pattern, only one object of class will exist
        /// </summary>
        public static CarList GetInstance(string xmlFileName)
        {
            if (instance == null)
                instance = new CarList(xmlFileName);

            return instance;
        }

        /// <summary>
        /// This operation returns the number of brands from the xml file.
        /// </summary>
        public int GetCountTypes()
        {
            List<string> BrandFields = new List<string>();
            var items = from xe in xDoc.Element("cars").Elements("car")
                        select xe.Element("brand").Value;

            foreach (var item in items)
            {
                BrandFields.Add(item);
            }

            List<string> ListOfBrands = new List<string>(BrandFields.Distinct());

            return ListOfBrands.Count;
        }

        /// <summary>
        /// This operation returns the number of all cars from the xml file.
        /// </summary>
        public int GetCountAll()
        {
            int TotalNumber = 0;
            var items = from xe in xDoc.Element("cars").Elements("car")
                        select xe.Element("number").Value;

            foreach (var item in items)
            {
                TotalNumber += Int32.Parse(item);
            }

            return TotalNumber;
        }

        /// <summary>
        /// This operation returns the average price of all cars from the xml file.
        /// </summary>
        public double GetAveragePrice()
        {
            int TotalNumber = GetCountAll();
            double TotalCost = 0;

            var items = from xe in xDoc.Element("cars").Elements("car")
                        select Double.Parse(xe.Element("price").Value) * Int32.Parse(xe.Element("number").Value);

            foreach (var item in items)
            {
                TotalCost += item;
            }

            return TotalCost / TotalNumber;
        }

        /// <summary>
        /// This operation returns the average price of cars of concrete brand from the xml file.
        /// </summary>
        public double GetAveragePriceType(string OperationName)
        {
            string BrandName = OperationName.Substring(("average price car ").Length);
            int TotalNumber = 0;
            double TotalCost = 0;

            var costs = from xe in xDoc.Element("cars").Elements("car")
                        where xe.Element("brand").Value == BrandName
                        select Double.Parse(xe.Element("price").Value) * Int32.Parse(xe.Element("number").Value);

            var numbers = from xe in xDoc.Element("cars").Elements("car")
                          where xe.Element("brand").Value == BrandName
                          select xe.Element("number").Value;

            foreach (var item in numbers)
            {
                TotalNumber += Int32.Parse(item);
            }

            foreach (var item in costs)
            {
                TotalCost += item;
            }

            return TotalCost / TotalNumber;
        }
    }
}

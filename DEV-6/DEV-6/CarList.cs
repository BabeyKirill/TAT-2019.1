using System;
using System.Collections.Generic;
using System.Xml;

namespace DEV_6
{
    /// <summary>
    /// Class receiver
    /// </summary>
    class CarList
    {
        public string xmlFileName { get; set; }
        protected XmlDocument xDoc = new XmlDocument();

        /// <summary>
        /// Constructor for receiver class
        /// </summary>
        /// <param name="xmlFileName">The name of the xml file with which it will work</param>
        public CarList(string xmlFileName)
        {
            this.xmlFileName = xmlFileName;

            try
            {
                xDoc.Load($"../../{xmlFileName}.xml");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        /// <summary>
        /// This operation returns the number of brands from the xml file.
        /// </summary>
        public int GetCountTypes()
        {
            XmlElement xRoot = xDoc.DocumentElement;
            List<string> ListOfBrands = new List<string>();

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "brand" && !ListOfBrands.Contains(childnode.InnerText))
                    {
                        ListOfBrands.Add(childnode.InnerText);
                    }
                }
            }

            return ListOfBrands.Count;
        }

        /// <summary>
        /// This operation returns the number of cars from the xml file.
        /// </summary>
        public int GetCountAll()
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int TotalNumber = 0;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "number")
                    {
                        TotalNumber += Int32.Parse(childnode.InnerText);
                    }
                }
            }

            return TotalNumber;
        }

        /// <summary>
        /// This operation returns the average price of cars from the xml file.
        /// </summary>
        public double GetAveragePrice()
        {
            XmlElement xRoot = xDoc.DocumentElement;
            int TotalNumber = 0;
            double TotalCost = 0;
            double CostOfCar = 0;
            int NumberOfTheCars = 0;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "price")
                    {
                        CostOfCar = Double.Parse(childnode.InnerText);
                    }

                    if (childnode.Name == "number")
                    {
                        NumberOfTheCars = Int32.Parse(childnode.InnerText);
                        TotalNumber += Int32.Parse(childnode.InnerText);
                    }
                }
                TotalCost += CostOfCar * NumberOfTheCars;
            }

            return TotalCost / TotalNumber;
        }

        /// <summary>
        /// This operation returns the average price of cars of concrete brand from the xml file.
        /// </summary>
        public double GetAveragePriceType(string CommandName)
        {
            XmlElement xRoot = xDoc.DocumentElement;
            string BrandName = CommandName.Substring(("average price ").Length);
            int TotalNumber = 0;
            double TotalCost = 0;
            double CostOfCar = 0;
            int NumberOfTheCars = 0;

            foreach (XmlNode xnode in xRoot)
            {
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "brand" && childnode.InnerText == BrandName)
                    {
                        foreach (XmlNode _childnode in xnode.ChildNodes)
                        {
                            if (_childnode.Name == "price")
                            {
                                CostOfCar = Double.Parse(_childnode.InnerText);
                            }

                            if (_childnode.Name == "number")
                            {
                                NumberOfTheCars = Int32.Parse(_childnode.InnerText);
                                TotalNumber += Int32.Parse(_childnode.InnerText);
                            }
                        }
                        TotalCost += CostOfCar * NumberOfTheCars;
                    }
                }
            }

            return TotalCost / TotalNumber;
        }
    }
}

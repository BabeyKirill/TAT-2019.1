using CW_10.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace CW_10
{
    class EntryPoint
    {
        static void Main(string[] args)
        {          
            Console.Write("Enter the file name and browser: ");
            string str = Console.ReadLine();

            DriverFactory driverFactory = new DriverFactory();
            IWebDriver driver = driverFactory.GetDriver(str);
            driver.Url = "https://kurs.onliner.by/";
            OnlinerKursPage page = new OnlinerKursPage(driver);
            List<ExchangeRate> rates = new List<ExchangeRate>();
            page.LoadValues(rates);
            WriterFactory writerFatory = new WriterFactory();
            Writer writer = writerFatory.GetWriter(str);
            writer.WriteInFile(rates);
        }
    }
}

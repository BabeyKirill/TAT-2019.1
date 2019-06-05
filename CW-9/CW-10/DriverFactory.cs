using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Opera;

namespace CW_10
{
    class DriverFactory
    {
        public IWebDriver GetDriver(string str)
        {
            if(str.Contains(" Chrome"))
            {
                return new ChromeDriver();
            }
            else if(str.Contains(" Opera"))
            {
                return new OperaDriver();
            }
            else
            {
                return null;
            }
        }
    }
}

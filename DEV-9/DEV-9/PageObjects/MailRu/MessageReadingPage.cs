using OpenQA.Selenium;

namespace DEV_9.PageObjects.MailRu
{
    public class MessageReadingPage
    {
        private IWebDriver driver;

        public IWebElement MessageText => this.driver.FindElement(By.XPath("//div[@class='js-helper js-readmsg-msg']/div/div/div"), 10);

        public IWebElement ShowProfileButton => this.driver.FindElement(By.XPath("//i[@id='PH_user-email']"), 10);

        public IWebElement PersonalDataButton => this.driver.FindElement(By.XPath("//div[@class='x-ph__menu__dropdown_auth__links']/a[2]"), 10);

        public MessageReadingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PersonalDataPage OpenPersonalData()
        {
            this.ShowProfileButton.Click();

            this.PersonalDataButton.Click();

            return new PersonalDataPage(this.driver);
        }
    }
}
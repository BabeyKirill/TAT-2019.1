using OpenQA.Selenium;

namespace DEV_9.PageObjects.MailRu
{
    public class PersonalDataPage
    {
        private IWebDriver driver;

        public IWebElement NickNameBox => this.driver.FindElement(By.XPath("//input[@id='NickName']"), 10);

        public IWebElement SaveChangesButton => this.driver.FindElement(By.XPath("//div[@class='form__actions__inner']/button[@type='submit']"), 10);

        public IWebElement PersonalDataButton => this.driver.FindElement(By.XPath("//a[@data-name='userinfo']"), 10);

        public PersonalDataPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PersonalDataPage ChangeNickName(string NickName)
        {
            this.NickNameBox.Clear();
            this.NickNameBox.SendKeys(NickName);

            this.SaveChangesButton.Click();

            this.PersonalDataButton.Click();

            return this;
        }
    }
}
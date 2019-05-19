using OpenQA.Selenium;

namespace DEV_9.PageObjects.MailRu
{
    /// <summary>
    /// Expected driver.Url = "https://mail.ru"
    /// </summary>
    public class MailRuHomePage
    {
        private IWebDriver driver;

        public IWebElement LoginBox => this.driver.FindElement(By.XPath("//input[@id='mailbox:login']"), 10);

        public IWebElement PasswordBox => this.driver.FindElement(By.XPath("//input[@id='mailbox:password']"), 10);

        public IWebElement LoginButton => this.driver.FindElement(By.XPath("//label[@id='mailbox:submit']"), 10);

        public IWebElement LoginErrorMessage => this.driver.FindElement(By.XPath("//div[@class='mailbox__body']/div[@id='mailbox:error']"), 5);

        public MailRuHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public InboxPage Login(string Login, string Password)
        {
            this.LoginBox.SendKeys(Login);

            this.PasswordBox.SendKeys(Password);

            this.LoginButton.Click();

            return new InboxPage(this.driver);
        }
    }
}

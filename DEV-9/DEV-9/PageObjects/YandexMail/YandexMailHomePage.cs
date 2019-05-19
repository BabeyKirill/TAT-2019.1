using OpenQA.Selenium;

namespace DEV_9.PageObjects.YandexMail
{
    /// <summary>
    /// Expected driver.Url = "https://mail.yandex.ru"
    /// </summary>
    public class YandexMailHomePage
    {
        private IWebDriver driver;

        public IWebElement LoginButton => this.driver.FindElement(By.XPath("//div[@class='HeadBanner-ButtonsWrapper']/a[2]"), 10);

        public IWebElement LoginBox => this.driver.FindElement(By.XPath("//input[@id='passp-field-login']"), 10);

        //This "class" attribute is required to bypass the bug caused by the page animation.
        public IWebElement PasswordBox => this.driver.FindElement(By.XPath("//div[@class='passp-form-field  passp-form-field_focused']/div/input"), 10);

        public IWebElement SecondLoginButton => this.driver.FindElement(By.XPath("//div[@class='passp-button passp-sign-in-button']/button[1]"), 10);

        public YandexMailHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public InboxPage Login(string Login, string Password)
        {
            this.LoginButton.Click();

            this.LoginBox.SendKeys(Login);

            this.SecondLoginButton.Click();

            this.PasswordBox.SendKeys(Password);

            this.SecondLoginButton.Click();

            return new InboxPage(this.driver);
        }
    }
}

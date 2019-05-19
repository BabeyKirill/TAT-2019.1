using OpenQA.Selenium;

namespace DEV_9.PageObjects.YandexMail
{
    public class InboxPage
    {
        private IWebDriver driver;

        public IWebElement OpenLastReceivedMessageButton => this.driver.FindElement(By.XPath("//div[@class='ns-view-container-desc mail-MessagesList js-messages-list']/div[1]"), 10);

        public IWebElement SenderOfLastMessage => this.driver.FindElement(By.XPath("//div[@class='ns-view-container-desc mail-MessagesList js-messages-list']/div[1]//span[@class='mail-MessageSnippet-FromText']"), 10);

        public IWebElement ReadStateLabel => this.driver.FindElement(By.XPath("//span[@class='mail-MessageSnippet-Item mail-MessageSnippet-Item_body js-message-snippet-body']/span[1]"), 10);

        public InboxPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MessageReadingPage ReadLastMessage()
        {
            this.OpenLastReceivedMessageButton.Click();

            return new MessageReadingPage(this.driver);
        }
    }
}

using OpenQA.Selenium;

namespace DEV_9.PageObjects.YandexMail
{
    public class MessageReadingPage
    {
        private IWebDriver driver;

        public IWebElement MessageText => this.driver.FindElement(By.XPath("//div[@class='mail-Message-Body-Content']/div"), 10);

        public IWebElement AnswerButton => this.driver.FindElement(By.XPath("//div[@class='mail-QuickReply-Placeholder_text']/span[1]"), 10);

        public IWebElement AnswerTextBox => this.driver.FindElement(By.XPath("//div[@class='cke_contents cke_reset']/div[@role='textbox']"), 10);

        public IWebElement SendAnswerButton => this.driver.FindElement(By.XPath("//div[@class='mail-Compose-Field-Actions_left']/span/button"), 10);

        public MessageReadingPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public MessageReadingPage WriteAnswer(string AnswerText)
        {
            this.AnswerButton.Click();

            this.AnswerTextBox.SendKeys(AnswerText);

            this.SendAnswerButton.Click();

            return this;
        }
    }
}

using DEV_9.PageObjects.MailRu;
using DEV_9.PageObjects.YandexMail;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DEV_9.Tests
{
    /// <summary>
    /// These tests check mailboxes for sending and receiving messages.
    /// </summary>
    [TestFixture]
    public class MailReceivingTests
    {
        private IWebDriver YandexDriver;
        private IWebDriver MailRuDriver;
        private PageObjects.YandexMail.InboxPage YandexInboxPage;
        private MailRuHomePage MailRuPage;
        private string MailRuLogin = "babeyfakemail@mail.ru";
        private string MailRuPassword = "MegaPassword";
        private string Recipient = "BabeyFakeMail@yandex.ru";
        private string MessageText = "Mega Message";
        private string AnswerText = "Super nickname";

        /// <summary>
        /// Logging in to Mail.ru, sending messages to Yandex and logging into Yandex mail 
        /// </summary>
        [SetUp]
        public void SendMessageAndOpenInbox()
        {
            this.MailRuDriver = new ChromeDriver();
            this.MailRuDriver.Url = "https://mail.ru";
            this.MailRuPage = new MailRuHomePage(MailRuDriver);
            this.MailRuPage.Login(MailRuLogin, MailRuPassword).WriteNewMessage(Recipient, MessageText);

            this.YandexDriver = new ChromeDriver();
            this.YandexDriver.Url = "https://mail.yandex.ru";
            YandexMailHomePage YandexMailPage = new YandexMailHomePage(this.YandexDriver);
            this.YandexInboxPage = YandexMailPage.Login("BabeyFakeMail", "MegaPassword");
        }

        [Test]
        public void ReadStateLabelAndSenderTest()
        {
            if ("Отметить как прочитанное" == this.YandexInboxPage.ReadStateLabel.GetAttribute("title") && MailRuLogin == this.YandexInboxPage.SenderOfLastMessage.GetAttribute("title"))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ReceivedMessageTextTest()
        {
            var YandexReadMessagePage = this.YandexInboxPage.ReadLastMessage();

            Assert.AreEqual(MessageText, YandexReadMessagePage.MessageText.Text);
        }

        /// <summary>
        /// Reply with Yandex mail and setting the message text as the Mail.ru nickname 
        /// </summary>
        [Test]
        public void MailRuChangeNickNameTest()
        {
            this.MailRuDriver.Quit();

            var YandexReadMessagePage = this.YandexInboxPage.ReadLastMessage();

            YandexReadMessagePage.WriteAnswer(AnswerText);

            this.MailRuDriver = new ChromeDriver();
            this.MailRuDriver.Url = "https://mail.ru";
            this.MailRuPage = new MailRuHomePage(MailRuDriver);
            var MailRuReadMessagePage = this.MailRuPage.Login(MailRuLogin, MailRuPassword).ReadLastMessage();
            var NewReceivedNickName = MailRuReadMessagePage.MessageText.Text;

            PersonalDataPage MailRuPersonalDataPage = MailRuReadMessagePage.OpenPersonalData().ChangeNickName(NewReceivedNickName);

            Assert.AreEqual(AnswerText, MailRuPersonalDataPage.NickNameBox.GetAttribute("value"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            this.YandexDriver.Quit();
            this.MailRuDriver.Quit();
        }
    }
}

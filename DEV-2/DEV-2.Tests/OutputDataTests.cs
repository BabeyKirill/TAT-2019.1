using NUnit.Framework;

namespace DEV_2.Tests
{
    [TestFixture]
    public class OutputDataTests
    {
        [TestCase("молоко+", "малако")]
        [TestCase("МОЛОКО+", "малако")]
        [TestCase("ме+сто", "м'эста")]
        [TestCase("тря+пка", "тр'апка")]
        [TestCase("ёлка", "йолка")]
        [TestCase("ё+лка", "йолка")]
        [TestCase("вью+га", "в'йуга")]
        [TestCase("моё", "майо")]
        [TestCase("ска+зка", "скаска")]
        [TestCase("сде+лать", "зд'элат'")]
        [TestCase("зуб", "зуп")]
        [TestCase("го+лубь", "голуп'")]
        [TestCase("до+ждь", "дошт'")]
        public void GetTranscription_Test(string word, string resultPhoneme)
        {
            Transcriptor transcriptor = new Transcriptor();
            Assert.AreEqual(resultPhoneme, transcriptor.GetTranscription(word).ToString());
        }
    }
}

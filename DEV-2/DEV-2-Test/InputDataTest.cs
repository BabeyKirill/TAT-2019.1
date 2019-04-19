using NUnit.Framework;
using DEV_2;
using System;

namespace DEV_2_Test
{
    /// <summary>
    /// Summary description for CountLettersToWordTest
    /// </summary>
    [TestFixture]
    public class InputDataTest
    {
        [TestCase("f")]
        [TestCase("5+")]
        [TestCase("5vs")]
        [TestCase("мо+ло+ко")]
        public void IncorrectInputWord_Test(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new Transcriptor().GetTranscription(word)
             );
        }

        [TestCase(null)]
        public void NullWord_Test(string word)
        {
            Assert.Throws<NullReferenceException>
             (
                () => new Transcriptor().GetTranscription(word)
             );
        }

        [TestCase("молоко+")]
        [TestCase("ё+лка")]
        [TestCase("привет")]
        [TestCase("пра+вда")]
        public void Accent_Test(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new Transcriptor().GetTranscription(word)
             );
        }
    }
}

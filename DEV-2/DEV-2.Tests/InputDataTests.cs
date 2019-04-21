using NUnit.Framework;
using System;

namespace DEV_2.Tests
{
    [TestFixture]
    public class InputDataTest
    {
        [TestCase("apple+")]
        [TestCase("f")]
        [TestCase("5+")]
        [TestCase("5vs")]
        [TestCase("мо+ло+ко")]
        [TestCase("молоко")]
        [TestCase("+молоко")]
        [TestCase("ссср+")]
        [TestCase("ссср")]
        public void IncorrectInputWord_Test(string word)
        {
            Assert.Throws<ArgumentOutOfRangeException>
             (
                () => new Validator().ValidationCheck(word)
             );
        }

        [TestCase(null)]
        [TestCase("")]
        public void NullWord_Test(string word)
        {
            Assert.Throws<ArgumentNullException>
                (
                    () => new Validator().ValidationCheck(word)
                );
        }

        [TestCase("молоко+")]
        [TestCase("ё+лка")]
        [TestCase("ёлка")]
        [TestCase("пра+вда")]
        [TestCase("зуб")]
        [TestCase("МОЛОКО+")]
        [TestCase("Молоко+")]
        public void CorrectInputWord_Test(string word)
        {
            Assert.DoesNotThrow
             (
                () => new Validator().ValidationCheck(word)
             );
        }
    }
}

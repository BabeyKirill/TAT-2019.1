using System;
using System.Linq;

namespace DEV_2
{
    /// <summary>
    /// Input string Validator for Transcriptor class.
    /// </summary>
    public class Validator
    {
        private string EnabledSymbols = "ёйцукенгшщзхъфывапролджэячсмитьбю+";
        private string Vovels = "ёуеыаоэяию";
        private int NumberOfAccents = 0;
        private int NumberOfVovels = 0;

        /// <summary>
        /// Check the string on validation for Transcriptor.
        /// </summary>
        /// <param name="word">string to check"</param>
        public void ValidationCheck(string word)
        {
            if (word == null || word == "")
            {
                throw new ArgumentNullException();
            }

            word = word.ToLower();

            foreach (char letter in word)
            {
                if (EnabledSymbols.Contains(letter) == false)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            foreach (char letter in word)
            {
                if (letter == '+')
                {
                    NumberOfAccents++;
                }
                if (Vovels.Contains(letter))
                {
                    NumberOfVovels++;
                }
            }

            if (NumberOfAccents == 0 && !word.Contains('ё') && NumberOfVovels != 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (NumberOfAccents > 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (word[0] == '+')
            {
                throw new ArgumentOutOfRangeException();
            }

            for (int i = 1; i < word.Length; i++)
            {
                if (word[i] == '+' && !Vovels.Contains(word[i - 1]))
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}

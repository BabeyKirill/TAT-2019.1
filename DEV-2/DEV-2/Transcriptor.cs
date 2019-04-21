using System.Linq;
using System.Text;

namespace DEV_2
{
    /// <summary>
    /// This class can convert words to transcription
    /// </summary>
    public class Transcriptor
    {
        private string vowel_rule = "уаоиьъы";
        private string consonant_rule1 = "бвгджзй";
        private string consonant_rule2 = "пфктшсхцчщ";
        private string paired_consonants = "бпвфгкдтжшзс";

        /// <summary>
        /// Convert the string to transcription.
        /// </summary>
        /// <param name="str">transcription to convert"</param>
        public string GetTranscription(string str)
        {
            new Validator().ValidationCheck(str);

            str = str.ToLower();

            StringBuilder transcription = new StringBuilder(str);

            VovelReplace(transcription);

            PairedConsonantReplace(transcription);

            return transcription.ToString();
        }

        /// <summary>
        /// method which replaces vowels according to phonetic rules.
        /// </summary>
        /// <param name="transcription">future transcription"</param>
        private void VovelReplace(StringBuilder transcription)
        {
            string UnchangedWord = transcription.ToString();
            int position = 0;
            int str_position = 0;

            foreach (char letter in UnchangedWord)
            {

                if (str_position + 1 < UnchangedWord.Length)
                    if (letter == 'о' && UnchangedWord[str_position + 1] == '+')
                    {
                        position++;
                        str_position++;
                        continue;
                    }

                if (letter == 'о')
                {
                    transcription.Remove(position, 1);
                    transcription.Insert(position, "а");
                    position++;
                    str_position++;
                    continue;
                }

                if (letter == '+')
                {
                    transcription.Remove(position, 1);
                    str_position++;
                    continue;
                }

                if (letter == 'ь')
                {
                    transcription.Remove(position, 1);
                    transcription.Insert(position, "'");
                    position++;
                    str_position++;
                    continue;
                }

                switch (letter)
                {
                    case 'ё':
                        if (str_position == 0)
                        {
                            transcription.Remove(position, 1);
                            transcription.Insert(position, "йо");
                            position = position + 2;
                            str_position++;
                        }
                        else
                        {
                            if (vowel_rule.Contains(UnchangedWord[str_position - 1]))
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "йо");
                                position = position + 2;
                                str_position++;
                            }
                            else
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "'о");
                                position = position + 2;
                                str_position++;
                            }
                        }
                        continue;
                    case 'е':
                        if (str_position == 0)
                        {
                            transcription.Remove(position, 1);
                            transcription.Insert(position, "йэ");
                            position = position + 2;
                            str_position++;
                        }
                        else
                        {
                            if (vowel_rule.Contains(UnchangedWord[str_position - 1]))
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "йэ");
                                position = position + 2;
                                str_position++;
                            }
                            else
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "'э");
                                position = position + 2;
                                str_position++;
                            }
                        }
                        continue;
                    case 'ю':
                        if (str_position == 0)
                        {
                            transcription.Remove(position, 1);
                            transcription.Insert(position, "йу");
                            position = position + 2;
                            str_position++;
                        }
                        else
                        {
                            if (vowel_rule.Contains(UnchangedWord[str_position - 1]))
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "йу");
                                position = position + 2;
                                str_position++;
                            }
                            else
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "'у");
                                position = position + 2;
                                str_position++;
                            }
                        }
                        continue;
                    case 'я':
                        if (str_position == 0)
                        {
                            transcription.Remove(position, 1);
                            transcription.Insert(position, "йа");
                            position = position + 2;
                            str_position++;
                        }
                        else
                        {
                            if (vowel_rule.Contains(UnchangedWord[str_position - 1]))
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "йа");
                                position = position + 2;
                                str_position++;
                            }
                            else
                            {
                                transcription.Remove(position, 1);
                                transcription.Insert(position, "'а");
                                position = position + 2;
                                str_position++;
                            }
                        }
                        continue;
                }

                position++;
                str_position++;
            }
        }

        /// <summary>
        /// replaces the deaf consonant on her paired voiced consonant
        /// </summary>
        /// <param name="word">word"</param>
        /// /// <param name="PositionOfLetter">position of consonant letter in word"</param>
        private void DeafToVoiced(StringBuilder word, int PositionOfLetter)
        {
            word.Insert(PositionOfLetter, paired_consonants[paired_consonants.IndexOf(word[PositionOfLetter]) - 1]);
            word.Remove(PositionOfLetter + 1, 1);
        }

        /// <summary>
        /// replaces the voiced consonant on her paired deaf consonant
        /// </summary>
        /// <param name="word">word"</param>
        /// /// <param name="PositionOfLetter">position of consonant letter in word"</param>
        private void VoicedToDeaf(StringBuilder word, int PositionOfLetter)
        {
            word.Insert(PositionOfLetter, paired_consonants[paired_consonants.IndexOf(word[PositionOfLetter]) + 1]);
            word.Remove(PositionOfLetter + 1, 1);
        }

        /// <summary>
        /// method which replaces consonants according to phonetic rules.
        /// </summary>
        /// <param name="transcription">future transcription"</param>
        private void PairedConsonantReplace(StringBuilder transcription)
        {
            if (consonant_rule1.Contains(transcription[transcription.Length - 1]))
            {
                VoicedToDeaf(transcription, transcription.Length - 1);
            }
            if (transcription[transcription.Length - 1] == 39 && consonant_rule1.Contains(transcription[transcription.Length - 2]))
            {
                VoicedToDeaf(transcription, transcription.Length - 2);
            }

            for (int i = transcription.Length - 2; i >= 0; i--)
            {
                if (transcription[i] != 39)
                {
                    if (paired_consonants.Contains(transcription[i]))
                    {
                        if (consonant_rule1.Contains(transcription[i]) && consonant_rule2.Contains(transcription[i + 1]))
                        {
                            VoicedToDeaf(transcription, i);
                            continue;
                        }
                        if (consonant_rule2.Contains(transcription[i]) && consonant_rule1.Contains(transcription[i + 1]))
                        {
                            DeafToVoiced(transcription, i);
                        }
                    }
                }
                else
                {
                    i = i--;
                    if (paired_consonants.Contains(transcription[i]))
                    {
                        if (consonant_rule1.Contains(transcription[i]) && consonant_rule2.Contains(transcription[i + 2]))
                        {
                            VoicedToDeaf(transcription, i);
                            continue;
                        }
                        if (consonant_rule2.Contains(transcription[i]) && consonant_rule1.Contains(transcription[i + 2]))
                        {
                            DeafToVoiced(transcription, i);
                        }
                    }
                }
            }
        }
    }
}

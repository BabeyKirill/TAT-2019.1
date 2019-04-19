using System.Linq;
using System.Text;

namespace DEV_2
{
    public class Transcriptor
    {
        private string vowel_rule = "уаоиьъы";
        private string consonant_rule1 = "бвгджзй";
        private string consonant_rule2 = "пфктшсхцчщ";
        private string paired_consonants = "бпвфгкдтжшзс";

        public string GetTranscription(string str)
        {
            StringBuilder transcription = new StringBuilder(str);

            VovelReplace(str, transcription);

            PairedConsonantReplace(transcription);

            return transcription.ToString();
        }

        private void VovelReplace(string str, StringBuilder transcription)
        {
            int position = 0;
            int str_position = 0;

            foreach (char letter in str)
            {

                if (str_position + 1 < str.Length)
                    if (letter == 'о' && str[str_position + 1] == '+')
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
                            if (vowel_rule.Contains(str[str_position - 1]))
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
                            if (vowel_rule.Contains(str[str_position - 1]))
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
                            if (vowel_rule.Contains(str[str_position - 1]))
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
                            if (vowel_rule.Contains(str[str_position - 1]))
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

        private void DeafToVoiced(StringBuilder word, int PositionOfLetter)
        {
            word.Insert(PositionOfLetter, paired_consonants[paired_consonants.IndexOf(word[PositionOfLetter]) - 1]);
            word.Remove(PositionOfLetter + 1, 1);
        }

        private void VoicedToDeaf(StringBuilder word, int PositionOfLetter)
        {
            word.Insert(PositionOfLetter, paired_consonants[paired_consonants.IndexOf(word[PositionOfLetter]) + 1]);
            word.Remove(PositionOfLetter + 1, 1);
        }

        private void PairedConsonantReplace(StringBuilder word)
        {
            if (consonant_rule1.Contains(word[word.Length - 1]))
            {
                VoicedToDeaf(word, word.Length - 1);
            }
            if (word[word.Length - 1] == 39 && consonant_rule1.Contains(word[word.Length - 2]))
            {
                VoicedToDeaf(word, word.Length - 2);
            }

            for (int i = word.Length - 2; i >= 0; i--)
            {
                if (word[i] != 39)
                {
                    if (paired_consonants.Contains(word[i]))
                    {
                        if (consonant_rule1.Contains(word[i]) && consonant_rule2.Contains(word[i + 1]))
                        {
                            VoicedToDeaf(word, i);
                            continue;
                        }
                        if (consonant_rule2.Contains(word[i]) && consonant_rule1.Contains(word[i + 1]))
                        {
                            DeafToVoiced(word, i);
                        }
                    }
                }
                else
                {
                    i = i--;
                    if (paired_consonants.Contains(word[i]))
                    {
                        if (consonant_rule1.Contains(word[i]) && consonant_rule2.Contains(word[i + 2]))
                        {
                            VoicedToDeaf(word, i);
                            continue;
                        }
                        if (consonant_rule2.Contains(word[i]) && consonant_rule1.Contains(word[i + 2]))
                        {
                            DeafToVoiced(word, i);
                        }
                    }
                }
            }
        }
    }
}
using System;

namespace DEV_2
{
    //This programm can convert words to transcriptions
    class EntryPoint
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                Transcriptor word = new Transcriptor();

                foreach (string str in args)
                {
                    string transcription = word.GetTranscription(str);

                    Console.Write(str + " -> ");
                    Console.WriteLine(transcription);
                }
            }
            else
            {
                Console.WriteLine("Command line is empty");
            }
        }
    }
}

using System;

namespace DEV_2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                foreach (string str in args)
                {
                    Console.Write(str + " -> ");

                    Transcriptor word = new Transcriptor();
                    string transcription = word.GetTranscription(str);

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

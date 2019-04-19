using System;

namespace DEV_1
{

    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            {
                string a = args[0];
                CheckMultipleChar str1 = new CheckMultipleChar(a);
                str1.SubstringFinder();
                if (args.Length > 1)
                    Console.WriteLine("There are more than 1 command line parameters, only the first one was checked.");
                str1.WriteAnswer();
            }
            catch when (args.Length == 0)
            {
                Console.WriteLine("Command line parameters is not set.");
            }
            catch when (args[0].Length == 1)
            {
                Console.WriteLine("The parameter must consist of at least 2 characters.");
            }
            catch
            {
                Console.WriteLine("Unexpected error");
            }
        }
    }

    class CheckMultipleChar                          //The class in which the string is analyzed for repeated characters in a row.
    {
        private string str;
        private string substrings;

        public CheckMultipleChar(string a)
        {
            if (a.Length > 1)
                str = a;
        }

        public void SubstringFinder()                       //Search for substrings without repeating
        {
            int n = 1;
            for (int i = 1; i < str.Length; i++)
            {
                if (str[i] != str[i - 1])                            
                {
                    for (int k = 0; k < n; k++)
                    {
                        for (int j = i - n + k; j <= i; j++)
                        {
                            substrings += str[j];            //Record all possible substrings without repeating in variable "substrings"
                        }
                        substrings += "\n";
                    }
                    n = n + 1;
                }
                else
                {
                    n = 1;
                }
            }
        }

        public void WriteAnswer()                            //Outputting results to the console
        {
            if (substrings != null)
            {
                Console.WriteLine("The string has the following substrings without multiple characters:");
                Console.WriteLine(substrings);
            }
            else
                Console.WriteLine("All characters in this parameter are the same.");
        }
    }
}

using System;

namespace CrackingCodeInterview.ArraysAndStrings
{
    public class Program
    {
        static void Main()
        {
            string userInput = "";

            while (userInput != "quit"
                && userInput != "exit")
            {
                userInput = Console.ReadLine().ToLowerInvariant();

                if (userInput == "usage"
                    || userInput == "help")
                {
                    Console.WriteLine("usage: <name> <command>");
                    Console.WriteLine("examples: isuniquestring run");
                    Console.WriteLine("\tisuniquestring explain");
                }
                else
                {
                    string[] parts = userInput.Split(" ");
                    string name = parts[0];
                    string command = parts[1];

                    FindExecutable(name, command)();
                }
            }
        }

        static Action FindExecutable(string name, string command)
        {
            Action run = null;
            Action explain = null;

            switch (name)
            {
                case "isuniquestring":
                    run = IsUniqueAscii.Run;
                    explain = IsUniqueAscii.Explain;
                break;

                default: throw new NotSupportedException(name + " is not a valid name.");
            }

            switch (command)
            {
                case "explain": return explain;
                case "run": return run;
                default: throw new NotSupportedException(name + " is not a valid name.");
            }
        }
    }
}
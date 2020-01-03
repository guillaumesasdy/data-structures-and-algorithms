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
            IExecutable executable = null;

            switch (name)
            {
                case "isuniquestring":
                    executable = new IsUniqueAscii();
                break;

                case "ispermutation":
                    executable = new IsPermutationAscii();
                break;

                case "oneaway":
                    executable = new OneAway();
                break;

                default: throw new NotSupportedException(name + " is not a valid name.");
            }

            switch (command)
            {
                case "explain": return executable.Explain;
                case "run": return executable.Run;
                default: throw new NotSupportedException(name + " is not a valid name.");
            }
        }
    }
}
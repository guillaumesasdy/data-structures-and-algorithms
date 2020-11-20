using System;
using MySolutions.CrackingCodeInterview.ArraysAndStrings;
using MySolutions.CrackingCodeInterview.LinkedList;
using MySolutions.CrackingCodeInterview.Queue;
using MySolutions.CrackingCodeInterview.SinglyLinkedList;
using MySolutions.CrackingCodeInterview.Stack;
using MySolutions.LeetCode;

namespace MySolutions.Common
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

                case "stringcompression":
                    executable = new StringCompression();
                    break;

                case "urlify":
                    executable = new URLify();
                    break;

                case "rotatematrix":
                    executable = new RotateMatrix();
                    break;

                case "countvowelspermutation":
                    executable = new CountVowelsPermutation();
                    break;

                case "singlylinkedlist":
                    executable = new SinglyLinkedList();
                    break;

                case "removedups":
                    executable = new RemoveDups();
                    break;

                case "returnkthlast":
                    executable = new ReturnKthLast();
                    break;

                case "deletemiddlenode":
                    executable = new DeleteMiddleNode();
                    break;

                case "partition":
                    executable = new Partition();
                    break;

                case "stack":
                    executable = new Stack<int>();
                    break;

                case "queue":
                    executable = new Queue<int>();
                    break;

                case "queuewithstacks":
                    executable = new QueueWithStacks<int>();
                    break;
                
                case "sumlists":
                    executable = new SumLists();
                    break;
                
                case "intersection":
                    executable = new Intersection();
                    break;
                
                case "detectloop":
                    executable = new LoopDetection();
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
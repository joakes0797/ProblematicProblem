using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    internal class Program
    {
        private static readonly string question1 = "Would you like to generate a random activity?  yes/no: ";
        private static readonly string question2 = "Would you like to see the current list of activities?  yes/no: ";
        private static readonly string question3 = "Would you like to add any activities to the list?  yes/no: ";
        private static readonly string question4 = "Would you like to add more? yes/no: ";
        private static readonly string question5 = "Would you like to grab a different activity?  yes/no: ";

        private static bool Decision(string question)
        {
            string result;
            do
            {
                Console.Write(question);
                result = Console.ReadLine().ToLower();
            } while (!(result == "yes" || result == "no"));
            return result == "yes" ? true : false;
        }

        private static void Exit()
        {
            Console.WriteLine("Enjoy your day.  Goodbye!");
        }

        private static void AddActivity()
        {
            Console.WriteLine("Enter what you would like to add: ");
            string userAddition = Console.ReadLine();
            Activities.Add(userAddition);
            Console.WriteLine("Adding activity...");
            foreach (var activity in Activities)
            {
                Console.WriteLine($"                {activity}");
                Thread.Sleep(250);
            }
            Console.WriteLine();
        }

        private static void DisplayRandom()
        {
            Console.Write("Choosing your random activity");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(". ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static List<string> Activities { get; private set; }

        private static string userName { get; set; }
        private static int age { get; set; }
        private static string randomActivity { get; set; }

        private static void UnderAge()
        {
            if (age < 21 && randomActivity == "Wine Tasting")
            {
                Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                Activities.Remove(randomActivity);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Ah, got it!  {userName}, your random activity is:  {randomActivity}");
                Activities.Remove(randomActivity);
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Activities = new List<string>
                { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

            Console.WriteLine("Hello, welcome to the random activity generator!");

            //make a method called Decision that takes a string as a parameter and returns a boolean as a result
            var answer1 = Decision(question1);    //Would you like to generate a random activity?  yes/no: 
            if (answer1)
            {
                Console.WriteLine();
            }
            else
            {
                goto end;
            }


            Console.Write("We are going to need your information first! What is your name?  ");
            string userName = Console.ReadLine();
            Console.WriteLine();
            Program.userName = userName;


            bool userAge;
            int age;
            do
            {
                Console.Write("What is your age?  ");
                userAge = int.TryParse(Console.ReadLine(), out age);

            } while (!userAge);
            Console.WriteLine();
            Program.age = age;


            var answer2 = Decision(question2);   //"Would you like to see the current list of activities?  yes/no: "
            if (answer2)
            {
                foreach (var activity in Activities)
                {
                    Console.WriteLine($"                {activity}");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
            }


            var answer3 = Decision(question3);   //"Would you like to add any activities to the list?  yes/no: "
            if (answer3)
            {
                AddActivity();                      // "Enter what you would like to add: "
            addMore:
                var answer4 = Decision(question4);    //"Would you like to add more? yes/no: "
                if (answer4)
                {
                    AddActivity();
                    goto addMore;
                }
                else
                {
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine();
            }

            Console.Write("Connecting to the database");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(". ");
                Thread.Sleep(250);
            }
            Console.WriteLine();
            Console.WriteLine();


            DisplayRandom();                   // "Choosing your random activity..."
            Program.randomActivity = Activities[new Random().Next(Activities.Count)];
            UnderAge();             //checks for under 21 && "Wine Tasting"

            differentActivity:
                var answer5 = Decision(question5);     //"Would you like to grab a different activity?  yes/no: "
                Console.WriteLine();

            if (answer5)
            {
                DisplayRandom();
                Program.randomActivity = Activities[new Random().Next(Activities.Count)];
                UnderAge();
                if (Activities.Count >= 1)
                {
                    goto differentActivity;
                }
            }
            else
            {
                goto end;
            }

            if (answer5)
            {
                Console.WriteLine("You've exhausted the list of activities.");
                goto end;
            }

            end:
                Exit();

        }
    }
}
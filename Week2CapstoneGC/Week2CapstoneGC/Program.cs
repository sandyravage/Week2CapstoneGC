using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneGC
{
    class Program
    {
        public static List<Task> Tasks = new List<Task>();

        static void Main()
        {
            Console.WriteLine("Welcome to the Task Manager!");
            MainMenu();
        }

        public static void MainMenu()//adds options to access all other methods
        {
            Console.Write("\nPlease enter a number corresponding to the following options:" +
                "\n1): List tasks" +
                "\n2): List tasks by team member" +
                "\n3): List tasks by due date" +
                "\n4): Add task" +
                "\n5): Delete task" +
                "\n6): Mark task complete" +
                "\n7): Edit task" +
                "\n8): Quit" +
                "\nEnter choice: ");
            string choice = Validator.MenuValidator(Console.ReadLine());
            switch (choice)
            {
                case "1":
                    EmptyListChecker();
                    Task.Lister(Tasks);
                    MainMenuCaller();
                    break;
                case "2":
                    EmptyListChecker();
                    Task.TeamMemberLister(Tasks, Validator.TeamMemberValidator(Tasks));
                    MainMenuCaller();
                    break;
                case "3":
                    EmptyListChecker();
                    Console.Write("\nPlease enter a valid due date: ");
                    Task.DueDateLister(Tasks, Validator.DueDateValidator(Tasks, Validator.DateValidator()));
                    MainMenuCaller();
                    break;
                case "4":
                    Console.Clear();
                    Tasks = Task.AddTask(Tasks);
                    MainMenuCaller();
                    break;
                case "5":
                    EmptyListChecker();
                    Tasks = Task.DeleteTask(Tasks);
                    MainMenuCaller();
                    break;
                case "6":
                    EmptyListChecker();
                    Tasks = Task.MarkTaskComplete(Tasks);
                    MainMenuCaller();
                    break;
                case "7":
                    EmptyListChecker();
                    Tasks = Task.EditTask(Tasks);
                    MainMenuCaller();
                    break;
                case "8":
                    Console.WriteLine("\nGoodbye");
                    System.Threading.Thread.Sleep(2000);
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        public static void MainMenuCaller()
        {
            Console.WriteLine("Press any key to continue. . .");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("\nWhat would you like to do now?");
            System.Threading.Thread.Sleep(1000);
            MainMenu();
        }
        public static void EmptyListChecker()
        {
            if(!Tasks.Any())
            {
                Console.WriteLine("\nNo tasks currently entered!\n");
                MainMenuCaller();
            }
        }
    }
}


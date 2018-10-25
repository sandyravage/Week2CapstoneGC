﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneGC
{
    class Validator
    {
        public static string YesNoChecker(string choice) //validates the many y/n decisions in this program
        {
            while (choice != "y" && choice != "n")
            {
                Console.Write("\nInvalid choice. Please enter \"y\" for yes or \"n\" for no: ");
                choice = Console.ReadLine();
            }
            return choice;
        }
        public static string MenuValidator(string input)
        {
            while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8")
            {
                Console.Write("\nInvalid choice. Please enter a decision 1 - 8: ");
                input = Console.ReadLine();
            }
            return input;
        }
        
        public static DateTime DateValidator()
        {
            DateTime datetime;
            string input = Console.ReadLine();
            while (!DateTime.TryParse(input,out datetime))
            {
                Console.Write("Invalid input. Please enter date in mm/dd/yyyy format: ");
                input = Console.ReadLine();
            }
            return datetime;
        }
        public static int DeleteValidator(List<Task> Tasks, string input)
        {
            int newinput;
            while(!int.TryParse(input, out newinput))
            {
                while (newinput > Tasks.Count - 1 || newinput < 1)
                {
                    Console.Write($"\nInvalid selection. Please choose a number between 1 and {Tasks.Count}: ");
                    input = Console.ReadLine();
                    break;
                }
            }
            return newinput - 1;
        }
        public static string TeamMemberValidator(List<Task> Tasks)
        {
            while (true)
            {
                Console.Write("\nPlease enter a team member name: ");
                string input = Console.ReadLine();
                foreach(Task task in Tasks)
                {
                    if(task.TeamMemberName().ToLower() == input.ToLower())
                    {
                        return input;
                    }
                }
                Console.Write("No team member found with that name.");
                continue;
            }
        }
        public static DateTime DueDateValidator(List<Task> Tasks, DateTime input)
        {
            while (true)
            {
                foreach (Task task in Tasks)
                {
                    if (task.DueDate() <= input)
                    {
                        return input;
                    }
                }
                Console.Write("No tasks found before this due date. Please try again: ");
                input = DateValidator();
                continue;
            }
        }
    }
}

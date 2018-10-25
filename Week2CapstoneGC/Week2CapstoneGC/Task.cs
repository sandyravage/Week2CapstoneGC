using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2CapstoneGC
{
    class Task
    {
        private static int instances = 0;
        private int instanceNumber;
        private string taskName;
        private string teamMemberName;
        private string description;
        private DateTime duedate;
        private bool isComplete;

        public string TeamMemberName()
        {
            return teamMemberName;
        }

        public DateTime DueDate()
        {
            return duedate;
        }

        public Task(string TaskName, string TeamMemberName, string Description, DateTime DueDate)
        {
            instances++;
            instanceNumber = instances;
            taskName = TaskName;
            teamMemberName = TeamMemberName;
            description = Description;
            duedate = DueDate;
            isComplete = false;
        }

        public static List<Task> AddTask(List<Task> Tasks)
        {
            List<Task> sublist = Tasks;
            Console.Write("\nADD TASK\n" +
                 "Task Name: ");
            string TaskName = Console.ReadLine();
            Console.Write("\nTeam Member Name: ");
            string TeamMemberName = Console.ReadLine();
            Console.Write("\nTask Description: ");
            string Description = Console.ReadLine();
            Console.Write("\nDue Date: ");
            DateTime DueDate = Validator.DateValidator();
            sublist.Add(new Task(TaskName, TeamMemberName, Description, DueDate));
            Console.WriteLine("\nTask Added!\n");
            return sublist;
        }

        public static List<Task> DeleteTask(List<Task> Tasks)
        {
                List<Task> sublist = Tasks;
                Console.Write("\nPlease enter the ID of the task you wish to delete: \n");
                foreach (Task task in Tasks)
                { 
                    Console.WriteLine($"{task.instanceNumber}: {task.taskName} entered by: {task.teamMemberName}");
                }
                Console.Write("\n\nEnter number: ");
                int num = Validator.DeleteValidator(Tasks, Console.ReadLine());
                sublist.RemoveAt(num);
                Console.WriteLine("\n\nTask Deleted!\n\n");
                return sublist;
            
        }

        public static void Lister(List<Task> Tasks)
        {
            Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", "Task Name", "Team Member Name", "Due Date", "Description", "Task Complete?");
            foreach (Task task in Tasks)
                {
                     Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", task.taskName, task.teamMemberName, task.duedate.ToString("MM/dd/yyyy"), task.description, task.isComplete);
                }
            Console.WriteLine("");
        }

        public static void TeamMemberLister(List<Task> Tasks, string input)
        {
            Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", "Task Name", "Team Member Name", "Due Date", "Description", "Task Complete?");
            foreach (Task task in Tasks)
                {
                    if (task.teamMemberName == input)
                    {
                    Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", task.taskName, task.teamMemberName, task.duedate.ToString("MM/dd/yyyy"), task.description, task.isComplete);
                }
            }
                Console.WriteLine("");
            
        }

        public static void DueDateLister(List<Task> Tasks, DateTime input)
        {
                Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", "Task Name", "Team Member Name", "Due Date", "Description", "Task Complete?");
            foreach (Task task in Tasks)
            {
                if (task.duedate <= input)
                {
                    Console.WriteLine("{0,-17} {1,-17} {2,-20} {3,-40} {4,5}", task.taskName, task.teamMemberName, task.duedate.ToString("MM/dd/yyyy"), task.description, task.isComplete);
                }
            }
            Console.WriteLine("");
            
        }

        public static List<Task> MarkTaskComplete(List<Task> Tasks)
        {
                List<Task> sublist = Tasks;
                Console.Write("\nPlease enter the ID of the task you wish to complete: \n");
                foreach (Task task in Tasks)
                {
                    Console.WriteLine($"{task.instanceNumber}: {task.taskName} entered by: {task.teamMemberName}");
                }
                Console.Write("\n\nEnter number: ");
                int num = 0;
                num = Validator.DeleteValidator(Tasks, Console.ReadLine()) + 1;
                foreach(Task task in Tasks)
                {
                    if(num == task.instanceNumber && task.isComplete == false)
                    {
                        task.isComplete = true;
                    }
                    else if(num == task.instanceNumber && task.isComplete == true)
                    {
                        Console.WriteLine("Task is already complete.");
                        return sublist;
                    }
                }
                Console.WriteLine("\n\nTask Completed!\n\n");
                return sublist;
            
        }
        public static List<Task> EditTask(List<Task> Tasks)
        {
           List<Task> sublist = Tasks;
                Console.Write("\nPlease enter the ID of the task you wish to edit: \n");
                foreach (Task task in Tasks)
                {
                    Console.WriteLine($"{task.instanceNumber}: {task.taskName} entered by: {task.teamMemberName}");
                }
                Console.Write("\n\nEnter number: ");
                int num = 0;
                num = Validator.DeleteValidator(Tasks, Console.ReadLine()) + 1;
                foreach (Task task in Tasks)
                {
                    if (num == task.instanceNumber)
                    {
                        Console.Write("Task Name: ");
                        string TaskName = Console.ReadLine();
                        Console.Write("\nTeam Member Name: ");
                        string TeamMemberName = Console.ReadLine();
                        Console.Write("\nTask Description: ");
                        string Description = Console.ReadLine();
                        Console.Write("\nDue Date: ");
                        DateTime DueDate = Validator.DateValidator();
                        task.taskName = TaskName;
                        task.teamMemberName = TeamMemberName;
                        task.description = Description;
                        task.duedate = DueDate;
                    }
                }
                Console.WriteLine("\n\nTask Edited!\n\n");
                return sublist;
            
        }
    }
}

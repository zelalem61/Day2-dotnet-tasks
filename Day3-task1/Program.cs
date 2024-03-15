using System;
using System.Collections.Generic;

public enum TaskCategory
{
    Personal,
    Work,
    Errands
}

public class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
}

public class TaskManager
{
    private List<Task> tasks = new List<Task>();

    public void AddTask(string name, string description, TaskCategory category, bool isCompleted)
    {
        tasks.Add(new Task { Name = name, Description = description, Category = category, IsCompleted = isCompleted });
    }

    public void DisplayTasks()
    {
        foreach (var task in tasks)
        {
            Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Choose an option:\n1. Add a task\n2. View tasks\n3. Exit");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                Console.WriteLine("Enter task name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Enter task description: ");
                string description = Console.ReadLine();

                Console.WriteLine("Enter task category (1 for Personal, 2 for Work, 3 for Errands): ");
                string categoryInput = Console.ReadLine();
                TaskCategory category;
                switch (categoryInput)
                {
                    case "1":
                        category = TaskCategory.Personal;
                        break;
                    case "2":
                        category = TaskCategory.Work;
                        break;
                    case "3":
                        category = TaskCategory.Errands;
                        break;
                    default:
                        Console.WriteLine("Invalid category. Please try again.");
                        continue;
                }

                Console.WriteLine("Is the task completed or not (insert 1 for completed, 2 for not completed): ");
                string bo = Console.ReadLine();
                bool isCompleted = bo == "1";

                taskManager.AddTask(name, description, category, isCompleted);
            }
            else if (userInput == "2")
            {
                taskManager.DisplayTasks();
            }
            else if (userInput == "3")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
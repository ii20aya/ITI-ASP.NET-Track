using System;
using System.Collections.Generic;

namespace Day04
{
    public class TaskManager
    {
     
        private IDictionary<int, TaskItem> _tasks = new Dictionary<int, TaskItem>();

     
        public TaskNotify? OnStatusChanged;

  
        public void AddTask(TaskItem task)
        {
            if (!_tasks.ContainsKey(task.Id))
            {
                _tasks.Add(task.Id, task);
                Console.WriteLine($"[System]: Task '{task.Title}' added successfully.");
            }
            else
            {
                Console.WriteLine($"[Error]: Task with ID {task.Id} already exists.");
            }
        }

    
        public void UpdateStatus(int id, TaskStatus newStatus)
        {
            if (_tasks.ContainsKey(id))
            {
                _tasks[id].Status = newStatus;

              
                OnStatusChanged?.Invoke($"Task '{_tasks[id].Title}' is now {newStatus}");
            }
            else
            {
                Console.WriteLine($"[Error]: Task ID {id} not found.");
            }
        }

  
        public List<TaskItem> FilterTasks(Predicate<TaskItem> criteria)
        {
            List<TaskItem> filteredList = new List<TaskItem>();

            foreach (var task in _tasks.Values)
            {
                if (criteria(task))
                {
                    filteredList.Add(task);
                }
            }
            return filteredList;
        }

   
        public void RemoveTask(int id)
        {
            if (_tasks.Remove(id))
            {
                Console.WriteLine($"[System]: Task {id} removed.");
            }
        }

      
        public void DisplayAll()
        {
            Console.WriteLine("\n--- Current Task List ---");
            foreach (var task in _tasks.Values)
            {
                Console.WriteLine(task.ToString());
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}
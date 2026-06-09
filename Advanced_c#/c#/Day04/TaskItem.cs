using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04
{
    public enum TaskStatus { Pending, InProgress, Completed }

    
    [Flags]
    public enum TaskTags { None = 0, Urgent = 1, Personal = 2, Work = 4 }

  
    public delegate void TaskNotify(string message);
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;
        public TaskStatus Status { get; set; }
        public string Assignee { get; set; } = string.Empty;
        public TaskTags Tags { get; set; } 

        public override string ToString()
        {
            return $"ID: {Id} | Title: {Title} | Status: {Status} | Assignee: {Assignee} | Tags: {Tags}";
        }
    }
}
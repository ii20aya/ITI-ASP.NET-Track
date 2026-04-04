using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day04
{
    public class TaskItem
    {
        public Guid GUID { get; set; }
        public int ProcID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Priority { get; set; }

        public TaskItem(int procId, int priority)
        {
            GUID = Guid.NewGuid();
            ProcID = procId;
            Priority = priority;
            StartTime = DateTime.Now;
        }

        public override string ToString()
        {
            return $"ProcID: {ProcID}, Priority: {Priority}";
        }
    }
}

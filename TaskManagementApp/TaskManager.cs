using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementApp
{
    public class TaskManager
    {
        private List<TaskItem> tasks;

        public TaskManager()
        {
            tasks = new List<TaskItem>();
        }

        public void AddTask(TaskItem task)
        {
            if (task != null)
            {
                tasks.Add(task);
            }
        }

        public void RemoveTask(TaskItem task)
        {
            tasks.Remove(task);
        }

        public List<TaskItem> GetAllTasks()
        {
            return tasks;
        }
    }
}

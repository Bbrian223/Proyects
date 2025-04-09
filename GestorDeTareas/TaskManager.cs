using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    public class TaskManager
    {
        private List<Task> list_tasks = new List<Task>();

        public void Add(Task task) 
        {
            list_tasks.Add(task);
        }

        public void Modify(Task task, int index) 
        { 
            list_tasks[index] = task;
        }

        public void Remove(int index)
        { 
            list_tasks.RemoveAt(index);
        }

        public List<Task> getListTask 
        {
            get { return list_tasks; } 
        }

        public Task getTask(int index)
        { 
            return getListTask[index];
        }
    }
}

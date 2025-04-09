using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeTareas
{
    public class Task
    {
        private string title;
        private string description;
        private TaskStatus status;

        public Task(string title, string description, TaskStatus status)
        { 
            Title = title;
            Description = description;
            this.status = status;  
        }

        public string Title 
        {
            get { return title; }
            set { title = string.IsNullOrWhiteSpace(value) ? "sin titulo" : value; }
        }

        public string Description 
        {
            get { return description; }
            set { description = string.IsNullOrWhiteSpace(value) ? "sin descripcion" : value; } 
        }

        public TaskStatus Status
        {
            set { status = value; } 
        }

        public string getStatus 
        {
            get 
            { 
                if (status == TaskStatus.pending) return "pendiente";
                if (status == TaskStatus.inProgress) return "en progreso";
                else return "finalizado";
            }
        }


        public override string ToString()
        {
            return $"Titulo: {title}, Descripcion: {description}, Estado: {getStatus}";
        }
    }

    public enum TaskStatus 
    {
        pending = 0,
        inProgress = 1,
        completed = 2
    }
}

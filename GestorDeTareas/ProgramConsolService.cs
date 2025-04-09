using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestorDeTareas
{
    public class ProgramConsolService
    {
        TaskManager manager = new TaskManager();

        public ConsoleKeyInfo StartConsoleApp()
        {
            ConsoleKeyInfo keyPress;

            Console.Clear();

            Console.WriteLine("Bienvienido a la aplicacion de gestion de tareas.");
            Console.WriteLine("\nSeleccione una opccion: \n");
            Console.WriteLine("1- Agregar Nueva Tarea. \n2- Editar Tarea \n3- Listar Tareas \n4- Eliminar Tarea \nESC- Salir");

            keyPress = Console.ReadKey(true);
            Console.Clear();

            return keyPress;
        }

        public void MessageEndConsoleApp()
        {
            Console.WriteLine("Gracias por usar esta aplicacion \n\n");
        }

        public void AddTaskOnList()
        {
            Console.WriteLine("Agregar nueva tarea: \n\n");
            
            manager.Add(ObteninNewTask());

            Console.WriteLine("\n\n Tarea guardada correctamente, presione una tecla para volver al menu anterior....");
            Console.ReadKey();
        }

        public void ListTaskOnConsole()
        {
            int cont = 1;

            Console.WriteLine("Lista de tareas guardadas\n\n");

            foreach (var item in manager.getListTask)
            {
                Console.WriteLine($"{cont}- {item}");
                cont++;
            }

            if(manager.getListTask.Count == 0)
                Console.WriteLine("Sin tareas registradas...Agrege una para poder visualizarla");

            Console.WriteLine("\n\nPresione una tecla para volver al menu principal....");
            Console.ReadKey();
        }

        public void ModifyTaskFromList()
        {
            bool status = true;

            int index = ObtainIndexTaskFromList();

            while (status)
            {
                Console.WriteLine("Esta seguro que desea modificarlo? (y/n):");
                string? confirmation = Console.ReadLine();


                switch (confirmation.ToLower())
                {
                    case "y":
                        Console.WriteLine("\nIngrese los nuevos datos de la tarea:\n\n");

                        Task task = ObteninNewTask();
                        manager.Modify(task, index);

                        Console.WriteLine("\n\n\nModificacion exitosa! Presione cualquier tecla para volver al menu principal");
                        status = false;
                        
                        break;
                    case "n":
                        Console.WriteLine("\nOperacion Cancelada. Presione cualquier tecla para volver al menu principal");
                        status = false;
                        
                        break;
                    default:
                        Console.WriteLine("\nConfirmacion incorrecta, intentelo de nuevo.....\n\n");

                        break;
                }

            }


            Console.ReadKey();
        }

        public void RemoveTaskFromList()
        {
            bool status = true;

            int index = ObtainIndexTaskFromList();

            while (status)
            {
                Console.WriteLine("Esta seguro que desea Eliminar la tarea? (y/n):");
                string? confirmation = Console.ReadLine();


                switch (confirmation.ToLower())
                {
                    case "y":
                        manager.Remove(index);

                        Console.WriteLine("\n\n\nEliminacion exitosa! Presione cualquier tecla para volver al menu principal");
                        status = false;

                        break;
                    case "n":
                        Console.WriteLine("\nOperacion Cancelada. Presione cualquier tecla para volver al menu principal");
                        status = false;

                        break;
                    default:
                        Console.WriteLine("\nConfirmacion incorrecta, intentelo de nuevo.....\n\n");

                        break;
                }

            }


            Console.ReadKey();
        }

        private Task ObteninNewTask()
        {
            string? title, description;
            TaskStatus status;

            Console.WriteLine("Titulo: ");
            title = Console.ReadLine();
            Console.WriteLine("Descripcion: ");
            description = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("(0- pendiente, 1- en proceso, 2- completado) ");
                Console.WriteLine("Estado: ");

                if (int.TryParse(Console.ReadLine(), out int numberStatus) && Enum.IsDefined(typeof(TaskStatus), numberStatus))
                {
                    status = (TaskStatus)numberStatus;
                    break;
                }
                else
                {
                    Console.WriteLine("Numero de estado incorrecto, ingreselo de nuevo...");
                }
            }

            return new Task(title, description, status);
        }

        private int ObtainIndexTaskFromList()
        {
            int cantTask = manager.getListTask.Count();
            int number;

            while (true)
            {
                Console.WriteLine("Ingrese el numero de tarea: ");

                if (int.TryParse(Console.ReadLine(), out number) && number <= cantTask && number >= 1)
                {
                    Console.WriteLine($"\n\nTarea seleccionada:\n{manager.getTask(number-1)}\n");
                    return number-1;
                }
                else
                {
                    Console.WriteLine("Numero de tarea incorrecto, ingreselo de nuevo...");
                }
            }
        }

    }
}

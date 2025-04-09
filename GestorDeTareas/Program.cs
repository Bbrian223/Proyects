using System.Runtime.CompilerServices;

namespace GestorDeTareas
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProgramConsolService serviceTask = new ProgramConsolService();
            bool status = true;

            do
            {

                switch (serviceTask.StartConsoleApp().Key) 
                {
                    case ConsoleKey.D1: // agregar nueva tarea
                        serviceTask.AddTaskOnList();
                        break;

                    case ConsoleKey.D2: // editar tarea
                        serviceTask.ModifyTaskFromList();
                        break;

                    case ConsoleKey.D3: // listar tareas
                        serviceTask.ListTaskOnConsole();
                        break;

                    case ConsoleKey.D4:  // eliminar tarea
                        serviceTask.RemoveTaskFromList();
                        break;

                    case ConsoleKey.Escape:
                        status = false;
                        break;

                    default:            // en caso de cualquier otra tecla
                        break;
                }

            } while (status);


            serviceTask.MessageEndConsoleApp();
        }

    }
}

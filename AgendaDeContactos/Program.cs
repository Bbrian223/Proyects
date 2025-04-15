using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleServiceManagment managment = new ConsoleServiceManagment();
            bool status = true;


            while (status) 
            {
                switch (managment.StartConsoleApp().Key)
                {
                    case ConsoleKey.D1:                     //Agregar contactos
                        managment.AddContactInList();
                        break;

                    case ConsoleKey.D2:                     // Leer lista de contactos
                        managment.ReadContactList();
                        break;

                    case ConsoleKey.D3:                     // Modificar contacto
                        managment.ModifyContactFromList();
                        break;

                    case ConsoleKey.D4:                     // Eliminar contacto de la agenda
                        managment.RemoveContactFromList();
                        break;

                    case ConsoleKey.Escape:                 // Salir
                        status = false;
                        break;

                    default:                                // CUALQUIER OTRA TECLA
                        managment.InvalidKey = true;
                        break;
                }

            }

            managment.EndConsoleApp();

        }
    }
}

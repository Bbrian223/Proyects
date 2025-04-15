using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    public class ConsoleServiceManagment
    {
        private ContactBook contactBook = new ContactBook();
        public bool InvalidKey = false;

        public ConsoleKeyInfo StartConsoleApp() 
        {
            ConsoleKeyInfo keypress;

            Console.Clear();
            Console.WriteLine("Control de Agenda de contactos\n");
            Console.WriteLine("Seleccione una operacion: \n\n");
            Console.WriteLine("1--  Agregar contacto");
            Console.WriteLine("2--  Leer lista de contactos");
            Console.WriteLine("3--  Modificar Contacto");
            Console.WriteLine("4--  Eliminar contacto");
            Console.WriteLine("ESC- Salir");

            if (InvalidKey == true) InvalidKeyMessage();

            keypress = Console.ReadKey();
            Console.Clear();

            InvalidKey = false;

            return keypress;
        }

        public void AddContactInList() 
        {
            Console.WriteLine("1--  Agregar contacto:\n\n");
            Contact contact = GetInfoNewContact();

            contactBook.Add(contact);

            OperationMessageComplete();
        }

        public void ReadContactList()
        {
            Console.WriteLine("2-- Leer lista de contactos: \n\n");

            if (contactBook.Count != 0)
            {
                foreach (var item in contactBook.getContactList)
                {
                    Console.WriteLine("----------------------------------------");
                    Console.WriteLine(item);
                    Console.WriteLine("----------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Sin contactos guardados. Agrege un contacto para visualizarlo.");
            }

            OperationMessageComplete();
        }

        public void ModifyContactFromList()
        {
            int index;
            Contact contact;
            
            Console.WriteLine("3--  Modificar Contacto:\n\n");

            contact = SearchContacInList();
            index = contactBook.getIndex(contact);

            if (contact == null)
            {
                Console.WriteLine("Contacto no encontrado.");
                OperationMessageComplete();
                return;
            }

            Console.WriteLine("\n\n----------------------------------------");
            Console.WriteLine(contact);
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Esta seguro de modificar este contacto? (y/n)");

            if (ConfirmationVerification())
            {
                Console.WriteLine("\nIngrese los nuevos datos del contacto: \n");
                contact = GetInfoNewContact();

                contactBook.Modify(contact,index);
                OperationMessageComplete();
            }
            else
            {
                OperationMessageComplete(false);
            }

        }

        public void RemoveContactFromList()
        {
            int index;
            Contact contact;

            Console.WriteLine("4--  Eliminar Contacto:\n\n");

            contact = SearchContacInList();
            index = contactBook.getIndex(contact);

            if (contact == null)
            {
                Console.WriteLine("Contacto no encontrado.");
                OperationMessageComplete();
                return;
            }

            Console.WriteLine("\n\n----------------------------------------");
            Console.WriteLine(contact);
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Esta seguro de eliminar este contacto? (y/n)");

            if (ConfirmationVerification())
            {
                contactBook.Remove(contact);
                OperationMessageComplete();
            }
            else
            {
                OperationMessageComplete(false);
            }
        }

        public void EndConsoleApp()
        {
            Console.Clear();
            Console.WriteLine("\n\n Aplicacion de gestion de contactos finalizada....\n\n\n");
        }

        public void InvalidKeyMessage()
        {
            Console.WriteLine("\nTecla incorrecta, intentelo de nuevo...\n");
        }

        private Contact GetInfoNewContact()
        {
            string name, number, email;

            Console.WriteLine("Nombre: ");
            name = Console.ReadLine();
            Console.WriteLine("\nTelefono:");
            number = Console.ReadLine();

            while (!long.TryParse(number, out long aux) && number.Length >= 6 && number.Length <= 15)
            {
                Console.WriteLine("\nEl numero ingresado no es valido, intentelo nuevamente..");
                Console.WriteLine("\nTelefono:");
                number = Console.ReadLine();
            }

            Console.WriteLine("\nEmail:");
            email = Console.ReadLine();

            while (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                Console.WriteLine("\nEl email ingresado no es valido, intentelo nuevamente..");
                Console.WriteLine("\nEmail:");
                email = Console.ReadLine();
            }

            return new Contact(name, number, email);
        }

        private void OperationMessageComplete(bool status = true)
        {
            Console.WriteLine($"\n\nOperación {(status == true? "completada" : "cancelada")} correctamente. Presione cualquier tecla para volver al menú principal");
            Console.ReadKey();
        }

        private Contact SearchContacInList()
        {
            Contact contact; ;

            Console.WriteLine("Buscar contacto por: ");
            Console.WriteLine("1- Buscar por nombre");
            Console.WriteLine("2- Buscar por numero de telefono");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\n\nIngrese su nombre:");
                    string name = Console.ReadLine();

                    contact = contactBook.getContactWithName(name);
                    break;

                case ConsoleKey.D2:
                    Console.WriteLine("\n\nIngrese su numero de telefono:");
                    string number = Console.ReadLine();

                    contact = contactBook.getContactWithNumber(number);
                    break;

                default:
                    contact = null;
                    break;
            }

            return contact;
        }

        private bool ConfirmationVerification()
        {
            while (true)
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        return true;

                    case "n":
                        return false;

                    default:
                        Console.WriteLine("\nConfirmacion incorrecta, intentelo de nuevo...\n");
                        break;
                }
            }
        }
    }
}

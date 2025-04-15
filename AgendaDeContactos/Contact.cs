using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    public class Contact
    {
        private string name;
        private string number_phone;
        private string email;

        public Contact(string name, string number_phone, string email)
        {
            Name = name;
            Number_phone = number_phone;
            Email = email;
        }

        public string Name 
        {
            get { return name; }
            set { name = string.IsNullOrWhiteSpace(value) ? "sin nombre" : value; }
        }

        public string Number_phone  
        {
            get { return number_phone; }
            set { number_phone = string.IsNullOrWhiteSpace(value) ? "sin numero" : value; }
        }

        public string Email 
        {
            get { return email; }
            set { email = string.IsNullOrWhiteSpace(value) ? "sin email" : value; }
        }

        public override string ToString()
        {
            return $"Nombre: {name}\nTelefono: {number_phone}\nEmail: {email}";
        }
    }
}

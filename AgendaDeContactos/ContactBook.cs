using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaDeContactos
{
    public class ContactBook
    {
        private List<Contact> contactList = new List<Contact>();
        private int count => contactList.Count;

        public void Add(Contact contact)
        { 
            contactList.Add(contact);
        }

        public void Remove(Contact contact)
        { 
            contactList.Remove(contact);
        }

        public void Modify(Contact contact, int index)
        {
            if(index >= 0 && index < count)
                contactList[index] = contact; 
        }

        public Contact getContactFromList(int index)
        {
            return index >=0 && index < count ? getContactList[index] : null;
        }

        public Contact getContactWithName(string name) 
        { 
            return getContactList.FirstOrDefault(x => x.Name == name);
        }

        public Contact getContactWithNumber(string number)
        {
            return getContactList.FirstOrDefault(x => x.Number_phone == number);
        }

        public List<Contact> getContactList 
        {
            get { return contactList; } 
        }

        public int Count 
        {
            get { return count; } 
        }

        public int getIndex(Contact contact)
        {
            return getContactList.IndexOf(contact);
        }
    }
}

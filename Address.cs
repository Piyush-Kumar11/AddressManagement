using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Address
    {
        List<Contact> contacts;

        public Address()
        {
            contacts = new List<Contact>();
        }

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
            Console.WriteLine("Contact Added!!!");
        }

        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter the number of contacts you want to add: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Adding Contact "+(i + 1)+": ");
                Contact contact = CreateNewContact();
                AddContact(contact);
            }
        }

        public void EditContact(string fName)
        {
            foreach (var contact in contacts)
            {
                if (contact.GetFirstName().Equals(fName, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Editing Contact...");
                    Contact updatedContact = CreateNewContact();
                    contacts[contacts.IndexOf(contact)] = updatedContact;//Update the contact of that person using index
                    Console.WriteLine("Updated!!!");
                    return;
                }
            }
            Console.WriteLine("Contact not found.");
        }

        public void DeleteContact(string fName)
        {
            foreach (var contact in contacts)
            {
                if (contact.GetFirstName().Equals(fName, StringComparison.OrdinalIgnoreCase))
                {
                    contacts.Remove(contact);//Using list function to remove
                    Console.WriteLine("Deleted success!!!");
                    return;
                }
            }
            Console.WriteLine("Contact not found.");
        }

        public void DisplayAllContacts()
        {
       
            Console.WriteLine("Contacts are: ");
            foreach (var contact in contacts)
            {
                contact.DisplayContact();
                Console.WriteLine();//To print on next line
            }
        }
        public Contact CreateNewContact()
        {
            Console.WriteLine("Enter First Name: ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lName = Console.ReadLine();
            Console.WriteLine("Enter Address: ");
            string address = Console.ReadLine();
            Console.WriteLine("Enter City Name: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter State Name: ");
            string state = Console.ReadLine();
            Console.WriteLine("Enter Zip: ");
            int zip = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Phone No.: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            return new Contact(fName, lName, address, city, state, zip, phone);
        }
    }
}

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
            var contact = contacts.Find(c => c.GetFirstName().Equals(fName, StringComparison.OrdinalIgnoreCase));
            if (contact != null)
            {
                Console.WriteLine("Editing Contact...");
                Contact updatedContact = CreateNewContact();
                contacts[contacts.IndexOf(contact)] = updatedContact; // Update the contact using index
                Console.WriteLine("Updated!!!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DeleteContact(string fName)
        {
            // Using lambda expression to remove all contacts with the given first name
            int removedCount = contacts.RemoveAll(c => c.GetFirstName().Equals(fName, StringComparison.OrdinalIgnoreCase));
            if (removedCount > 0)
            {
                Console.WriteLine("Deleted successfully!!!");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DisplayAllContacts()
        {
            try
            {
                if (contacts.Count == 0)
                {
                    throw new NoContactFoundException("Please add contacts first!");
                }

                Console.WriteLine("Contacts are: ");
                // Using lambda expression to display each contact

                contacts.ForEach(contact =>
                {
                    contact.DisplayContact();
                    Console.WriteLine(); // To print on the next line
                });
            }
            catch (NoContactFoundException e)
            {
                Console.WriteLine(e);//Calls the ToString method from custom exception
            }
            
        }
        public Contact CreateNewContact()
        {
            try
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
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }
    }
}

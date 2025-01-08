using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AddressBook
{
    internal class Address
    {
        List<Contact> contacts;
        Dictionary<string, List<Contact>> cityDictionary;
        Dictionary<string, List<Contact>> stateDictionary;

        public Address()
        {
            contacts = new List<Contact>();
            cityDictionary = new Dictionary<string, List<Contact>>();
            stateDictionary = new Dictionary<string, List<Contact>>();
        }

        public void AddContact(Contact contact)
        {
            try
            {
                contacts.Add(contact);
                var context = new ValidationContext(contact);
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(contact, context, results, true);
                if (isValid)
                {
                    Console.WriteLine("Data Validation Success");
                    Console.WriteLine("Contact Added!!!");

                    // Update city and state dictionaries
                    if (!cityDictionary.ContainsKey(contact.City))
                    {
                        cityDictionary[contact.City] = new List<Contact>();
                    }
                    cityDictionary[contact.City].Add(contact);

                    if (!stateDictionary.ContainsKey(contact.State))
                    {
                        stateDictionary[contact.State] = new List<Contact>();
                    }
                    stateDictionary[contact.State].Add(contact);
                }
                else
                {
                    Console.WriteLine("Data Validation failed!");
                }

                foreach (var error in results)
                {
                    Console.WriteLine($"Error: {error}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Value cannot be null");
            }
        }

        public void AddMultipleContacts()
        {
            Console.WriteLine("Enter the number of contacts you want to add: ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Adding Contact " + (i + 1) + ": ");
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
                contacts.ForEach(contact => Console.WriteLine(contact));
            }
            catch (NoContactFoundException e)
            {
                Console.WriteLine(e); // Calls the ToString method from custom exception
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DisplayPersonsByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                Console.WriteLine($"Persons in {city}:");
                foreach (var contact in cityDictionary[city])
                {
                    Console.WriteLine(contact);
                }
                Console.WriteLine($"Total contacts in {city}: {cityDictionary[city].Count}");
            }
            else
            {
                Console.WriteLine($"No contacts found in city: {city}");
            }
        }

        public void DisplayPersonsByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                Console.WriteLine($"Persons in {state}:");
                foreach (var contact in stateDictionary[state])
                {
                    Console.WriteLine(contact);
                }
                Console.WriteLine($"Total contacts in {state}: {stateDictionary[state].Count}");
            }
            else
            {
                Console.WriteLine($"No contacts found in state: {state}");
            }
        }

        public void SearchByCityOrState(string cityOrState)
        {
            Console.WriteLine($"Searching for contacts in city or state: {cityOrState}");

            var searchResults = contacts.FindAll(c =>
                c.City.Equals(cityOrState, StringComparison.OrdinalIgnoreCase) ||
                c.State.Equals(cityOrState, StringComparison.OrdinalIgnoreCase));

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Found the following contacts:");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine(contact);
                }
                Console.WriteLine($"Total contacts found: {searchResults.Count}");
            }
            else
            {
                Console.WriteLine($"No contacts found in {cityOrState}.");
            }
        }

        public int GetContactCountByCityOrState(string cityOrState)
        {
            int count = 0;
            count += cityDictionary.ContainsKey(cityOrState) ? cityDictionary[cityOrState].Count : 0;
            count += stateDictionary.ContainsKey(cityOrState) ? stateDictionary[cityOrState].Count : 0;
            return count;
        }

        public void SortContactsByName()
        {
            contacts.Sort((c1, c2) =>
            {
                string fullName1 = c1.FirstName + " " + c1.LastName;
                string fullName2 = c2.FirstName + " " + c2.LastName;
                return fullName1.CompareTo(fullName2);  // Sorting alphabetically by name
            });

            Console.WriteLine("Contacts sorted alphabetically by name:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);  // The overridden ToString will be used here
            }
        }

        public void SortContactsByCity()
        {
            contacts.Sort((c1, c2) => c1.City.CompareTo(c2.City));  // Sorting by City alphabetically
            Console.WriteLine("Contacts sorted by City:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
        public void SortContactsByState()
        {
            contacts.Sort((c1, c2) => c1.State.CompareTo(c2.State));  // Sorting by State alphabetically
            Console.WriteLine("Contacts sorted by State:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }

        public void SortContactsByZip()
        {
            contacts.Sort((c1, c2) => c1.Zip.CompareTo(c2.Zip));  // Sorting by Zip numerically
            Console.WriteLine("Contacts sorted by Zip:");
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
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
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

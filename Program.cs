using System;
using System.Collections.Generic;
using System.IO;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Address> addressBooks = new Dictionary<string, Address>();

            char continueChoice;
            do
            {
                Console.WriteLine("Choose Option:\n1. Add New Address Book\n2. Select Address Book\n3. Display All Address Books\n4. Exit");
                int choice = 4;

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter a number between 1 and 4 only!");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter a unique name for the new Address Book:");
                        string newBookName = Console.ReadLine();
                        if (!addressBooks.ContainsKey(newBookName))
                        {
                            addressBooks[newBookName] = new Address();
                            Console.WriteLine($"Address Book '{newBookName}' created successfully!");
                        }
                        else
                        {
                            Console.WriteLine("An Address Book with this name already exists.");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Available Address Book:");
                        
                        Console.WriteLine("Enter the name of the Address Book to select:");
                        string bookName = Console.ReadLine();

                        if (addressBooks.ContainsKey(bookName))
                        {
                            ManageAddressBook(addressBooks[bookName]);
                        }
                        else
                        {
                            Console.WriteLine("Address Book not found.");
                        }
                        break;

                    case 3:
                        if (addressBooks.Count != 0)
                        {
                            foreach (var entry in addressBooks)
                            {
                                string key = entry.Key;
                                Address addressBook = entry.Value; // Value (the Address object containing contacts)

                                Console.WriteLine($"Address Book for: {key}");

                                addressBook.DisplayAllContacts();

                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Address Found!");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Exited Successfully!");
                        return;

                    default:
                        Console.WriteLine("Choose a valid option...");
                        break;
                }

                Console.WriteLine("Enter 'Y/y' to continue or any other key to stop.");
                continueChoice = Convert.ToChar(Console.ReadLine());
            } while (continueChoice == 'Y' || continueChoice == 'y');

            Console.WriteLine("Thank you!");
        }

        static void ManageAddressBook(Address addressBook)
        {
            char choice;
            do
            {
                Console.WriteLine("Choose Option:\n1. Add Contact\n2. Edit Contact\n3. Delete Contact\n4. Add Multiple Contacts\n5. Display All Contacts\n6. Search Contacts by City or State\n7. View Contact Count by City or State\n8. Display Persons by City\n9. Display Persons by State\n10. Sort contacts by Name\n11. Sort Contacts by State, City or Zip\n12. For File Operations\n13. Return to Main Menu");
                int action = 13;

                try
                {
                    action = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter a number between 1 and 10 only!");
                }

                switch (action)
                {
                    case 1:
                        addressBook.AddContact(addressBook.CreateNewContact());
                        break;

                    case 2:
                        Console.WriteLine("Enter First Name to Edit:");
                        string edit = Console.ReadLine();
                        addressBook.EditContact(edit);
                        break;

                    case 3:
                        Console.WriteLine("Enter First Name to Delete:");
                        string delete = Console.ReadLine();
                        addressBook.DeleteContact(delete);
                        break;

                    case 4:
                        addressBook.AddMultipleContacts();
                        break;

                    case 5:
                        addressBook.DisplayAllContacts();
                        break;

                    case 6:
                        Console.WriteLine("Enter the city or state to search for:");
                        string cityOrState = Console.ReadLine();
                        addressBook.SearchByCityOrState(cityOrState);
                        break;

                    case 7:
                        Console.WriteLine("Enter the city or state to get contact count:");
                        string cityOrStateCount = Console.ReadLine();
                        int count = addressBook.GetContactCountByCityOrState(cityOrStateCount);
                        Console.WriteLine($"Total contacts in {cityOrStateCount}: {count}");
                        break;

                    case 8:
                        Console.WriteLine("Enter the city to display persons:");
                        string city = Console.ReadLine();
                        addressBook.DisplayPersonsByCity(city);
                        break;

                    case 9:
                        Console.WriteLine("Enter the state to display persons:");
                        string state = Console.ReadLine();
                        addressBook.DisplayPersonsByState(state);
                        break;

                    case 10:
                        addressBook.SortContactsByName();
                        break;

                    case 11:
                        Console.WriteLine("Choose sorting criteria:\n1. Sort by City\n2. Sort by State\n3. Sort by Zip");
                        int sortChoice = Convert.ToInt32(Console.ReadLine());
                        switch (sortChoice)
                        {
                            case 1:
                                addressBook.SortContactsByCity();
                                break;

                            case 2:
                                addressBook.SortContactsByState();
                                break;

                            case 3:
                                addressBook.SortContactsByZip();
                                break;

                            default:
                                Console.WriteLine("Invalid option.");
                                break;
                        }
                        break;

                    case 12:
                        Console.WriteLine("Choose Option:\n1. Add into File\n2. Read from File\n3. Add to CSV file\n4. Read from CSV file\n5. Add to JSON file\n6. Read from JSON file\n7. Exit");
                        int fileChoice = Convert.ToInt32(Console.ReadLine());
                        switch (fileChoice)
                        {
                            case 1:
                                addressBook.SaveToFile();
                                break;

                            case 2:
                                addressBook.LoadFromFile();
                                break;

                            case 3:
                                addressBook.SaveToCSV();
                                break;

                            case 4:
                                addressBook.ReadFromCSV();
                                break;

                            case 5:
                                addressBook.SaveToJson();
                                break;

                            case 6:
                                addressBook.ReadFromJson();
                                break;

                            case 7:
                                Console.WriteLine("Exited Successfully!");
                                return;

                            default:
                                Console.WriteLine("Choose a valid option...");
                                break;
                        }
                        break;
                    case 13:
                        return;

                    default:
                        Console.WriteLine("Choose a valid option...");
                        break;
                }
                Console.WriteLine("Enter 'Y/y' to continue in this Address Book or any other key to return to Main Menu.");
                choice = Convert.ToChar(Console.ReadLine());
            } while (choice == 'Y' || choice == 'y');
        }
    }
}

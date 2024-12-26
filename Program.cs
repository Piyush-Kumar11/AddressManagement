using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Created object of address to use in all the cases
            Address addressBook = new Address();

            char c;
            do
            {
                Console.WriteLine("Choose Option:\n1.Add\n2.Edit\n3.Delete\n4.Add Multiple\n5.Display All\n6.Exit");
                int choice = 6;
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter number between 1 to 6 only!");
                }

                switch (choice)
                {
                    case 1:
                        addressBook.AddContact(addressBook.CreateNewContact());
                        break;
                    case 2:
                        Console.WriteLine("Enter First Name to Edit: ");
                        string edit = Console.ReadLine();
                        addressBook.EditContact(edit);
                        break;
                    case 3:
                        Console.WriteLine("Enter First Name to Delete: ");
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
                        Console.WriteLine("Exited Successfully!!!");
                        return;
                    default:
                        Console.WriteLine("Choose other options...");
                        break;
                }
                Console.WriteLine("Enter 'Y/y' to continue or other key to stop");
                c = Convert.ToChar(Console.ReadLine());
            } while (c == 'Y' || c=='y');
            Console.WriteLine("Thank you!!!");
        }
    }
}

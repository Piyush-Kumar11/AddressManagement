using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Contact
    {
        private string firstName { get; }
        private string lastName { get; }
        private string address { get;}
        private string city { get; }
        private string state { get; }
        private int zip { get; }
        private long phoneNum { get; }
        private string email { get; }

        public Contact(string fName,string lName,string add, string city, string state, int zip, long phoneNum)
        {
            this.firstName = fName;
            this.lastName = lName;
            this.address = lName;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNum = phoneNum;
        }

        public void DisplayContact()
        {
            Console.WriteLine("First Name: " + firstName + "\nLast Name: " + lastName + "\nAddress: " + address + "\ncity: " + city + "\nState: " + state + "\nZip: " + zip + "\nPhoneNumber: " + phoneNum);
        }

        public string GetFirstName()
        {
            return firstName;
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Contact
    {
        [Required(ErrorMessage="First name required!")]
        [StringLength(12,ErrorMessage ="String length should be in 2 to 12 Charcaters only!"),MinLength(2)]
        public string firstName { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"),MinLength(2)]
        public string lastName { get; set; }

        [StringLength(100, ErrorMessage = "String length should be in 2 to 100 Charcaters only!"),MinLength(2)]
        public string address { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"), MinLength(2)]
        public string city { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"), MinLength(2)]
        public string state { get; set; }

        [Range(100000,999999,ErrorMessage ="Not valid zip code")]
        public int zip { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Not valid zip code")]
        public long phoneNum { get; set; }

        [EmailAddress(ErrorMessage ="Not a valid email")]
        public string email { get; set; }

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

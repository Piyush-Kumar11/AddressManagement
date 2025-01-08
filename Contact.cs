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
        public string FirstName { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"),MinLength(2)]
        public string LastName { get; set; }

        [StringLength(100, ErrorMessage = "String length should be in 2 to 100 Charcaters only!"),MinLength(2)]
        public string Address { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"), MinLength(2)]
        public string City { get; set; }

        [StringLength(12, ErrorMessage = "String length should be in 2 to 12 Charcaters only!"), MinLength(2)]
        public string State { get; set; }

        [Range(100000,999999,ErrorMessage ="Not valid zip code")]
        public int Zip { get; set; }

        [Range(1000000000, 9999999999, ErrorMessage = "Not valid zip code")]
        public long PhoneNum { get; set; }

        [EmailAddress(ErrorMessage ="Not a valid email")]
        public string Email { get; set; }

        public Contact(string fName,string lName,string add, string city, string state, int zip, long phoneNum)
        {
            FirstName = fName;
            LastName = lName;
            Address = lName;
            City = city;
            State = state;
            Zip = zip;
            PhoneNum = phoneNum;
        }

        public override string ToString()
        {
            return $"First Name: {FirstName} \nLast Name: {LastName} \nAddress: {Address} \ncity: {City} \nState: {State} \nZip: {Zip} \nPhoneNumber: {PhoneNum}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Contact otherContact)
            {
                return string.Equals(FirstName, otherContact.FirstName, StringComparison.OrdinalIgnoreCase) &&
                       string.Equals(LastName, otherContact.LastName, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        public override int GetHashCode()
        {
            string fName = FirstName != null ? FirstName.ToLower() : string.Empty;
            string lName = LastName != null ? LastName.ToLower() : string.Empty;
            return (fName + lName).GetHashCode();
        }


        public string GetFirstName()
        {
            return FirstName;
        }
        public string GetLastName() => LastName;
    }
}

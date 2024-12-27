using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class NoContactFoundException: Exception
    {
        public NoContactFoundException(string msg): base(msg) { }

        public override string ToString()
        {
            return $"Custom Exception: {Message}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Client
    {
            public int Code { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

            // Constructor
            public Client()
            {
            }

            public Client(int code, string firstName, string lastName, string address, string phone, string email)
            {
                Code = code;
                FirstName = firstName;
                LastName = lastName;
                Address = address;
                Phone = phone;
                Email = email;
            }
        }
}

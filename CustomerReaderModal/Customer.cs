using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReaderModal
{
    public class Address
    {
        public String streetAddress;
        public String city;
        public String state;
        public String zipCode;
    }
    public class Customer : Address
    {
        public String firstName;
        public String lastName;
        public String email;
        public String phone;
        public String fullName;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerReaderModal
{
    public class Address
    {
        public String streetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public String zipCode { get; set; }
    }
    public class Customer : Address
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String phone { get; set; }
        public String fullName { get; set; }
    }
}

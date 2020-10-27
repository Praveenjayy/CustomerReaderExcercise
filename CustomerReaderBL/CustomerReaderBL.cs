using System.Collections.Generic;

namespace CustomerReaderBL
{
    public class CustomerReaderBL
    {
        CustomerReaderDL.CustomerReaderDL objCutomerReaderDL = new CustomerReaderDL.CustomerReaderDL();
        private List<CustomerReaderModal.Customer> customers;

        public CustomerReaderBL()
        {
            customers = new List<CustomerReaderModal.Customer>();
        }

        /*
         * This method returns customer list.
         */
        public List<CustomerReaderModal.Customer> GetCustomers()
        {
            customers = objCutomerReaderDL.GetCustomers();
            return customers;
        }
    }
}

using NUnit.Framework;
using System.Collections.Generic;

namespace CustomerRederTestProject
{
    [TestFixture]
    public class CustomerReaderTests
    {
        CustomerReaderDL.CustomerReaderDL objCustomerReaderDL = new CustomerReaderDL.CustomerReaderDL();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void When_ReadCustomers_from_Csv()
        {
            List<CustomerReaderModal.Customer> lstCustomers = objCustomerReaderDL.ReadCustomersCsv("..\\..\\..\\doc\\customers.csv");
            if (lstCustomers.Count > 0)
                Assert.Pass("Test case Passed");
            else
                Assert.Fail("Test case Failed");
        }

        [Test]
        public void When_ReadCustomers_from_XML()
        {
            List<CustomerReaderModal.Customer> lstCustomers = objCustomerReaderDL.ReadCustomersXml("..\\..\\..\\doc\\customers.xml");
            if (lstCustomers.Count > 0)
                Assert.Pass("Test case Passed");
            else
                Assert.Fail("Test case Failed");
        }

        [Test]
        public void When_ReadCustomers_from_Json()
        {
            List<CustomerReaderModal.Customer> lstCustomers = objCustomerReaderDL.ReadCustomersJson("..\\..\\..\\doc\\customers.json");
            if (lstCustomers.Count > 0)
                Assert.Pass("Test case Passed");
            else
                Assert.Fail("Test case Failed");
        }
    }
}
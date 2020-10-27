using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CustomerReaderDL
{
    public class CustomerReaderDL
    {
        /*
         * This method returns customer list.
         */
        public List<CustomerReaderModal.Customer> GetCustomers()
        {
            CustomerReaderDL objCustomerReaderDL = new CustomerReaderDL();
            List<CustomerReaderModal.Customer> lstCustomers = new List<CustomerReaderModal.Customer>();
            lstCustomers.AddRange(objCustomerReaderDL.ReadCustomersCsv("..\\..\\..\\doc\\customers.csv"));
            lstCustomers.AddRange(objCustomerReaderDL.ReadCustomersXml("..\\..\\..\\doc\\customers.xml"));
            lstCustomers.AddRange(objCustomerReaderDL.ReadCustomersJson("..\\..\\..\\doc\\customers.json"));
            return lstCustomers;
        }

        /*
         * This method reads customers from a CSV file and puts them into the customers list.
         */
        public List<CustomerReaderModal.Customer> ReadCustomersCsv(String customer_file_path)
        {
            List<CustomerReaderModal.Customer> customers = new List<CustomerReaderModal.Customer>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            try
            {
                StreamReader br = new StreamReader(File.Open(customer_file_path, FileMode.Open));
                String line = br.ReadLine();

                while (line != null)
                {
                    //String[] attributes = line.split(" , ");
                    String[] attributes = line.Split(',');

                    CustomerReaderModal.Customer customer = new CustomerReaderModal.Customer();
                    customer.email = textInfo.ToLower(attributes[0]);
                    customer.firstName = textInfo.ToTitleCase(attributes[1]);
                    customer.lastName = textInfo.ToTitleCase(attributes[2]);
                    customer.fullName = textInfo.ToTitleCase(attributes[1] + " " + attributes[2]);
                    customer.phone = attributes[3];
                    customer.streetAddress = textInfo.ToTitleCase(attributes[4]);
                    customer.city = textInfo.ToTitleCase(attributes[5]);
                    customer.state = textInfo.ToUpper(attributes[6]);
                    customer.zipCode = attributes[7];

                    customers.Add(customer);
                    line = br.ReadLine();
                }
            }
            catch (IOException ex)
            {
                Console.Write("OH NO!!!!");
                Console.Write(ex.StackTrace);
            }
            return customers;
        }

        /*
         * This method reads customers from a XML file and puts them into the customers list.
         */
        public List<CustomerReaderModal.Customer> ReadCustomersXml(String customerFilePath)
        {
            List<CustomerReaderModal.Customer> customers = new List<CustomerReaderModal.Customer>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            try
            {
                var doc = new XmlDocument();
                doc.Load(customerFilePath);
                XmlNodeList nList = doc.GetElementsByTagName("Customers");

                for (int temp = 0; temp < nList.Count; temp++)
                {
                    XmlNode nNode = nList[temp];
                    Console.WriteLine("\nCurrent Element :" + nNode.Name);
                    if (nNode.NodeType == XmlNodeType.Element)
                    {
                        CustomerReaderModal.Customer customer = new CustomerReaderModal.Customer();
                        XmlElement eElement = (XmlElement)nNode;

                        customer.email = textInfo.ToLower(eElement.GetElementsByTagName("Email").Item(0).InnerText);
                        customer.firstName = textInfo.ToTitleCase(eElement.GetElementsByTagName("FirstName").Item(0).InnerText);
                        customer.lastName = textInfo.ToTitleCase(eElement.GetElementsByTagName("LastName").Item(0).InnerText);
                        customer.fullName = textInfo.ToTitleCase(eElement.GetElementsByTagName("FirstName").Item(0).InnerText + " " + eElement.GetElementsByTagName("LastName").Item(0).InnerText);
                        customer.phone = eElement.GetElementsByTagName("PhoneNumber").Item(0).InnerText;

                        XmlElement aElement = (XmlElement)eElement.GetElementsByTagName("Address").Item(0);

                        customer.streetAddress = textInfo.ToTitleCase(aElement.GetElementsByTagName("StreetAddress").Item(0).InnerText);
                        customer.city = textInfo.ToTitleCase(aElement.GetElementsByTagName("City").Item(0).InnerText);
                        customer.state = textInfo.ToUpper(aElement.GetElementsByTagName("State").Item(0).InnerText);
                        customer.zipCode = aElement.GetElementsByTagName("ZipCode").Item(0).InnerText;

                        customers.Add(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            return customers;
        }

        /*
         * This method reads customers from a Json file and puts them into the customers list.
         */
        public List<CustomerReaderModal.Customer> ReadCustomersJson(String customersFilePath)
        {
            JsonTextReader reader = new JsonTextReader(System.IO.File.OpenText(customersFilePath));
            List<CustomerReaderModal.Customer> customers = new List<CustomerReaderModal.Customer>();
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            try
            {
                JArray obj = (JArray)JToken.ReadFrom(reader);
                //JArray a = (JArray)reader);
                //

                foreach (JObject o in obj)
                {
                    CustomerReaderModal.Customer customer = new CustomerReaderModal.Customer();
                    JObject record = (JObject)o;

                    String email = (String)record["Email"];
                    customer.email = textInfo.ToLower(email);

                    String firstName = (String)record["FirstName"];
                    customer.firstName = textInfo.ToTitleCase(firstName);

                    String lastName = (String)record["LastName"];
                    customer.lastName = textInfo.ToTitleCase(lastName);

                    customer.fullName = textInfo.ToTitleCase(firstName + " " + lastName);

                    String phone = (String)record["PhoneNumber"];
                    customer.phone = phone;

                    JObject address = (JObject)record["Address"];

                    String streetAddress = (String)address["StreetAddress"];
                    customer.streetAddress = textInfo.ToTitleCase(streetAddress);

                    String city = (String)address["City"];
                    customer.city = textInfo.ToTitleCase(city);

                    String state = (String)address["State"];
                    customer.state = textInfo.ToUpper(state);

                    String zipCode = (String)address["ZipCode"];
                    customer.zipCode = zipCode;

                    customers.Add(customer);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (IOException e)
            {
                Console.Write(e.StackTrace);
            }
            catch (JsonException e)
            {
                Console.Write(e.StackTrace);
            }
            return customers;
        }
    }
}

using System;
using System.Diagnostics;
using System.Linq;
using A.Blog.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace A.Blog.Data.Repository.Test
{
    [TestClass]
    public class CustomerTests
    {
        private BlogRepository _repository;

        [TestInitialize]
        public void Initialise()
        {
            _repository = new BlogRepository();
        }

        [TestMethod]
        public void Query_AllCustomers_NoException()
        {
            var customers = _repository.AllIncluding<Customer>().ToList();

            foreach (var customer in customers)
            {
                Trace.TraceInformation("Customer : " + customer.CompanyName);

            }
        }


        [TestMethod]
        public void Query_AllCustomersIncludeOrders_NoException()
        {
            var customers = _repository.AllIncluding<Customer>(p=>p.Orders).ToList();

            foreach (var customer in customers)
            {
                Trace.TraceInformation("Customer : " + customer.CompanyName);
                Trace.TraceInformation("Orders # : " + customer.Orders.Count);

            }
        }
    }
}

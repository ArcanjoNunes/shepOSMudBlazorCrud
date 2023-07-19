using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shepOSMudBlazorCrud.Repository;
using shepOSMudBlazorCrud.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace shepOSMudBlazorCrud.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly shepOSDbContext _dbContext;

        public CustomerService(shepOSDbContext context)
        {
            _dbContext = context;
        }

        public void DeleteCustomer(int id)
        {
            var customer = _dbContext.Customers.FirstOrDefault(x => x.Id == id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
            }
        }

        public Customer GetCustomerById(int id)
        {
            return _dbContext.Customers.SingleOrDefault(x => x.Id == id) ?? new Customer();
        }

        public List<Customer> GetCustomers()
        {
            RefreshCustomer();
            return _dbContext.Customers.ToList();
        }

        public void ReloadCustomer(ref Customer customer)
        {
            _dbContext.Entry(customer).Reload();
        }

        public void RefreshCustomer()
        {
            _dbContext.Customers.Load();
        }

        public void SaveCustomer(Customer customer)
        {
            if (customer.Id == 0) { _dbContext.Customers.Add(customer); }
            else                  { _dbContext.Customers.Update(customer); }
            _dbContext.SaveChanges();
        }

        public System.Data.DataTable GetCustomerList(List<Customer> customerList)
        {
            return shepOS.shepOSLibrary.ToDataTable(customerList, shepOS.shepOSLibrary.REPORT_MAIN_TABLENAME);
        }

        public class ResultGroup
        {
            public string? Title { get; set; }
            public int Total { get; set; }
        }
        public IOrderedEnumerable<ResultGroup> GetRegionSummary()
        {
            IOrderedEnumerable<ResultGroup> oResultGroup = GetCustomers()
                .GroupBy(c => c.RegionTitle)
		        .Select(c => new ResultGroup { Title = c.Key, Total = c.Count() })
				.OrderBy(c => c.Title);

            return oResultGroup;
        }
	}
}

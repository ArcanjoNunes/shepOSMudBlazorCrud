using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shepOSMudBlazorCrud.Models;
using static shepOSMudBlazorCrud.Services.CustomerService;

namespace shepOSMudBlazorCrud.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);
        void SaveCustomer(Customer customer);
        void ReloadCustomer(ref Customer customer);
        void DeleteCustomer(int id);
        System.Data.DataTable GetCustomerList(List<Customer> customerList);
        IOrderedEnumerable<ResultGroup> GetRegionSummary();


	}
}

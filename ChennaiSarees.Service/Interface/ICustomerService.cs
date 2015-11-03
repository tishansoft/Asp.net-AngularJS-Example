using ChennaiSarees.BusinessObjects.Customer;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Repository.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.Implementation
{
    public interface ICustomerService : IService<Customer>
    {
        decimal CustomerOrderTotalByYear(string customerId, int year);
        IEnumerable<CustomerDto> CustomersByCompany(string companyName);
    }
}

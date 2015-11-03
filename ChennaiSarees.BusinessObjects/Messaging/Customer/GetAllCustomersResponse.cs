using ChennaiSarees.BusinessObjects.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Messaging.Customer
{
    public class GetAllCustomersResponse : ServiceResponseBase
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
    }
}

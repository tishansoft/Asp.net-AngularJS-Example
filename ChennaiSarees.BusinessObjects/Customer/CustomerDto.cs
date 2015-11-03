using ChennaiSarees.BusinessObjects.Order;
using System;
using System.Collections.Generic;


namespace ChennaiSarees.BusinessObjects.Customer
{
    public class CustomerDto
    {
        public CustomerDto()
        {
            orders = new List<OrderDto>();
                
        }
        private List<OrderDto> orders { get; set; }

        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public IEnumerable<OrderDto> GetOrders()
        {
            return orders;
        }

        public void AddOrder(OrderDto order)
        {
            orders.Add(order);
        }
    }
}
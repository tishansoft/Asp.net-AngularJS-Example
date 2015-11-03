using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ChennaiSarees.Entities.Models
{
    public partial class Customer : Entity
    {
        public Customer()
        {
            this.Orders = new List<Order>();
            this.ShoppingCarts = new List<ShoppingCart>();
            this.CustomerDemographics = new List<CustomerDemographic>();
        }

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
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public virtual ICollection<CustomerDemographic> CustomerDemographics { get; set; }
    }
}

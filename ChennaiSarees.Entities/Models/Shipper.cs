using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ChennaiSarees.Entities.Models
{
    public partial class Shipper : Entity
    {
        public Shipper()
        {
            this.Orders = new List<Order>();
        }

        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

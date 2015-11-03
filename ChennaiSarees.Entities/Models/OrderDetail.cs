using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ChennaiSarees.Entities.Models
{
    public partial class OrderDetail : Entity
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}

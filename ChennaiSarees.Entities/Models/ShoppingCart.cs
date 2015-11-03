using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;

namespace ChennaiSarees.Entities.Models
{
    public partial class ShoppingCart : Entity
    {
        public int ShoppingCartId { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public int ProductID { get; set; }
        public short Quantity { get; set; }
        public System.DateTime OrderDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Product Product { get; set; }
    }
}

using ChennaiSarees.BusinessObjects.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.OrderDetail
{
    public class OrderDetailDto
    {
        public ProductDto product { get; set; }

        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public ProductDto GetProduct()
        {
            return product;
        }

        public void AddProduct(ProductDto productdto)
        {
            product = productdto;
        }
    }

}

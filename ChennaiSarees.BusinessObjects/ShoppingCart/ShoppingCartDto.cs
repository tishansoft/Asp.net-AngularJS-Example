using ChennaiSarees.BusinessObjects.Product;
using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ChennaiSarees.BusinessObjects.ShoppingCart
{
    [DataContract]
    public class ShoppingCartDto
    {

        public ShoppingCartDto()
        {
            Product = new ProductDto();
        }
        [DataMember]
        public ProductDto Product { get; private set; }
        [DataMember]
        public int ShoppingCartId { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public Nullable<int> EmployeeID { get; set; }
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public Nullable<System.DateTime> OrderDate { get; set; }

        public ProductDto GetProduct()
        {
            return Product;
        }

        public void AddProduct(ProductDto productDto)
        {
            Product = productDto;
        }

    }
}

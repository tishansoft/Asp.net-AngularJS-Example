using ChennaiSarees.BusinessObjects.OrderDetail;
using ChennaiSarees.BusinessObjects.Shipper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Order
{
    public class OrderDto
    {
        private List<OrderDetailDto> orderDetails { get; set; }
        private ShipperDto shipper { get; set; }

        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public System.DateTime? OrderDate { get; set; }
        public System.DateTime? RequiredDate { get; set; }
        public System.DateTime? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }

        public IEnumerable<OrderDetailDto> GetOrderDetails()
        {
            return orderDetails;
        }

        public void AddOrder(OrderDetailDto orderDetail)
        {
            orderDetails.Add(orderDetail);
        }

        public ShipperDto GetShipper()
        {
            return shipper;
        }

        public void AddShipper(ShipperDto shipperdto)
        {
            shipper = shipperdto;
        }
    }
}

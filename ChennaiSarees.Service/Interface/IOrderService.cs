using ChennaiSarees.BusinessObjects.Messaging.Order;
using ChennaiSarees.Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.Interface
{
    public interface IOrderService : IService<Order>
    {
        AddOrderResponse AddOrder(AddOrderRequest addOrderRequest);
    }
}

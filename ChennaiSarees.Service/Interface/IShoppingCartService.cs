using ChennaiSarees.BusinessObjects.Messaging.ShoppingCart;
using ChennaiSarees.Entities.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.Interface
{
    public interface IShoppingCartService : IService<ShoppingCart>
    {
        AddShoppingCartResponse AddShoppingCart(AddShoppingCartRequest addShoppingCartRequest);
        ListShoppingCartResponse ListShoppingCart(ListShoppingCartRequest listShoppingCartRequest);
        UpdateShoppingCartResponse UpdateShoppingCart(UpdateShoppingCartRequest addShoppingCartRequest);
    }
}

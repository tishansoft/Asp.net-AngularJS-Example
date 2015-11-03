using AutoMapper;
using ChennaiSarees.BusinessObjects.Order;
using ChennaiSarees.BusinessObjects.OrderDetail;
using ChennaiSarees.BusinessObjects.Product;
using ChennaiSarees.BusinessObjects.ShoppingCart;
using ChennaiSarees.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.AppServiceAutomapperConfig
{
    public static class InitializeAppServiceAutoMapper
    {
        public static void Initialize() {
            MapOrder();
            MapOrderItem();
            MapShoppingCart();
            MapProduct();
        }

        public static void MapOrder()
        {
            Mapper.CreateMap<AddOrderDto, Order>();
        }

        public static void MapOrderItem()
        {
            Mapper.CreateMap<AddOrderDetailDto, OrderDetail>();
        }

        public static void MapShoppingCart()
        {
            Mapper.CreateMap<AddShoppingCartDto, ShoppingCart>();
            Mapper.CreateMap<ShoppingCart, ShoppingCartDto>();
        }

        public static void MapProduct()
        {
            Mapper.CreateMap<Product, ProductDto>();
        }


    }
}

﻿using ChennaiSarees.BusinessObjects.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Messaging.ShoppingCart
{
    public class ListShoppingCartResponse : ServiceResponseBase
    {
        public IEnumerable<ShoppingCartDto> ShoppingCartItems { get; set; }
    }
}
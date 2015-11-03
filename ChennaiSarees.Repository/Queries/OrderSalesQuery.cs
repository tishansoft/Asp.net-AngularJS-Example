﻿using System;
using System.Linq;
using System.Linq.Expressions;
using ChennaiSarees.Entities.Models;
using Repository.Pattern.Ef6;

namespace ChennaiSarees.Repository.Queries
{
    public class OrderSalesQuery : QueryObject<Order>
    {
        public decimal Amount { get; set; }
        public string Country { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public override Expression<Func<Order, bool>> Query()
        {
            return (x =>
                x.OrderDetails.Sum(y => y.UnitPrice) > Amount &&
                x.OrderDate >= FromDate &&
                x.OrderDate <= ToDate &&
                x.ShipCountry == Country);
        }
    }
}
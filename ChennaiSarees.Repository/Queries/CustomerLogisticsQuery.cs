﻿using ChennaiSarees.Entities.Models;
using Repository.Pattern.Ef6;

namespace ChennaiSarees.Repository.Queries
{
    public class CustomerLogisticsQuery : QueryObject<Customer>
    {
        public CustomerLogisticsQuery FromCountry(string country)
        {
            And(x => x.Country == country);
            return this;
        }

        public CustomerLogisticsQuery LivesInCity(string city)
        {
            And(x => x.City == city);
            return this;
        }
    }
}
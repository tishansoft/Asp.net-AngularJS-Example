﻿using ChennaiSarees.Infrastructure.Domain;
using ChennaiSarees.Service.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.BusinessRules
{
    public class AppServiceCustomerBusinessRule
    {
        public static readonly BusinessRule CustomerNotFoundForGivenId = new BusinessRule(AppServiceApplicationMessages.CustomerNotFoundForGivenId);
    }
}

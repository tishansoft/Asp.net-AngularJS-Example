using ChennaiSarees.BusinessObjects.Customer;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Repository.Models;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.Interface
{
    public interface IProductService : IService<Product>
    {}
}

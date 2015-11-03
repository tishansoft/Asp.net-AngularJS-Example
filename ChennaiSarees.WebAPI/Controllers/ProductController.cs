using ChennaiSarees.Entities.Models;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Service.Interface;
using ChennaiSarees.WebAPI.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ChennaiSarees.WebAPI.Controllers
{
    public class ProductController : BaseApiODataController
    {
        private readonly IProductService _ProductService;

        public ProductController(ILogRepository logRepository, IMappingService mappingService, IProductService ProductService)
            : base(logRepository, mappingService)
        {
            _ProductService = ProductService;
        }

        // GET: odata/Products
        [HttpGet]
        [EnableQuery]
        public IQueryable<Product> GetProduct()
        {
            var test = _ProductService.Queryable();
            var test1 = test;
            return _ProductService.Queryable();
        }

        // GET: odata/Products(5)
        [EnableQuery]
        public SingleResult<Product> GetProduct([FromODataUri] int key)
        {
            return SingleResult.Create(_ProductService.Queryable().Where(t => t.ProductID == key));
        }
        private bool ProductExists(int key)
        {
            return _ProductService.Query(e => e.ProductID == key).Select().Any();
        }
    }
}

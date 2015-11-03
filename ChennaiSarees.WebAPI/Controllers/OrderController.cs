using ChennaiSarees.BusinessObjects.Messaging.Order;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Service.Interface;
using ChennaiSarees.WebAPI.Api;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace ChennaiSarees.WebAPI.Controllers
{
    public class OrderController : BaseApiODataController
    {
        private readonly IOrderService _OrderService;

        public OrderController(ILogRepository logRepository, IMappingService mappingService, IOrderService OrderService)
            : base(logRepository, mappingService)
        {
            _OrderService = OrderService;
        }

        // GET: odata/Orders
        [HttpGet]
        [EnableQuery]
        public IQueryable<Order> GetOrder()
        {
            return _OrderService.Queryable();
        }

        // GET: odata/Orders(5)
        [HttpGet]
        [EnableQuery]
        public SingleResult<Order> GetOrder([FromODataUri] int key)
        {
            return SingleResult.Create(_OrderService.Queryable().Where(t => t.OrderID == key));
        }

        [HttpPost]
        public IHttpActionResult AddOrder(AddOrderRequest addOrderRequest)
        {
            try
            {
                if (addOrderRequest == null)
                {
                    return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.BadRequest });
                }

                var addOrderResponse = _OrderService.AddOrder(addOrderRequest);

                if (addOrderResponse.ValidationResults.Any())
                {
                    return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(JsonConvert.SerializeObject(string.Join(",", addOrderResponse.ValidationResults))) });
                }

                return Ok<AddOrderResponse>(addOrderResponse);
            }
            catch (Exception ex)
            {
                _logRepository.Log(ex);
                return InternalServerError();
            }
        }


        private bool OrderExists(int key)
        {
            return _OrderService.Query(e => e.OrderID == key).Select().Any();
        }
    }
}

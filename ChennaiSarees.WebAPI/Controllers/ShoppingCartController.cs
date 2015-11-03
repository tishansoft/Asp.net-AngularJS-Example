using ChennaiSarees.BusinessObjects.Messaging.ShoppingCart;
using ChennaiSarees.BusinessObjects.ShoppingCart;
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
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace ChennaiSarees.WebAPI.Controllers
{
    public class ShoppingCartController : BaseApiController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(ILogRepository logRepository, IMappingService mappingService, IShoppingCartService shoppingCartService)
            : base(logRepository, mappingService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // GET: odata/Products(5)
        [HttpGet]
        public IHttpActionResult GetShoppingCart(string id)
        {
            var getShoppingCartList = _shoppingCartService.ListShoppingCart(new ListShoppingCartRequest { CustomerID = id });
            if (getShoppingCartList.ValidationResults.Any())
            {
                return ResponseMessage(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(JsonConvert.SerializeObject(string.Join(",", getShoppingCartList.ValidationResults))) });
            }

            return Ok<ListShoppingCartResponse>(getShoppingCartList);
        }

        // POST: odata/ShoppingCart
        [HttpPost]
        public IHttpActionResult Post(AddShoppingCartRequest addShoppingCartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _shoppingCartService.AddShoppingCart(addShoppingCartDto);
            try
            {
 
                if (result.ValidationResults != null && result.ValidationResults.Count() != 0)
                {
                    return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(JsonConvert.SerializeObject(string.Join(",", result.ValidationResults))) });
                }

            }
            catch (Exception ex)
            {
                _logRepository.Log(ex);
                throw;
            }

            return Ok<AddShoppingCartResponse>(result);
        }

        [HttpPut]
        public IHttpActionResult Put(UpdateShoppingCartRequest updateShoppingCartDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _shoppingCartService.UpdateShoppingCart(updateShoppingCartDto);
            try
            {

                if (result.ValidationResults != null && result.ValidationResults.Count() != 0)
                {
                    return ResponseMessage(new HttpResponseMessage() { StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(JsonConvert.SerializeObject(string.Join(",", result.ValidationResults))) });
                }

            }
            catch (Exception ex)
            {
                _logRepository.Log(ex);
                throw;
            }

            return Ok<UpdateShoppingCartResponse>(result);
        }

    }
}

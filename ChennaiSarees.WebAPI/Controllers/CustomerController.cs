using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Service;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.UnitOfWork;
using ChennaiSarees.Service.Implementation;
using ChennaiSarees.WebAPI.Api;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Service.Interface;

namespace ChennaiSarees.Web.Controllers
{
    public class CustomerController : BaseApiODataController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ILogRepository logRepository, IMappingService mappingService, ICustomerService customerService)
            : base(logRepository, mappingService)
        {
            _customerService = customerService;
        }

        // GET: odata/Customers
        [HttpGet]
        [EnableQuery]
        public IQueryable<Customer> GetCustomer()
        {
            return _customerService.Queryable();
        }

        // GET: odata/Customers(5)
        [EnableQuery]
        public SingleResult<Customer> GetCustomer([FromODataUri] string key)
        {
            return SingleResult.Create(_customerService.Queryable().Where(t => t.CustomerID == key));
        }
/*

        // PUT: odata/Customers(5)
        public async Task<IHttpActionResult> Put(string key, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != customer.CustomerID)
            {
                return BadRequest();
            }

            customer.ObjectState = ObjectState.Modified;
            _customerService.Update(customer);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(customer);
        }

        // POST: odata/Customers
        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customer.ObjectState = ObjectState.Added;
            _customerService.Insert(customer);

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerExists(customer.CustomerID))
                {
                    return Conflict();
                }
                throw;
            }

            return Created(customer);
        }

        //// PATCH: odata/Customers(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] string key, Delta<Customer> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Customer customer = await _customerService.FindAsync(key);

            if (customer == null)
            {
                return NotFound();
            }

            patch.Patch(customer);
            customer.ObjectState = ObjectState.Modified;

            try
            {
                await _unitOfWorkAsync.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                throw;
            }

            return Updated(customer);
        }

        // DELETE: odata/Customers(5)
        public async Task<IHttpActionResult> Delete(string key)
        {
            Customer customer = await _customerService.FindAsync(key);

            if (customer == null)
            {
                return NotFound();
            }

            customer.ObjectState = ObjectState.Deleted;

            _customerService.Delete(customer);
            await _unitOfWorkAsync.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Customers(5)/CustomerDemographics
        [Queryable]
        public IQueryable<CustomerDemographic> GetCustomerDemographics([FromODataUri] string key)
        {
            return
                _customerService.Queryable()
                    .Where(m => m.CustomerID == key)
                    .SelectMany(m => m.CustomerDemographics);
        }

        // GET: odata/Customers(5)/Orders
        [Queryable]
        public IQueryable<Order> GetOrders([FromODataUri] string key)
        {
            return _customerService.Queryable().Where(m => m.CustomerID == key).SelectMany(m => m.Orders);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWorkAsync.Dispose();
                _customerService.Dispose();
            }
            base.Dispose(disposing);
        }
*/
        private bool CustomerExists(string key)
        {
            return _customerService.Query(e => e.CustomerID == key).Select().Any();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _customerService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
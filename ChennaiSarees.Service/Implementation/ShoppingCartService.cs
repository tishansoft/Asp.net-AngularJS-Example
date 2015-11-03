using ChennaiSarees.BusinessObjects.Messaging.ShoppingCart;
using ChennaiSarees.BusinessObjects.Product;
using ChennaiSarees.BusinessObjects.ShoppingCart;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Service.BusinessRules.ShoppingCart;
using ChennaiSarees.Service.Interface;
using Repository.Pattern.Infrastructure;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.Service.Implementation
{
    public class ShoppingCartService : Service<ShoppingCart>, IShoppingCartService
    {
        private readonly IMappingService _mappingService;
        private readonly ILogRepository _log;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ShoppingCartService(IRepositoryAsync<ShoppingCart> repository, IUnitOfWorkAsync unitOfWorkAsync, IMappingService mappingService, ILogRepository logRepository)
            : base(repository)
        {
            if (mappingService == null) throw new ArgumentNullException("mappingService");
            {
                _mappingService = mappingService;
            }
            if (logRepository == null) throw new ArgumentNullException("Log Repository");
            {
                _log = logRepository;
            }
            if (unitOfWorkAsync == null) throw new ArgumentNullException("UnitOfWorkAsync");
            {
                _unitOfWorkAsync = unitOfWorkAsync;
            }
        }

        public override IQueryFluent<ShoppingCart> Query(IQueryObject<ShoppingCart> queryObject)
        {
            return base.Query(queryObject).Include(x=>x.Product);
        }

        public AddShoppingCartResponse AddShoppingCart(AddShoppingCartRequest addShoppingCartRequest)
        {
            var result = new List<ValidationResult>();
            var response = new AddShoppingCartResponse();
            try
            {
                var validationResults = addShoppingCartRequest.Validate().ToList();
                if (validationResults.Any())
                {
                    response.ValidationResults = validationResults;
                    return response;
                }
                var customer = base.Queryable().Where(x => x.CustomerID == addShoppingCartRequest.CustomerID);
                if (customer == null)
                {
                    response.ValidationResults.Add(new ValidationResult(AppServiceShoppingCartBusinessRule.CustomerNotFoundForGivenId.RuleDescription));
                    return response;
                }

                var shoppingCart = _mappingService.Map<AddShoppingCartDto, ShoppingCart>(addShoppingCartRequest);
                base.Insert(shoppingCart);

                _unitOfWorkAsync.SaveChangesAsync();

                return response;
            }
            catch (Exception ex)
            {
                _log.Log(ex);
                throw;
            }
        }

        public UpdateShoppingCartResponse UpdateShoppingCart(UpdateShoppingCartRequest updateShoppingCartRequest)
        {
            var result = new List<ValidationResult>();
            var response = new UpdateShoppingCartResponse();
            try
            {

                var validationResults = updateShoppingCartRequest.Validate().ToList();
                if (validationResults.Any())
                {
                    response.ValidationResults = validationResults;
                    return response;
                }
                var customer = base.Queryable().Where(x => x.CustomerID == updateShoppingCartRequest.CustomerID);
                if (customer == null)
                {
                    response.ValidationResults.Add(new ValidationResult(AppServiceShoppingCartBusinessRule.CustomerNotFoundForGivenId.RuleDescription));
                    return response;
                }

                var cartList = base.Query(x => x.CustomerID == updateShoppingCartRequest.CustomerID).Select();

                foreach (var deletedCart in cartList.Where(p => !updateShoppingCartRequest.UpdateShoppingCartList.Any(l => p.ShoppingCartId == l.ShoppingCartId)))
                {
                    base.Delete(deletedCart.ShoppingCartId);
                }

                foreach (var updatedCart in cartList.Where(p => updateShoppingCartRequest.UpdateShoppingCartList.Any(l => p.ShoppingCartId == l.ShoppingCartId)))
                {
                    var cart = base.Find(updatedCart.ShoppingCartId);
                    cart.Quantity = (short)updateShoppingCartRequest.UpdateShoppingCartList.First(x => x.ShoppingCartId == updatedCart.ShoppingCartId).Quantity;
                    base.Update(cart);
                }

                _unitOfWorkAsync.SaveChanges();
                return response;
            }
            catch (Exception ex)
            {
                _unitOfWorkAsync.Rollback();
                _log.Log(ex);
                throw;
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            _unitOfWorkAsync.Dispose();
        }

        public ListShoppingCartResponse ListShoppingCart(ListShoppingCartRequest listShoppingCartRequest)
        {
            var result = new List<ValidationResult>();
            var response = new ListShoppingCartResponse();
            try
            {
                var validationResults = listShoppingCartRequest.Validate().ToList();
                if (validationResults.Any())
                {
                    response.ValidationResults = validationResults;
                    return response;
                }
                var customer = base.Queryable().Where(x => x.CustomerID == listShoppingCartRequest.CustomerID);
                if (customer == null)
                {
                    response.ValidationResults.Add(new ValidationResult(AppServiceShoppingCartBusinessRule.CustomerNotFoundForGivenId.RuleDescription));
                    return response;
                }

                var shoppingCartList = new List<ShoppingCartDto>();
                foreach (var x in base.Query(x => x.CustomerID == listShoppingCartRequest.CustomerID).Include(x => x.Product).Select())
                {
                    var shoppingCartDto = new ShoppingCartDto
                    {
                        ShoppingCartId = x.ShoppingCartId,
                        CustomerID = x.CustomerID,
                        EmployeeID = x.EmployeeID,
                        ProductID = x.ProductID,
                        OrderDate = x.OrderDate,
                        Quantity = x.Quantity
                    };

                    shoppingCartDto.AddProduct(_mappingService.Map<Product, ProductDto>(x.Product));
                    shoppingCartList.Add(shoppingCartDto);
                }
                return new ListShoppingCartResponse { ShoppingCartItems = shoppingCartList };
            }
            catch (Exception ex)
            {
                _log.Log(ex);
                throw;
            }
        }
    }
}

using ChennaiSarees.BusinessObjects.Messaging.Order;
using ChennaiSarees.BusinessObjects.Order;
using ChennaiSarees.BusinessObjects.OrderDetail;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.Service.BusinessRules;
using ChennaiSarees.Service.BusinessRules.Order;
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
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IRepositoryAsync<Order> _repository;
        private readonly IMappingService _mappingService;
        private readonly ILogRepository _log;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public OrderService(IRepositoryAsync<Order> repository, IUnitOfWorkAsync unitOfWorkAsync, IMappingService mappingService, ILogRepository logRepository)
            : base(repository)
        {
            if (repository == null) throw new ArgumentNullException("Repository");
            {
                _repository = repository;
            }
            if (unitOfWorkAsync == null) throw new ArgumentNullException("UnitOfWorkAsync");
            {
                _unitOfWorkAsync = unitOfWorkAsync;
            }
            if (logRepository == null) throw new ArgumentNullException("Log Repository");
            {
                _log = logRepository;
            }
            if (logRepository == null) throw new ArgumentNullException("Log Repository");
            {
                _mappingService = mappingService;
            }
        }

        public AddOrderResponse AddOrder(AddOrderRequest addOrderRequest)
        {
            var result = new List<ValidationResult>();
            var response = new AddOrderResponse();
            try
            {
                var validationResults = addOrderRequest.Validate().ToList();
                if (validationResults.Any())
                {
                    response.ValidationResults = validationResults;
                    return response;
                }
                var customer = base.Queryable().Where(x => x.CustomerID == addOrderRequest.CustomerID);
                if (customer == null)
                {
                    response.ValidationResults.Add(new ValidationResult(AppServiceOrderBusinessRule.CustomerNotFoundForGivenId.RuleDescription));
                    return response;
                }

                var order = _mappingService.Map<AddOrderDto, Order>(addOrderRequest);

                foreach(var orderDetailDto in addOrderRequest.OrderItems)
                {
                    var orderDetail = _mappingService.Map<AddOrderDetailDto, OrderDetail>(orderDetailDto);
                    orderDetail.ObjectState = ObjectState.Added;
                    order.OrderDetails.Add(orderDetail);
                }

                foreach (var orderDetail in order.OrderDetails)
                {
                    orderDetail.ObjectState = ObjectState.Added;
                }

                base.Insert(order);

                return response;
            }
            catch (Exception ex)
            {
                _log.Log(ex);
                throw;
            }
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        public override void Dispose()
        {
            if (_repository != null)
            {
                _repository.Dispose();
            }
            base.Dispose();
        }
    }
}

#region

using System.Collections.Generic;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Repository.Models;
using ChennaiSarees.Repository.Repositories;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Repository.Pattern.UnitOfWork;
using ChennaiSarees.Service.Implementation;
using ChennaiSarees.BusinessObjects.Customer;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using System;

#endregion

namespace ChennaiSarees.Service
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly IRepositoryAsync<Customer> _repository;
        private readonly IMappingService _mappingService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public CustomerService(IRepositoryAsync<Customer> repository, IUnitOfWorkAsync unitOfWorkAsync)
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
        }

        public decimal CustomerOrderTotalByYear(string customerId, int year)
        {
            // add business logic here
            return _repository.GetCustomerOrderTotalByYear(customerId, year);
        }

        public IEnumerable<CustomerDto> CustomersByCompany(string companyName)
        {
            // add business logic here
            var customers = _repository.CustomersByCompany(companyName);
            return _mappingService.Map<IEnumerable<Customer> , IEnumerable<CustomerDto>>(customers);
        }

        public override void Insert(Customer entity)
        {
            // e.g. add business logic here before inserting
            base.Insert(entity);
        }

        public override void Delete(object id)
        {
            // e.g. add business logic here before deleting
            base.Delete(id);
        }

        public override void Dispose()
        {
            if (_unitOfWorkAsync != null)
            {
                _unitOfWorkAsync.Dispose();
            }

            if (_repository != null)
            {
                _repository.Dispose();
            }
            base.Dispose();
        }
    }
}
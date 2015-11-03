using System.Collections.Generic;
using ChennaiSarees.Entities.Models;
using ChennaiSarees.Repository.Models;
using ChennaiSarees.Repository.Repositories;
using Repository.Pattern.Repositories;
using Service.Pattern;
using Repository.Pattern.UnitOfWork;
using ChennaiSarees.Service.Implementation;
using ChennaiSarees.BusinessObjects.Product;
using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using System;
using ChennaiSarees.Service.Interface;

namespace ChennaiSarees.Service.Implementation
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepositoryAsync<Product> _repository;
        private readonly IMappingService _mappingService;
        private readonly IUnitOfWorkAsync _unitOfWorkAsync;

        public ProductService(IRepositoryAsync<Product> repository, IUnitOfWorkAsync unitOfWorkAsync)
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

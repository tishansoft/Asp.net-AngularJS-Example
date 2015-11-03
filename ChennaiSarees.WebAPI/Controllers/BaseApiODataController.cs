using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Mvc;

namespace ChennaiSarees.WebAPI.Api
{
    [ExceptionHandlerFilter]
    public class BaseApiODataController : ODataController
    {
        protected readonly ILogRepository _logRepository;
        protected readonly IMappingService _mappingService;

        public BaseApiODataController(ILogRepository logRepository, IMappingService mappinService)
        {
            _logRepository = logRepository;
            _mappingService = mappinService;
        }
    }
}
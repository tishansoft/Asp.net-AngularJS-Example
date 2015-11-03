using ChennaiSarees.Infrastructure.Automapper;
using ChennaiSarees.Infrastructure.Logging;
using ChennaiSarees.WebAPI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChennaiSarees.WebAPI.Controllers
{
    [ExceptionHandlerFilter]
    public class BaseApiController : ApiController
    {
        protected readonly ILogRepository _logRepository;
        protected readonly IMappingService _mappingService;

        public BaseApiController(ILogRepository logRepository, IMappingService mappinService)
        {
            _logRepository = logRepository;
            _mappingService = mappinService;
        }

    }
}

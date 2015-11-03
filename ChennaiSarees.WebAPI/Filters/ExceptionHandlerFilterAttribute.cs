using ChennaiSarees.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;

namespace ChennaiSarees.WebAPI.Filters
{
    public class ExceptionHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public ExceptionHandlerFilterAttribute()
        {
            this.Mappings = new Dictionary<Type, HttpStatusCode>();
            this.Mappings.Add(typeof(ArgumentNullException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(ArgumentException), HttpStatusCode.BadRequest);
            this.Mappings.Add(typeof(HttpResponseException), HttpStatusCode.Conflict);
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception != null)
            {
                var _log = (ILogRepository)actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(typeof(ILogRepository));
                var exception = actionExecutedContext.Exception;

                //first log the exception into log table
                _log.Log(exception);
                if (actionExecutedContext.Exception is HttpException)
                {
                    var httpException = (HttpException)exception;
                    var resp = new HttpResponseMessage((HttpStatusCode)httpException.GetHttpCode())
                    {
                        Content = new StringContent(actionExecutedContext.Exception.Message),
                    };
                    throw new HttpResponseException(resp);
                }
                else if (actionExecutedContext.Exception is HttpResponseException)
                {
                    throw (actionExecutedContext.Exception);
                }
                else
                {
                    var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    {
                        Content = new StringContent(actionExecutedContext.Exception.Message),
                    };
                    throw new HttpResponseException(resp);
                }
            }
        }

        public IDictionary<Type, HttpStatusCode> Mappings
        {
            get;
            private set;
        }
    }
}
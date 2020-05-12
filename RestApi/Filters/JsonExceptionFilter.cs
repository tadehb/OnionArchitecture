using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Filters
{
    public class JsonExceptionFilter : IExceptionFilter
    {
        private readonly IHostingEnvironment _hostingEnviorment;

        public JsonExceptionFilter(IHostingEnvironment hostingEnviorment)
        {
            _hostingEnviorment = hostingEnviorment;
        }
        public void OnException(ExceptionContext context)
        {
            var error = new ApiErrors();

            if (_hostingEnviorment.IsDevelopment())
            {
                error.Message = context.Exception.Message;
                error.Details = context.Exception.StackTrace;
            }
            else
            {
                error.Message = "A server error occured.";
                error.Details = context.Exception.Message;
            }
         

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}

using System;
using System.Net;
using CleanWebApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanWebApi.WebApi.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var code = HttpStatusCode.InternalServerError;

            // Uncomment this switch to change the status code for custom exceptions.
            // switch (context.Exception)
            // {
            //     case NotFoundException _:
            //         code = HttpStatusCode.NotFound;
            //         break;
            // }

            // Log exception if it is a non-custom, unhandled exception
            if (code == HttpStatusCode.InternalServerError)
            {
                var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<CustomExceptionFilterAttribute>>();
                logger.LogError(context.Exception, "Internal server error occurred");
            }

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ErrorViewModel(context.Exception.Message));
        }
    }
}
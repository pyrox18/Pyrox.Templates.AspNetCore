using System;
using System.Net;
using CleanWebApi.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

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

            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;
            context.Result = new JsonResult(new ErrorViewModel(context.Exception.Message));
        }
    }
}
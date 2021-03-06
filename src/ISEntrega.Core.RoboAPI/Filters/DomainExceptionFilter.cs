﻿namespace ISEntrega.Core.RoboAPI.Filters
{
    using ISEntrega.Core.Domain;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Newtonsoft.Json;
    using System.Net;
    
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var domainException = context.Exception as DomainException;

            if (domainException != null)
            {
                var json = JsonConvert.SerializeObject(domainException.BusinessMessage);

                context.Result = new BadRequestObjectResult(json);                
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}

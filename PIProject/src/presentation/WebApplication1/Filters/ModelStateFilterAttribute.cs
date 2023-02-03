using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using RusMProject.Domain.Entities;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RusMProject.WebAPI.Filters
{
    public class ModelStateFilterAttribute : ResultFilterAttribute
    {
        private readonly IExceptionNotificationServiceAble ExceptionNotificationService;
        public ModelStateFilterAttribute(IExceptionNotificationServiceAble exceptionNotificationService)
        {
            ExceptionNotificationService = exceptionNotificationService;
        }
        public async override void OnResultExecuting(ResultExecutingContext context)
        {
            var modelState = context.ModelState;

            if (!modelState.IsValid)
            {
                var messageNames = new List<string>();
                var messageDescriptions = new List<string>();
                string errors = string.Empty;

                foreach (var e in modelState)
                {
                    var name = e.Value.Errors.FirstOrDefault().ErrorMessage;
                    var exception =ExceptionNotificationService.Get(name);
                    if(exception != null)
                    {
                        messageNames.Add(exception.Name);
                        messageDescriptions.Add(exception.Description);
                    }
                    else
                    {
                        messageNames.Add(e.Key);
                        messageDescriptions.Add(name);
                    }
                }
                for (int i = 0; i < messageNames.Count && messageNames!=null; i++)
                {
                    errors= "Error: "+messageNames[i]+" : "+ messageDescriptions[i]+"\n";
                }
                await context.HttpContext.Response.WriteAsync(errors);
            }
        }
    }
}

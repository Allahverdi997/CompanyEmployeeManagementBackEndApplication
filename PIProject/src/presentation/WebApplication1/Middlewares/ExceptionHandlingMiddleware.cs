using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace RusMProject.WebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        public IExceptionNotificationServiceAble ExceptionNotificationService { get; set; }
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next,IExceptionNotificationServiceAble exceptionNotificationService)
        {
            _next = next;
            ExceptionNotificationService=exceptionNotificationService;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var content = new object();
                string name = string.Empty;
                if (ex.GetType().IsSubclassOf(typeof(CustomException)))
                {
                    var exception = (CustomException)ex;
                    name = exception.Name;
                    var exceptionContent = ExceptionNotificationService.Get(name);

                    if(exceptionContent != null )
                        content = new { Key = name, Content = exceptionContent.Description, ExceptionMessage = string.Empty };
                    else
                        content= new { Key = name, Content = ex.Message, ExceptionMessage = string.Empty };
                }
                else
                    content = new { Key = name, Content = ex.Message, ExceptionMessage = string.Empty };
                var response = JsonConvert.SerializeObject(content);
                await context.Response.WriteAsync(response);
            }
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RusMProject.WebAPI.Filters
{
    public class UnhandledExceptionFilter : IExceptionFilter
    {
        private readonly IExceptionNotificationServiceAble ExceptionNotificationService;
        public UnhandledExceptionFilter(IExceptionNotificationServiceAble exceptionNotificationService)
        {
            ExceptionNotificationService = exceptionNotificationService;
        }
        public void OnException(ExceptionContext context)
        {
            var content = new object();
            string name = string.Empty;
            if (context.Exception.GetType().IsSubclassOf(typeof(CustomException)))
            {
                var exception = (CustomException)context.Exception;
                name = exception.Name;
                var exceptionContent = ExceptionNotificationService.Get(name);

                if (exceptionContent != null)
                    content = new { Key = name, Content = content, ExceptionMessage = context.Exception.InnerException.Message };
                else
                    content = new { Key = name, Content = context.Exception.Message, ExceptionMessage = context.Exception.InnerException.Message };
            }
            else
            {
                content = $"Exception:{context.Exception.InnerException.Message}";
            }
        }
    }
}

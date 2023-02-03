using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.IIS.Core;
using Newtonsoft.Json;
using RusMProject.WebAPI.Attributes;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Services;
using RusMProjectApplication.Exceptions;
using System.Net;
using System.Net.Mail;

namespace RusMProject.WebAPI.Filters
{
    public class AuthenticationFilter : IAuthorizationFilter
    {
        public readonly IExceptionNotificationServiceAble ExceptionNotificationService;
        private readonly IApplicationSettingsAble AppSettings;
        private readonly IFilterServiceAble FilterService;

        public AuthenticationFilter(IExceptionNotificationServiceAble exceptionNotificationService,
            IFilterServiceAble filterService,
            IApplicationSettingsAble appSettings)
        {
            ExceptionNotificationService = exceptionNotificationService;
            FilterService = filterService;
            AppSettings = appSettings;
        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                if (context.ActionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    var isDefined = controllerActionDescriptor.MethodInfo.GetCustomAttributes(inherit: true)
                        .Any(a => a.GetType().Equals(typeof(AnonymousUserAttribute)));

                    if (isDefined)
                        return;
                }

                HttpRequest request = context.HttpContext.Request;
                if (request.Headers["AuthenticationToken"] != string.Empty)
                {
                    var authorization = request.Headers["AuthenticationToken"];
                    FilterService.AuthenticateUser(authorization.ToString());
                }
                
            }
            catch (System.Exception ex)
            {
                var content = new object();
                string name = string.Empty;
                if (ex.GetType().IsSubclassOf(typeof(CustomException)))
                {
                    var exception = (CustomException)ex;
                    name = exception.Name;
                    var exceptionContent = ExceptionNotificationService.Get(name);

                    if (exceptionContent != null)
                        content = new { Key = name, Content = exceptionContent.Description, ExceptionMessage = string.Empty };
                    else
                        content = new { Key = name, Content = ex.Message, ExceptionMessage = string.Empty };
                }
                else
                    content = new { Key = name, Content = ex.Message, ExceptionMessage = string.Empty };
                var response = JsonConvert.SerializeObject(content);
                context.Result = ResponseGenerator.CreateResponse(HttpStatusCode.Unauthorized, content);
            }

        }
    }
}

using Castle.DynamicProxy;
using RusMPeoject.Infrastructure.Utilities.CrossCustingConcerns.Interceptors;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Logging
{
    public class LoggingAspect : MethodInterceptor
    {
        protected override void OnBefore(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            Log.Information($"{methodName} Method'a muraciet olundu.");
        }

        protected override void OnException(IInvocation invocation, Exception exception)
        {
            var methodName = invocation.Method.Name;
            Log.Information($"{methodName} Method'da xeta bas verdi.Exception: {exception.Message}");
        }
    }
}

using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RusMPeoject.Infrastructure.Utilities.CrossCustingConcerns.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            if(type.GetCustomAttribute<MethodInterceptionBaseAttribute>(true)!=null && type.GetMethod(method.Name).GetCustomAttribute<MethodInterceptionBaseAttribute>(true)!=null)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

                var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

                classAttributes.AddRange(methodAttributes);

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
            else
                return null;
        }
    }
}

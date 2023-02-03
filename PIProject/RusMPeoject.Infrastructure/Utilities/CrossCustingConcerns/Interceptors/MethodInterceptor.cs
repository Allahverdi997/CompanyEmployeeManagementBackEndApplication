using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMPeoject.Infrastructure.Utilities.CrossCustingConcerns.Interceptors
{
    public abstract class MethodInterceptor:MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation,Exception exception) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            OnBefore(invocation);
            try
            {
                
                invocation.Proceed();
                OnSuccess(invocation);
                OnAfter(invocation);
            }
            catch (Exception ex)
            {
                OnException(invocation, ex);
            } 
        }
    }
}

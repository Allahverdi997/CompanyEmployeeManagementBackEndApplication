using Castle.DynamicProxy;
using RusMPeoject.Infrastructure.Utilities.CrossCustingConcerns.Interceptors;
using RusMProject.Persistance.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RusMProject.Persistance.Utilities.CrossCustingConcerns.Aspects.Transaction
{
    public class TransactionAspect : MethodInterceptor
    {
        protected override void OnBefore(IInvocation invocation)
        {
                using(var tran=new TransactionScope())
                {
                    try
                    {
                        invocation.Proceed();
                        tran.Complete();
                    }
                    catch (Exception)
                    {
                        tran.Dispose();
                    }
                }
        }
    }
}

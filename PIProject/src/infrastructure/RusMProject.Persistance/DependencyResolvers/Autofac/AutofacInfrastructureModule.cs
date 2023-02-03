using Autofac;
using Autofac.Extras.DynamicProxy;
using RusMPeoject.Infrastructure.Utilities.CrossCustingConcerns.Interceptors;
using RusMProject.Infrastructure.Services;
using RusMProject.Persistance.Repositories.ApplicationRepositories.Read;
using RusMProject.Persistance.Repositories.ApplicationRepositories.Write;
using RusMProject.Persistance.Services;
using RusMProject.Persistance.UnitOfWorkFolder;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Read;
using RusMProjectApplication.Abstraction.Repositories.ApplicationRepositories.Write;
using RusMProjectApplication.Abstraction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RusMProject.Persistance.DependencyResolvers.Autofac
{
    public class AutofacInfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DepartmentReadRepository>().As<IDepartmentReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<DepartmentWriteRepository>().As<IDepartmentWriteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeReadRepository>().As<IEmployeeReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeWriteRepository>().As<IEmployeeWriteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExceptionNotificationReadRepository>().As<IExceptionNotificationReadRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExceptionNotificationWriteRepository>().As<IExceptionNotificationWriteRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ExceptionNotificationManager>().As<IExceptionNotificationServiceAble>().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAble>().SingleInstance();

            builder.RegisterType<FilterManager>().As<IFilterServiceAble>().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}

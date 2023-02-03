using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using RusMProject.Persistance.DbContextManager;
using RusMProject.Persistance.DependencyResolvers.Autofac;
using RusMProject.Persistance.UnitOfWorkFolder;
using RusMProject.WebAPI.Filters;
using RusMProject.WebAPI.Middlewares;
using RusMProject.WebAPI.Others;
using RusMProjectApplication.Abstraction;
using RusMProjectApplication.Statics;
using RusMProjectApplication.Validations;
using Serilog;

Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File("Loggs/FileLogger.txt")
                .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

//Adding controller support

builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.SetIsOriginAllowed(x => true)
            .AllowAnyMethod()
            .AllowAnyHeader());
});
builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(typeof(ModelStateFilterAttribute), 2);
    opt.Filters.Add(typeof(AuthenticationFilter), 1);
    //opt.Filters.Add(typeof(UnhandledExceptionFilter), 1);
})
.AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve)
.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<GeneralValidator>());
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SimaWebsite.WebAPI",
        Version = "v1"
    });
    c.OperationFilter<SwaggerHeaderFilter>();

});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacInfrastructureModule()));
DbContextRegistration.GenerateFromPersistance(builder.Services, builder.Configuration);
ServiceRegistrationFromApplication.GenerateStartupFromApplication(builder.Services,builder.Configuration);

builder.Services.AddScoped<IUnitOfWorkAble, UnitOfWork>();

builder.Services.AddHealthChecks();

// Configure the HTTP request pipeline.
var app = builder.Build();
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 v1"));
}
app.HealthCheck();
app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
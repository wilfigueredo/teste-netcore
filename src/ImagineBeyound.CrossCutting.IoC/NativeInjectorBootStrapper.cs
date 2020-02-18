using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using ImagineBeyond.Application.Customer.Interfaces;
using ImagineBeyond.Application.Customer.Services;
using ImagineBeyond.Domain.Interfaces.Repositories;
using ImagineBeyond.Repository.Repository;
using ImagineBeyond.Repository.Context;
using Microsoft.AspNetCore.Http;
using ImagineBeyond.Repository.UoW;

namespace ImagineBeyound.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            // ASP NET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // App
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Repository
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ImagineBeyondContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

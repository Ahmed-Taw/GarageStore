using Garage.Business.Infrastructure.Iservices;
using Garage.Business.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Business.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessLayerServices(this IServiceCollection services)
        {
            services.AddScoped<ICarService, CarService>();
        }
    }
}

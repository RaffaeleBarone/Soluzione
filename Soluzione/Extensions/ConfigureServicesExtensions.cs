using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Progetto1.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto1.Extensions
{
   public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddDbContextServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IStudenteManager, StudenteManager>();
            services.AddScoped<IEsameManager, EsameManager>();
            return services;

        }
    }
}

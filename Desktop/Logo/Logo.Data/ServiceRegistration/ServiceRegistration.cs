using Logo.Core.Repositories;
using Logo.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logo.Data.ServiceRegistration
{
    public  static class ServiceRegistration
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IFeatureRepository,FeatureRepository>();

        }
    }
}

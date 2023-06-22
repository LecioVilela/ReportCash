using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ReportCash.Core.Repo;
using ReportCash.Infrastructure.Repo;

namespace ReportCash.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();

            return services;
        }
    }
}
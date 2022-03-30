using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Programming.Core;

namespace Programming.Api.Extensions
{
    public static class ApiServiceExtension
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return services;
        }
    }
}

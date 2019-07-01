using GestorInventario.api.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Extensions
{
    public static class RepositoryInjectionModule
    {
        public static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IElementoRepository, ElementoRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            return services;
        }
    }
}

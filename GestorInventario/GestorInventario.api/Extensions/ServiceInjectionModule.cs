using GestorInventario.api.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorInventario.api.Extensions
{
    public static class ServiceInjectionModule
    {
        public static IServiceCollection InjectPersistence(this IServiceCollection services)
        {
            services.AddTransient<IElementoService, ElementoService>();
            services.AddTransient<IUsuarioService, UsuarioService>();
            return services;
        }
    }
}

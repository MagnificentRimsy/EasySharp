using EasySharp.Cache.Option;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Cache.Store.LocalStorage
{
    public static class LocalStorageExtension
    {
        public static IServiceCollection AddLocalStorage(this IServiceCollection services, IConfiguration Configuration)
        {
            var options = new Cacheable();
            Configuration.GetSection(nameof(Cacheable)).Bind(options);

            var localStorageOptions = options.LocalStorage ?? new LocalStorageOptions();

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddSingleton<IStorage, StorageService>();

            return services;
        }
    }
}

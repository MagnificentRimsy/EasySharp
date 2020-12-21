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
        public static IServiceCollection AddLocalStorage(this IServiceCollection services, IConfigurationRoot Configuration)
        {
            var options = new Cacheable();
            Configuration.GetSection(nameof(Cacheable)).Bind(options);

            var localStorageOptions = options.LocalStorage ?? new LocalStorageOptions();

            services.AddSingleton(Configuration);

            services.AddSingleton<IStorage, StorageService>();

            return services;
        }
    }
}

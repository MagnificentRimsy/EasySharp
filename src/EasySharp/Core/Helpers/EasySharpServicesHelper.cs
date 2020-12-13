using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Core.Helpers
{
    public static class EasySharpServicesHelper
    {
        private static IWebHostEnvironment _env;
        public static bool IsInitialized { get; private set; }

        static IServiceCollection _services = null;

        /// <summary>
        /// Provides static access to the framework's services provider
        /// </summary>
        public static IServiceCollection Services
        {
            get { return _services; }
            set
            {
                if (_services != null)
                {
                    throw new Exception("Can't set once a value has already been set.");
                }
                _services = value;
            }
        }

        //should be called once, no duplication
        public static void Initialize()
        {
            IServiceProvider serviceProvider = _services.BuildServiceProvider();
            IWebHostEnvironment env = serviceProvider.GetService<IWebHostEnvironment>();

            if (IsInitialized)
                throw new InvalidOperationException("Object already initialized");

            _env = env;
            IsInitialized = true;
        }

        public static IConfigurationRoot Builder() 
        {
            if (!IsInitialized)
                throw new InvalidOperationException("Object is not initialized");

            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{_env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}

using EasySharp.Core.AntiXss;
using EasySharp.Core.Cors;
using EasySharp.Core.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasySharp.Core
{
    public static class CoreExtensions
    {

        /// <summary>
        /// Application Configuration
        /// </summary>
        public static IConfigurationRoot Configuration { get; set; }

        public static IServiceCollection AddEasySharp(this IServiceCollection services, params Type[] types)
        {
            EasySharpServicesHelper.Services = services;

            if (EasySharpServicesHelper.IsInitialized == false)
            {
                EasySharpServicesHelper.Initialize();
            }

            Configuration = EasySharpServicesHelper.Builder();

            services.AddOptions();

            services
                .AddMvc();


            return services;
        }

        public static IApplicationBuilder UseEasySharp(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseAntiXssMiddleware(Configuration);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCorsOption();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            return app;
        }
    }
}

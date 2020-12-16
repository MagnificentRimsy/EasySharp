using EasySharp.Core.AntiXss;
using EasySharp.Core.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasySharp.Core
{
    public static class CoreExtensions
    {
        

        public static IServiceCollection AddEasySharp(this IServiceCollection services, params Type[] types)
        {
            services.AddOptions();

            services
                .AddMvc();


            return services;
        }

        public static IApplicationBuilder UseEasySharp(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseAntiXssMiddleware();
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

using EasySharp.Core.Cors;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasySharp.Core
{
    public static class CoreExtensions
    {
        

        public static IServiceCollection AddEasyCloud(this IServiceCollection services, params Type[] types)
        {
            services.AddOptions();

            services
                .AddMvc();


            return services;
        }

        public static IApplicationBuilder UseEasyCloud(this IApplicationBuilder app)
        {
            app.UseStaticFiles();
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

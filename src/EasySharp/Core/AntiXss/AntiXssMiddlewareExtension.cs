using EasySharp.Core.AntiXss.Info;
using EasySharp.Core.AntiXss.Option;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace EasySharp.Core.AntiXss
{
    public static class AntiXssMiddlewareExtension
    {
        //app.UseAntiXssMiddleware();
        public static IApplicationBuilder UseAntiXssMiddleware(this IApplicationBuilder builder)
        //public static IApplicationBuilder UseAntiXssMiddleware(this IApplicationBuilder builder, IConfiguration Configuration)
        {
            var servi = builder.ApplicationServices;
            servi.GetService();
            var options = new AntiXssOptions();
            Configuration.GetSection(nameof(AntiXssOptions)).Bind(options);

            var IsEnabled = (options.Enabled == true) ? true : false;

            if (IsEnabled)
            {
                return builder.UseMiddleware<AntiXssMiddleware>();
            }

            return builder;
        }
    }
}

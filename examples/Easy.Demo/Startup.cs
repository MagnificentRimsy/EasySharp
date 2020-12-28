using Easy.Demo.Data;
using Easy.Demo.Events;
using Easy.Demo.Interface;
using Easy.Demo.Repos;
using EasySharp.Cache;
using EasySharp.Core;
using EasySharp.Core.Cors;
using EasySharp.EfCore;
using EasySharp.EventStores;
using EasySharp.EventStores.Stores.EfCore;
using EasySharp.MessageBrokers;
using EasySharp.Outbox;
using EasySharp.Pagination;
using EasySharp.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Easy.Demo
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///  Configuration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddEasySharp(typeof(Startup), typeof(DataContext))
                .AddEfCore<DataContext>()
                .AddDocs()
                .AddCorsOption()
                .AddCacheable()
                .AddApiPagination()
                .AddMessageBroker()
                .AddOutbox();

            services.AddScoped<IEmployee, EmployeeRepo>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // UpdateDatabase(app);

            app
                .UseEasySharp()
                .UseDocs()
                .UseSubscribeEvent<EmployeeCreated>();
        }


        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<EfCoreEventStoreContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}

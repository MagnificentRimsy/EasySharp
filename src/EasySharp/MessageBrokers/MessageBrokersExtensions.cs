﻿using EasySharp.Core.Events;
using EasySharp.Core.Helpers;
using EasySharp.MessageBrokers.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EasySharp.MessageBrokers
{
    public static class MessageBrokersExtensions
    {
        public static IConfigurationRoot Configuration { get; set; }
        
        public static IServiceCollection AddMessageBroker(this IServiceCollection services)
        {
            Configuration = EasySharpServices.Builder();


            var options = new MessageBrokersOptions();
            Configuration.GetSection(nameof(MessageBrokersOptions)).Bind(options);
            services.Configure<MessageBrokersOptions>(Configuration.GetSection(nameof(MessageBrokersOptions)));

            if (options.Enable == false)
            {
                return services;
            }

            switch (options.MessageBrokerType.ToLowerInvariant())
            {
                case "rabbitmq":
                    return services.AddRabbitMQ(Configuration);
                default:
                    throw new Exception($"Message broker type '{options.MessageBrokerType}' is not supported");
            }
        }

        public static IApplicationBuilder UseSubscribeEvent<T>(this IApplicationBuilder app) where T : IEvent
        {
            app.ApplicationServices.GetRequiredService<IEventListener>().Subscribe<T>();

            return app;
        }

        public static IApplicationBuilder UseSubscribeEvent(this IApplicationBuilder app, Type type)
        {
            app.ApplicationServices.GetRequiredService<IEventListener>().Subscribe(type);

            return app;
        }
    }
}

using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using EasySharp.Swagger.Builders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace EasySharp.Swagger
{
    public static class SwaggerExtensions
    {
        private const string RegistryName = "docs.swagger";

        private static ConcurrentDictionary<string, bool> _registry = new ConcurrentDictionary<string, bool>();

        public static IServiceCollection AddDocs(this IServiceCollection services, IConfiguration Configuration)
        {

            var options = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(options);



            return services.AddSwaggerDocs(options);
        }

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services,
            Func<ISwaggerOptionsBuilder, ISwaggerOptionsBuilder> buildOptions)
        {
            var options = buildOptions(new SwaggerOptionsBuilder()).Build();
            return services.AddSwaggerDocs(options);
        }

        public static IServiceCollection AddSwaggerDocs(this IServiceCollection services, SwaggerOptions options)
        {

            var dt = _registry.TryAdd(RegistryName, true);

            if (!options.Enabled || !dt)
            {
                return services;
            }

            services.AddSingleton(options);

            Uri termsOfService = new Uri(options.TermsOfService);
            Uri contactUrl = new Uri(options.SecurityOptions.Contact.Url);
            Uri licenseUrl = new Uri(options.SecurityOptions.License.Url);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(options.Name, new OpenApiInfo
                {
                    Version = options.Name,
                    Title = options.Title,
                    Description = options.Description,
                    TermsOfService = termsOfService,
                    Contact = new OpenApiContact
                    {
                        Name = options.SecurityOptions.Contact.Name,
                        Email = options.SecurityOptions.Contact.Email,
                        Url = contactUrl,
                    },
                    License = new OpenApiLicense
                    {
                        Name = options.SecurityOptions.License.Name,
                        Url = licenseUrl
                    }
                });

                c.CustomSchemaIds(type => type.ToString());

                if (options.SecurityOptions.XmlDoc)
                {
                    //string baseDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";

                    //List<Assembly> usedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select((item) => Assembly.Load(item)).ToList();

                    ////var result = baseDirectory.Replace(baseDirectory + "\\", "");
                    ////baseDirectory = baseDirectory.Substring(0, baseDirectory.Length - 24);


                    //var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    //c.IncludeXmlComments(commentsFile);
                }

                if (options.IncludeSecurity)
                {
                    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                    {
                        Type = SecuritySchemeType.OAuth2,
                        Flows = new OpenApiOAuthFlows
                        {
                            AuthorizationCode = new OpenApiOAuthFlow
                            {
                                AuthorizationUrl = new Uri(options.SecurityOptions.AuthorityURL),
                                TokenUrl = new Uri(options.SecurityOptions.TokenUrl),
                                RefreshUrl = new Uri(options.SecurityOptions.TokenUrl),
                                Scopes = new Dictionary<string, string>
                                    {
                                        { options.SecurityOptions.Scope.Name, options.SecurityOptions.Scope.Description },
                                    }
                            }
                        }
                    });

                    c.OperationFilter<AuthorizeCheckOperationFilter>(options);
                }
            });

            if (options.IncludeSecurity)
            {
                services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                        .AddIdentityServerAuthentication(x =>
                        {
                            x.Authority = options.SecurityOptions.Authority;
                            x.ApiName = options.SecurityOptions.ApiName;
                            x.SupportedTokens = SupportedTokens.Both;
                            x.ApiSecret = options.SecurityOptions.ClientSecret;
                            x.RequireHttpsMetadata = bool.Parse(options.SecurityOptions.RequireHttpsMetadata);

                            x.SaveToken = true;
                            x.EnableCaching = true;
                            x.CacheDuration = TimeSpan.FromMinutes(10);

                        });
            }

            return services;
        }

        public static IApplicationBuilder UseDocs(this IApplicationBuilder app, IConfiguration Configuration)
        {
            var options = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(options);

            if (!options.Enabled)
            {
                return app;
            }

            var routePrefix = string.IsNullOrWhiteSpace(options.RoutePrefix) ? "swagger" : options.RoutePrefix;

            app.UseStaticFiles()
               .UseSwagger(c => c.RouteTemplate = routePrefix + "/{documentName}/swagger.json");


            return options.ReDocEnabled
                ? app.UseReDoc(c =>
                {
                    c.RoutePrefix = routePrefix;

                    if (options.SecurityOptions.Folder == "")
                    {
                        c.SpecUrl = $"{options.Name}/swagger.json";
                    }
                    else
                    {
                        c.SpecUrl = $"{options.SecurityOptions.Folder}/{options.Name}/swagger.json";

                    }
                })
                : app.UseSwaggerUI(c =>
                {
                    if (options.SecurityOptions.Folder == "")
                    {
                        c.SwaggerEndpoint($"/{routePrefix}/{options.Name}/swagger.json", options.Title);
                    }
                    else
                    {
                        c.SwaggerEndpoint($"/{options.SecurityOptions.Folder}/{routePrefix}/{options.Name}/swagger.json", options.Title);

                    }

                    c.RoutePrefix = routePrefix;

                    c.EnableDeepLinking();

                    // Additional OAuth settings
                    c.OAuthClientId(options.SecurityOptions.ApiId);
                    c.OAuthClientSecret(options.SecurityOptions.ClientSecret);
                    c.OAuthAppName(options.Description);
                    c.OAuthScopeSeparator(" ");
                    c.OAuthUsePkce();
                });
        }
    }
}

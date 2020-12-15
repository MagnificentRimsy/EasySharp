using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Swagger.Builders
{
    internal sealed class SwaggersBuilder : ISwaggerOptions
    {
        private readonly SwaggerOptions _options = new SwaggerOptions();

        public ISwaggerOptions Enable(bool enabled)
        {
            _options.Enabled = enabled;
            return this;
        }

        public ISwaggerOptions ReDocEnable(bool reDocEnabled)
        {
            _options.ReDocEnabled = reDocEnabled;
            return this;
        }

        public ISwaggerOptions WithName(string name)
        {
            _options.Name = name;
            return this;
        }

        public ISwaggerOptions WithTitle(string title)
        {
            _options.Title = title;
            return this;
        }

        public ISwaggerOptions WithVersion(string version)
        {
            _options.Version = version;
            return this;
        }

        public ISwaggerOptions WithRoutePrefix(string routePrefix)
        {
            _options.RoutePrefix = routePrefix;
            return this;
        }

        public ISwaggerOptions IncludeSecurity(bool includeSecurity)
        {
            _options.IncludeSecurity = includeSecurity;
            return this;
        }

        public SwaggerOptions Build() => _options;
    }
}

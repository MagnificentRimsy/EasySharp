using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Swagger.Helpers
{
    public interface ISwaggerOptions
    {
        ISwaggerOptions Enable(bool enabled);
        ISwaggerOptions ReDocEnable(bool reDocEnabled);
        ISwaggerOptions WithName(string name);
        ISwaggerOptions WithTitle(string title);
        ISwaggerOptions WithVersion(string version);
        ISwaggerOptions WithRoutePrefix(string routePrefix);
        ISwaggerOptions IncludeSecurity(bool includeSecurity);
        SwaggerOptions Build();
    }
}

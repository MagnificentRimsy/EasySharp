using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Core.Cors.Option
{
    public class CorsOptions
    {
        public bool Enabled { get; set; }
        public string Name { get; set; }

        public string[] Links { get; set; }
    }
}

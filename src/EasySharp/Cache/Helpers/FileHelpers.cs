using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EasySharp.Cache.Helpers
{
    internal static class FileHelpers
    {
        internal static string GetLocalStoreFilePath(string folder, string filename)
        {
            return Path.Combine(folder, filename);
            //return Path.Combine(System.AppContext.BaseDirectory, filename);
        }
    }
}

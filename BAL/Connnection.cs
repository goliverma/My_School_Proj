using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace BAL
{
    internal static class Connnection
    {
        internal static string Connection()
        {
            var con = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("connection.json", optional: false)
                .Build();
            return con.GetConnectionString("DataPath");
        }
    }
}

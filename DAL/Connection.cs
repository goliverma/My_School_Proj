using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
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

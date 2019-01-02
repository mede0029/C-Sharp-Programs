﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Lab7
{
    public class Config
    {
        public static string ConnectionString(string name)
        {
            string projectBase = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var builder = new ConfigurationBuilder()
                .SetBasePath(projectBase)
                .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            string connectionString = Configuration.GetConnectionString(name);
            return connectionString;
        }
    }
}

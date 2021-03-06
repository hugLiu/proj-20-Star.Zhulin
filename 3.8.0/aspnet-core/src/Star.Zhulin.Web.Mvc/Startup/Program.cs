﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Star.Zhulin.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://192.168.0.103:6002")
                .UseStartup<Startup>()
                .Build();
        }
    }
}

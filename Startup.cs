using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UserCRUD.FuncApp.Data;
using UserCRUD.FuncApp.Services;

[assembly: FunctionsStartup(typeof(UserCRUD.FuncApp.Startup))]

namespace UserCRUD.FuncApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var connectionString = 
                Environment.GetEnvironmentVariable("SqlServerConnection");
            builder.Services.AddDbContext<DataContext>(x =>
            {
                x.UseSqlServer(connectionString
                , options=>options.EnableRetryOnFailure());
            });

            builder.Services.AddTransient<ICRUDService, CRUDService>();

        }
    }
}
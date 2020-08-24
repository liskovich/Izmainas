using Izmainas.Data;
using Izmainas.Data.DataAccess;
using Izmainas.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRecordService, RecordService>();
            services.AddScoped<IRecordTempService, RecordTempService>();
            services.AddScoped<IEmailDataService, EmailDataService>();
            services.AddScoped<IEmailSendingService, EmailSendingService>();

            services.AddTransient<ISqlDataAccess, SqlDataAccess>();
            services.AddTransient<IMySqlDataAccess, MySqlDataAccess>();

            services.AddTransient<IRecordData, RecordData>();
            services.AddTransient<IRecordTempData, RecordTempData>();
            services.AddTransient<IEmailData, EmailData>();
        }
    }
}

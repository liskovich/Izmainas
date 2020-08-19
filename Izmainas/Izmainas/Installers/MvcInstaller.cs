﻿using Izmainas.ConfigOptions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Izmainas API", Version = "v1" });
            });

            services.Configure<EmailOptions>(configuration.GetSection(nameof(EmailOptions)));
            services.Configure<SmtpOptions>(configuration.GetSection(nameof(SmtpOptions)));
            services.Configure<ApplicationOptions>(configuration.GetSection(nameof(ApplicationOptions)));
        }
    }
}

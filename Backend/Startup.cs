using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using BioData.DbRepository;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BioData
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BioDataContext>();
            services.AddScoped<IBioDataRepository, BioDataRepository>();
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMvc(option => option.EnableEndpointRouting = false)
            .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("ApiCorsPolicy");
            app.UseMvc();
        }
    }
}
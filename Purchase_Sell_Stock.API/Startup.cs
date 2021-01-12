using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.DAL.GetDBHelper;

namespace Purchase_Sell_Stock.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DBHelper._locastr = Configuration["ConnectionStrings:connString"];
            services.AddControllers();
            services.AddTransient<ISet,SetBll>();
            services.AddTransient<PropertyBll>();
            //services.Add(new ServiceDescriptor(typeof(DBHelper),  DBHelper(Configuration["ConnectionString:locastr"])));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //AutoFac   IOC    JWT    this 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

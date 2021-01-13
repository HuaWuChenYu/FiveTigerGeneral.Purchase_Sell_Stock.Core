using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Purchase_Sell_Stock.API.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Services;
using Purchase_Sell_Stock.IServices;
using Purchase_Sell_Stock.Services;
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
            services.AddSingleton<IStorage, StorageBll>();
            DBHelper._locastr = Configuration["ConnectionString:locastr"];
            services.AddSwaggerSetup();
            services.AddSingleton<IGoods, GoodsBll>();
            services.AddTransient<ISet,SetBll>();
            services.AddControllers();
            //配置跨域处理，允许所有来源：
            services.AddCors(options =>
            {
                options.AddPolicy("any", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()   //必须写AllowAnyHeader否则前端掉不了 
                    //.AllowCredentials()//指定处理cookie
                .AllowAnyOrigin(); //允许任何来源的主机访问
                });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("any");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/V1/swagger.json", "Purchase_Sell_Stock.API V1");

                //·�����ã�����Ϊ�գ���ʾֱ���ڸ�������localhost:8001�����ʸ��ļ�,ע��localhost:8001/swagger�Ƿ��ʲ����ģ�ȥlaunchSettings.json��launchUrlȥ���������뻻һ��·����ֱ��д���ּ��ɣ�����ֱ��дc.RoutePrefix = "doc";
                c.RoutePrefix = "";
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

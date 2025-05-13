using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zhaoxi.SmartParking.Server.Start.GlobalRoute;

namespace Zhaoxi.SmartParking.Server.Start
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
            services.AddTransient<ICommon.IConfiguration, Common.Configration>();
            services.AddTransient<ICommon.IDbConnectionFactory, Common.DbConnectionFactory>();
            services.AddTransient<ICommon.IUtils, Common.Utils>();

            services.AddTransient<IService.IFileUpgradeService, Service.FileUpgradeService>();
            services.AddTransient<IService.ILoginService, Service.LoginService>();
            services.AddTransient<IService.IMenuService, Service.MenuService>();
            services.AddTransient<IService.IUserService, Service.UserService>();
            services.AddTransient<IService.IRoleService, Service.RoleService>();
            services.AddTransient<IService.IAutoRegisterService, Service.AutoRegisterService>();
            //20210315
            services.AddTransient<IService.IRecordService, Service.RecordService>();
            services.AddTransient<IService.IBillingService, Service.BillingService>();
            //20210320
            services.AddTransient<IService.IReportService, Service.ReportService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Zhaoxi.SmartParking.Server.Start", Version = "v1" });
            });

            services.Configure<FormOptions>(option =>
            {
                option.MultipartBoundaryLengthLimit = 1024 * 1024 * 1024;
                option.MultipartBodyLengthLimit = 1024 * 1024 * 1024;
            });

            services.AddMvc(opt =>
            {
                opt.UseCentralRoutePrefix(new RouteAttribute("api/v1/[controller]"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zhaoxi.SmartParking.Server.Start v1"));
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

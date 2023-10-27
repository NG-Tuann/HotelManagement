using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using HotelManagement.Models;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Repositories;
using HotelManagement.MiddleWares;
using HotelManagement.Services;

namespace HotelManagement
{
    public class Startup
    {
        private IConfiguration _configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Cau hinh cho doi tuong tra ve khong moc' noi' du lieu voi nhau qua dai
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Su dung session login logout
            services.AddSession();

            var connectionString = _configuration["ConnectionStrings:DefaultConnection"].ToString();
            services.AddDbContext<DatabaseContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));

            //inject repo
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //dependency inject
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IBookingDetailService, BookingDetailService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<IRoomTypeService, RoomTypeService>();
            services.AddScoped<ICheckOutService, CheckOutService>();
        }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseMiddleware<AuthenticationMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action}/{id?}"); 
            });
        }
    }
}

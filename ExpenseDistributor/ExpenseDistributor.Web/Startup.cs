using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseDistributor.Core.Controllers;
using ExpenseDistributor.DomainModel.Data;
using ExpenseDistributor.Repository.Expenses;
using ExpenseDistributor.Repository.Friends;
using ExpenseDistributor.Repository.Groups;
using ExpenseDistributor.Repository.Settlements;
using ExpenseDistributor.Repository.Users;
using ExpenseDistributor.Web.MappingProfiles;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ExpenseDistributor.Web
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin());
            });
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            //services.AddRazorPages();
            services.AddDbContextPool<DataContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DBCS")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ISettlementRepository, SettlementRepository>();
            //var a = Assembly.Load(typeof(ExpenseDistributor.Core));
            //var a = Assembly.GetAssembly(typeof(UserController));
            services.AddMvc();
                //.AddApplicationPart(a);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseExceptionHandler("/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapControllerRoute(
                //    name:"/User",
                //    pattern: "{controller=User}/{action=check}/{Id?}"
                //    );
                //endpoints.MapRazorPages();
            });
        }
    }
}

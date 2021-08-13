using Book.Data;
using Book.Interfaces;
using Book.Models;
using Book.Services;
using Book.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
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
            var getJwt = Configuration.GetSection("jwt").Get<JwtConfig>();

            services.AddSingleton(getJwt);
            services.AddScoped<ITokenService, TokenService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<DataContext>(d => d.UseSqlite(Configuration.GetConnectionString("sql")));
            
            services.AddIdentity<UserModel, IdentityRole>(i =>
             {
                 i.SignIn.RequireConfirmedEmail = false;
                 i.SignIn.RequireConfirmedAccount = false;
                 i.Lockout.AllowedForNewUsers = true;

             }).AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(c =>
            {
                c.LoginPath = "/user/login";
            });
            services.AddAuthentication().AddCookie(c => c.SlidingExpiration = true)
                .AddJwtBearer(j =>
                {
                    j.RequireHttpsMetadata = true;
                    j.SaveToken = true;
                   
                    j.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = getJwt.Issuer,
                        ValidateIssuerSigningKey = true,
                        ValidAudience = getJwt.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromHours(7),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(getJwt.Secret))
                    };
                });
            services.AddSession();
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

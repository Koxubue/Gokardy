using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gokardy.Encryptions;
using Gokardy.Models;
using Gokardy.Services.Classes;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Gokardy
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
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                                                                    .AllowAnyMethod()
                                                                    .AllowAnyHeader()
                                                                    .AllowCredentials()
                                                                    .Build());
            });
            services.AddControllers();
            services.AddTransient<ILoginKierowcaService, LoginKierowcaService>();
            services.AddTransient<IEncryption, Encryption>();
            services.AddTransient<IUzytkownikService, UzytkownikService>();
            services.AddTransient<IZarzadzajTorService, ZarzadzajTorService>();
            services.AddTransient<IZarzadajKierowcaService, ZarzadzajKierowcaService>();
            services.AddTransient<IZarzadzajGokardService, ZarzadzajGokardService>();
            services.AddTransient<IZarzadzajPracownikService, ZarzadzajPracownikService>();
            services.AddDbContext<GokardyContext>(options =>
            {
                options.UseSqlServer(@"Data Source=(Localdb)\MSSQLLocalDB; Initial Catalog=Gokardy;Integrated Security=True");
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = null,
                        ValidAudience = null,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

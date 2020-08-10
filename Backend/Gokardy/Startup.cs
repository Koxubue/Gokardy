using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gokardy.Models;
using Gokardy.Services.Classes;
using Gokardy.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
            services.AddControllers();
            services.AddTransient<IZarzadzajUzytkownikService, ZarzadzajUzytkownikService>();
            services.AddTransient<IZarzadzajTorService, ZarzadzajTorService>();
            services.AddTransient<IZarzadajKierowcaService, ZarzadzajKierowcaService>();
            services.AddDbContext<GokardyContext>(options =>
            {
                options.UseSqlServer(@"Data Source=(Localdb)\MSSQLLocalDB; Initial Catalog=Gokardy;Integrated Security=True");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

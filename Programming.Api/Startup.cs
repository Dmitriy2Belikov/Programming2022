using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Programming.Api.Extensions;
using Programming.Core;
using Programming.Infrastructure.Extensions;
using Programming.Infrastructure.Mapping;

namespace Programming.Api
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
            // db context
            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // business logic services
            services.AddInfrastructureServices();

            // api services
            services.AddApiServices();

            // other
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Programming.Api", Version = "v1" });
            });

            services.AddAutoMapper(x =>
            {
                x.AddProfile<MapProjectProfile>();
                x.AddProfile<MapTeamProfile>();
                x.AddProfile<MapDeveloperProfile>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Programming.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

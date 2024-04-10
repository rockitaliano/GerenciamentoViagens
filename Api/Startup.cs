using Domain.Interfaces;
using Infrastructure.Context;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Globalization;

namespace Api
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
            services.AddDbContext<DataContext>(opt =>
               opt.UseSqlServer(Configuration.GetConnectionString("Api")));
            services.AddHttpClient();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<IMotoristaService, MotoristaService>();
            services.AddScoped<IViagemService, ViagemService>();
            services.AddScoped<IViagemRepository, ViagemRepository>();

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    var dateConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                    {
                        DateTimeFormat = "dd'-'MM'-'yyyy'T'HH':'mm"
                    };

                    options.SerializerSettings.Converters.Add(dateConverter);
                    options.SerializerSettings.Culture = new CultureInfo("en-IE");
                    options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciamentoViagensApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciamentoViagensApi v1"));
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
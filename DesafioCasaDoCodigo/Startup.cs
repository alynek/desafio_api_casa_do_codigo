using DesafioCasaDoCodigo.Data;
using DesafioCasaDoCodigo.Repositories;
using DesafioCasaDoCodigo.Repositories.Interfaces;
using DesafioCasaDoCodigo.Services;
using DesafioCasaDoCodigo.Services.Interfaces;
using DesafioCasaDoCodigo.Utility;
using DesafioCasaDoCodigo.Utility.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace DesafioCasaDoCodigo
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
            services.AddDbContext<DesafioContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("Connection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Desafio Casa Do Codigo", Version = "v1" });
            });

            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IUploader, Uploader>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<ICompraRepository, CompraRepository>();
            services.AddScoped<ICupomRepository, CupomRepository>();
            services.AddScoped<IPagamentoPaypalRepository, PagamentoPaypalRepository>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ITentativaPagamentoService, TentativaPagamentoService>();
            services.AddScoped<Cookies>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Casa Do Codigo");
            });
        }
    }
}

using Holtz_PDV.Data;
using Holtz_PDV.Models;
using Holtz_PDV.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using ReflectionIT.Mvc.Paging;

namespace Holtz_PDV
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential 
                // cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                // requires using Microsoft.AspNetCore.Http;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddControllersWithViews();
            //Install-Package Pomelo.EntityFrameworkCore.MySql
            services.AddDbContext<Holtz_PDVContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SQLServer"))//appsettings.json
            /*, ServiceLifetime.Transient*/); //para resolver dupla instância do context
                                              //options.UseMySql(Configuration.GetConnectionString("MySql"), builder => builder.MigrationsAssembly("Holtz_PDV")));


            //inject interface
            services.AddScoped<IEFCore, EFCoreRepo>();

            services.AddPaging(options =>
            {
                options.ViewName = "Bootstrap5";
                options.HtmlIndicatorDown = " <span>&darr;</span>";
                options.HtmlIndicatorUp = " <span>&uarr;</span>";
            }); //ReflectionIT.Mvc.Paging;

            //Injeção de serviços : services
            services.AddScoped<SeedingService>();
            services.AddScoped<ClienteService>();
            services.AddScoped<CidadeService>();
            services.AddScoped<EstadoService>();
            services.AddScoped<ProdutoService>();
            services.AddScoped<MarcaService>();
            services.AddScoped<PedidoService>();

            services.AddAutoMapper(typeof(Startup));
            services.AddCors(options => options.AddDefaultPolicy(builder => builder.WithOrigins("https://localhost:44379/").AllowAnyHeader().AllowAnyMethod()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment()) //Desenvolvimento
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed(); //Popular o banco de dados
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

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

﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Evento.UI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Evento.Domain.Interfaces.Repository;
using Evento.Infra.Repository;
using Evento.Infra.Data;
using Evento.Domain.Services;
using Evento.Domain.Interfaces.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Evento.UI
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

            //copie a partit daqui
            //var cultureInfo = new CultureInfo("pt-BR");
            //cultureInfo.NumberFormat.CurrencySymbol = "R$";

            //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            //copie até aqui            

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<Contexto>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            ///////////////////////////////////////////////////////

            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddSingleton<ICategoriaRepository, CategoriaRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<IDependenteRepository, DependenteRepository>();
            services.AddSingleton<IEventoRepository, EventoRepository>();
            services.AddSingleton<IInscricaoRepository, InscricaoRepository>();

            // SERVIÇO DOMINIO
            services.AddSingleton(typeof(IServiceBase<>), typeof(ServiceBase<>));
            services.AddSingleton<ICategoriaService, CategoriaService>();
            services.AddSingleton<IClienteService, ClienteService>();
            services.AddSingleton<IDependenteService, DependenteService>();
            services.AddSingleton<IEventoService, EventoService>();
            services.AddSingleton<IInscricaoService, InscricaoService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            // Definindo a cultura padrão: pt-BR
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }     

    public static class StartupExtesions
    {
        private const string Culture = "pt-BR";

        public static IServiceCollection ConfigureCuturePtBR(this IServiceCollection services)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo(Culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo(Culture);
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(Culture);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(Culture);

            return services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(Culture);
                options.SupportedCultures = new List<CultureInfo> { new CultureInfo(Culture) };
                options.RequestCultureProviders.Clear();
            });
        }
    }
}
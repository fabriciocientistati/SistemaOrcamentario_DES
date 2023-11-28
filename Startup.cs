using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaOrcamentario.Context;
using SistemaOrcamentario.Helper;
using SistemaOrcamentario.Models;
using SistemaOrcamentario.Services;

namespace SistemaOrcamentario
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<DataContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddSingleton <IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<IEmail, Email>();
            services.AddScoped<IService<UsuarioModel>, UsuarioService>();
            services.AddScoped<IService<PessoaModel>, PessoaService>();
            services.AddScoped<IService<OrcamentoModel>, OrcamentoService>();

            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}

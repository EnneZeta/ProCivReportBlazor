using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.JSInterop;
using ProCivReport.Data;
using ProCivReport.PdfBuilder;
using ProCivReport.Services;

namespace ProCivReport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            //var x = WebAssemblyHostBuilder.CreateDefault();
            //var j = x.HostEnvironment.BaseAddress;
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<Persistency>();
            services.AddScoped<ToastService>();
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:32365/") }); //TODO: Mettere parametrico http://localhost:5000/ http://localhost:32365/ http://vpccalderara-001-site1.etempurl.com
            services.AddSingleton<IRepo>(_ =>
                new Repo(""));
            services.AddSingleton<ServiceReportBuilder>();
            services.AddSingleton<LightingBreakdownsBuilder>();
            services.AddSingleton<PathBuilder>();
            services.AddSingleton<IMailSender, MailSender>();
            services.AddMvc(options => options.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseMvcWithDefaultRoute();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}

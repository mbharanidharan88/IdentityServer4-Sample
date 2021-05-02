using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace IdentityServer
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // var fileName = Path.Combine("key.pem");

            // if (!File.Exists(fileName))
            // {
            //     throw new FileNotFoundException("Signing Certificate is missing!");
            // }

            // var cert = new X509Certificate2(Encoding.UTF8.GetBytes(fileName), "Admin$1234");
            // var secKey = new X509SecurityKey(cert);
            // signingKeys.Add(secKey);
        
            services.AddControllersWithViews();
            services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            //.AddSigningCredential(cert)
            .AddInMemoryApiScopes(Configurations.ApiScopes())
            .AddInMemoryApiResources(Configurations.ApiResources())
            .AddInMemoryClients(Configurations.Clients())
            .AddTestUsers(Configurations.Users().ToList());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseIdentityServer();
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         await context.Response.WriteAsync("Hello World!");
            //     });
            // });

            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}

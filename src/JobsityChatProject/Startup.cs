using JobsityChatProject.Core.AuthManager;
using JobsityChatProject.Core.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using JobsityChatProject.Infrastructure.DataBaseContext;
using Microsoft.AspNetCore.Identity;
using JobsityChatProject.Core.Models;
using JobsityChatProject.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;

namespace JobsityChatProject
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
            services.AddCors();
            services.AddControllers();

            /*Add all Scoped dependencies to repositories(repository pattern and IoC pattern)
            providing reusability instead of add each dependency manually. Do the same for services*/

            services.ResolveRepositoryScopedDependencies();
            services.ResolveServicesScopedDependencies();

            var key = Encoding.ASCII.GetBytes(TokenSecret.Secret);
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Home";
                    options.LogoutPath = "/Index";
                    options.Cookie.Name = "ChatCookie";
                });

            services.AddDbContext<JobsityChatContext>(opt => opt.UseInMemoryDatabase("JobsityChatDatabase"));

            services.AddRazorPages();

            services.AddSignalR();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<GeneralChatHub>("/chat");
            });
        }
    }
}

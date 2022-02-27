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
using JobsityChatProject.TestData;

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

            //Add all Scoped dependencies to repositories(repository pattern and IoC pattern) providing reusability instead of add each dependency manually
            services.ResolveRepositoryScopedDependencies();

            var key = Encoding.ASCII.GetBytes(TokenSecret.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddDbContext<JobsityChatContext>(opt => opt.UseInMemoryDatabase("JobsityChatDatabase"));

            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<JobsityChatContext>()
                    .AddDefaultTokenProviders();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<GeneralChatHub>("/chat");
            });
        }
    }
}

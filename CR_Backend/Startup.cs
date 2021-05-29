using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;
using DataBaseConfig;
using Microsoft.IdentityModel.Tokens;    
using Microsoft.AspNetCore.Authentication.JwtBearer;    
using System.Text;

namespace CR_Backend
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
            // JWT
            SetupJWTServices(services);  
            services.AddControllers();

            string dataBasePath = Path.Combine("..", "CalshRoyale.db");
            services.AddDbContext<ClashRoyaleDB>(options => options.UseSqlite($"Data Source={dataBasePath}"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CR_Backend", Version = "v1" });
            });
        }

        private void SetupJWTServices(IServiceCollection services)  
        {  
            string key = "my_secret_key_12345"; //this should be same which is used while creating token      
            var issuer = "http://localhost:5000";  //this should be same which is used while creating token  
  
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)  
          .AddJwtBearer(options =>  
          {  
              options.TokenValidationParameters = new TokenValidationParameters  
              {  
                  ValidateIssuer = true,  
                  ValidateAudience = true,  
                  ValidateIssuerSigningKey = true,  
                  ValidIssuer = issuer,  
                  ValidAudience = issuer,  
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))  
              };  
  
              options.Events = new JwtBearerEvents  
              {  
                  OnAuthenticationFailed = context =>  
                  {  
                      if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))  
                      {  
                          context.Response.Headers.Add("Token-Expired", "true");  
                      }  
                      return Task.CompletedTask;  
                  }  
              };  
          });  
        } 

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CR_Backend v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();  
            app.UseAuthorization();  

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

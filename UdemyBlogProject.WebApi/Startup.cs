using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using UdemyBlogProject.BusinessLayer.Containers.MicrosoftIOC;
using UdemyBlogProject.BusinessLayer.StringInfos;

namespace UdemyBlogProject.WebApi
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
            services.AddAutoMapper(typeof(Startup));
            services.AddDependencies();
            //
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt=> {
                    //�u an ssl sertifikam�z olmad��� i�in bearer token �n g�venlik sertifikias�n� false yapt�k
                    opt.RequireHttpsMetadata = false;
                    //Token �n validasyon parametrelerini yazal�m
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //Token � hangi server olu��turur
                        ValidIssuer = JWTStrings.Issuer,
                        //Token � kim t�ketir
                        ValidAudience = JWTStrings.Audience,
                        //G�venlik anahtar�m�z�n decode edilmesi
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTStrings.SecurityKey)),
                        //Token ya�am s�resi bitti�inde token� ge�ersiz k�lar
                        ValidateLifetime=true,
                        //Token � kullanacak portu kontrol eder
                        ValidateAudience=true,
                        //Token � olu�turan portu kontrol eder
                        ValidateIssuer=true,
                        //�stekte bulunan makine ile deploy edilen server aras�nda zaman fark� var ise bu zaman fark�n� ortadan kald�r�r
                        ClockSkew=TimeSpan.Zero

                    };

                }
                );



            services.AddControllers().AddNewtonsoftJson(opt=> {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

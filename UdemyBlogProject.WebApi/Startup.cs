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
using UdemyBlogProject.WebApi.CustomFilters;

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
            services.AddScoped(typeof(ValidId<>));
            services.AddDependencies();
            //
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                opt=> {
                    //Þu an ssl sertifikamýz olmadýðý için bearer token ýn güvenlik sertifikiasýný false yaptýk
                    opt.RequireHttpsMetadata = false;
                    //Token ýn validasyon parametrelerini yazalým
                    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        //Token ý hangi server oluýþturur
                        ValidIssuer = JWTStrings.Issuer,
                        //Token ý kim tüketir
                        ValidAudience = JWTStrings.Audience,
                        //Güvenlik anahtarýmýzýn decode edilmesi
                        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTStrings.SecurityKey)),
                        //Token yaþam süresi bittiðinde tokený geçersiz kýlar
                        ValidateLifetime=true,
                        //Token ý kullanacak portu kontrol eder
                        ValidateAudience=true,
                        //Token ý oluþturan portu kontrol eder
                        ValidateIssuer=true,
                        //Ýstekte bulunan makine ile deploy edilen server arasýnda zaman farký var ise bu zaman farkýný ortadan kaldýrýr
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

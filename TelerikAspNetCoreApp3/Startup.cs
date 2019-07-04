using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Northwind.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add connectionstring 
            services.AddSingleton(_ => Configuration);

            services.AddProjectService();


            // Add framework services.
            services
                .AddMvc(t => 
                {
                    //NamespaceRoutingConvention namespaceRoutingConvention = new NamespaceRoutingConvention("Northwind");
                    //t.Conventions.Add(namespaceRoutingConvention);

                    int a = 0;
                })
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_2)
                // Maintain property names during serialization. See:
                // https://github.com/aspnet/Announcements/issues/194
                .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            // var tokenEndpoint = Configuration.GetSection("TokenEndpoint");

            // services.AddMvcCore(options =>
            // {
            //     options.Filters.Add(new AuthorizeFilter(ScopePolicy.Create(tokenEndpoint["ApiName"])));
            // })
            //.AddAuthorization();

            // services.AddAuthentication(options =>
            // {
            //     options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //     options.DefaultChallengeScheme = "oidc";
            // })
            //     .AddCookie(options =>
            //     {
            //         options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            //         options.Cookie.Name = tokenEndpoint["ApiName"];
            //     })
            //     .AddOpenIdConnect("oidc", options =>
            //     {
            //         options.Authority = tokenEndpoint["Url"];
            //         options.RequireHttpsMetadata = false;
            //         options.SignedOutRedirectUri = tokenEndpoint["SiteUrl"];

            //         options.Events.OnRedirectToIdentityProvider = async context =>
            //         {
            //             context.ProtocolMessage.RedirectUri = tokenEndpoint["SiteUrl"];
            //             await Task.FromResult(0);
            //         };

            //         options.ClientId = tokenEndpoint["ApiName"];

            //         options.ResponseType = "id_token token";

            //         options.Scope.Clear();
            //         options.Scope.Add("openid");
            //         options.Scope.Add("profile");
            //         options.Scope.Add("c3po_dataprovider_svc");
            //         options.Scope.Add("c3_auth_svc");

            //         options.ClaimActions.MapAllExcept("iss", "nbf", "exp", "aud", "nonce", "iat", "c_hash");
            //         //options.ClaimActions.MapAll();


            //         options.GetClaimsFromUserInfoEndpoint = true;
            //         options.SaveTokens = true;

            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             NameClaimType = JwtClaimTypes.Name,
            //             RoleClaimType = JwtClaimTypes.Role,
            //         };
            //     });


            // Add Kendo UI services to the services container
            services.AddKendo();

            // Add Mobin services to the services container
            services.AddMobin();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.XForwardedFor 
            //    | Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{area=Nortwind}/{controller=PersianDate}/{action=Index}/{id?}");
            //});


            app.UseMvc(routes =>
            {
                routes.MapAreaRoute("northwind", "Northwind", "Northwind/{controller}/{action}/{id?}",
                    defaults: new { area = "Northwind" }, constraints: new { area = "Northwind" });

                routes.MapAreaRoute("bus", "Bus", "Bus/{controller}/{action}/{id?}",
                    defaults: new { area = "Bus" }, constraints: new { area = "Bus" });

                routes.MapRoute("default", "{controller}/{action}/{id?}",
                    defaults: new { controller = "PersianDate", action = "Index" });
            });

        }
    }
}
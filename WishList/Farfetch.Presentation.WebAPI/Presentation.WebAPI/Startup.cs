using Farfetch.Application.Service;
using Farfetch.Data.Repository;
using Farfetch.Data.Repository.Interface;
using Farfetch.Domain.Core.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Farfetch.Presentation.WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        private const string _apiVersion = "v1";
        private const string _apiTitle = "The wish list";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<CassandraContext>(new CassandraContext(Configuration));

            //add to scope the interface
            services.AddScoped<IWishListData, WishListData>();
            services.AddScoped<IWishListItemData, WishListItemData>();

            //add to scope the service
            services.AddScoped<WishListApplicationService>();
            services.AddScoped<WishListItemApplicationService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //swagger
            services.AddSwaggerGen
            (
                options =>
                {
                    var info = new Info
                    {
                        Title = _apiTitle,
                        Version = _apiVersion
                    };

                    options.SwaggerDoc(_apiVersion, info);
                    options.DescribeAllEnumsAsStrings();
                }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {          
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //enable middleware to server generate swagger as a json point
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", _apiTitle);
            });
          
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("No such route is found for this url! Please, access the localhost with the port to see the swagger.");
            });
        }
    }
}

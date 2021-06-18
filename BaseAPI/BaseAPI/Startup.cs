using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FrameWork.Installer;
using FrameWork.Options;

namespace BaseAPI
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
            //install every thing from configuration project & installer folder
            services.InstallerServiceInAssembly(Configuration);

            //services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            #region CheckDevelopment
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            #endregion

            #region HttpsRedirection
            app.UseHttpsRedirection();
            #endregion

            #region Routing
            app.UseRouting();
            #endregion

            #region StaticFiles
            app.UseStaticFiles();
            #endregion

            #region AuthenticationAndAuthorization
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            #region swagger
            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);
            app.UseSwagger(option =>
            {
                option.RouteTemplate = swaggerOptions.JsonRoute;
            });
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });
            #endregion

            #region Controllers
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            #endregion

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapRazorPages();
            //});



        }
    }
}

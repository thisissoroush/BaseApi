using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BaseAPI.Services.v1;
using BaseAPI.Services.v1.Google;

namespace FrameWork.Installer
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            //to get request ip
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //custom service
            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IGoogleService, GoogleService>();

        }
    }
}
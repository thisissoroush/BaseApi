using FrameWork.Installer;
using FrameWork.Util.Caching;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace BaseAPI.Installer
{
    public class CacheInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {

            #region Redis
            //using this shit need redis service
            //var redisCachSettings = new RedisCacheSettings();
            //configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCachSettings);
            //services.AddSingleton(redisCachSettings);

            //if (!redisCachSettings.Enabled)
            //{
            //    return;
            //}

            //services.AddDistributedRedisCache(options => options.Configuration = redisCachSettings.ConnectionString);
            #endregion

            #region MemoryCache
            services.AddMemoryCache();
            #endregion
        }
    }
}

using FrameWork.DAL.ConnectionString;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrameWork.DAL.DapperSQl;

namespace FrameWork.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnector, DbConnector>();
            services.AddSingleton(typeof(IDapper<>), typeof(Dapper<>));
        }
    }
}
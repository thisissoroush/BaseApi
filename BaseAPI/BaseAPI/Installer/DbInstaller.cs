using FrameWork.DAL.ConnectionString;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FrameWork.DAL.DapperSQl;
using FrameWork.DAL.EF.Repositories;
using FrameWork.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace FrameWork.Installer
{
    public class DbInstaller : IInstaller
    {
        public void InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnector, DbConnector>();
            services.AddSingleton(typeof(IDapper<>), typeof(Dapper<>));
            services.AddDbContext<BaseDBContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
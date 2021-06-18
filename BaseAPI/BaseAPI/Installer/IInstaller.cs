using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrameWork.Installer
{
    public interface IInstaller
    {
        void InstallerService(IServiceCollection services, IConfiguration configuration);
    }
}

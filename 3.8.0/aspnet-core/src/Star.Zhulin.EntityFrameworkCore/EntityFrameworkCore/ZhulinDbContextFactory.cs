using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Star.Zhulin.Configuration;
using Star.Zhulin.Web;

namespace Star.Zhulin.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ZhulinDbContextFactory : IDesignTimeDbContextFactory<ZhulinDbContext>
    {
        public ZhulinDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ZhulinDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ZhulinDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ZhulinConsts.ConnectionStringName));

            return new ZhulinDbContext(builder.Options);
        }
    }
}

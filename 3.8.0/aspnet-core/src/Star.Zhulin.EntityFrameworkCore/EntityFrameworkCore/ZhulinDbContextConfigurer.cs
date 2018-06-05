using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Star.Zhulin.EntityFrameworkCore
{
    public static class ZhulinDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ZhulinDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ZhulinDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

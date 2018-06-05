using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Star.Zhulin.Authorization.Roles;
using Star.Zhulin.Authorization.Users;
using Star.Zhulin.MultiTenancy;
using Star.Zhulin.Tasks;
using Star.Zhulin.Videos;
using Star.Zhulin.Albums;

namespace Star.Zhulin.EntityFrameworkCore
{
    public class ZhulinDbContext : AbpZeroDbContext<Tenant, Role, User, ZhulinDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Video> Video { get; set; }
        public DbSet<Album> Album { get; set; }

        public ZhulinDbContext(DbContextOptions<ZhulinDbContext> options)
            : base(options)
        {
        }
    }
}

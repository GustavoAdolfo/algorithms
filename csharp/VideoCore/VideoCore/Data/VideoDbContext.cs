
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoCore.Entities;

namespace VideoCore.Data
{
    public class VideoDbContext : IdentityDbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<User> Users { get; set; }

        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

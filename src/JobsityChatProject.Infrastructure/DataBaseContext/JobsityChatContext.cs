using JobsityChatProject.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace JobsityChatProject.Infrastructure.DataBaseContext
{
    public class JobsityChatContext : DbContext
    {
       
            public JobsityChatContext(DbContextOptions<JobsityChatContext> options)
              : base(options)
            { }
            public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

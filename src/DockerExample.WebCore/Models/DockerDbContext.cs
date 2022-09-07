using Microsoft.EntityFrameworkCore;

namespace DockerExample.WebCore.Models
{
    public class DockerDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }

        public DockerDbContext(DbContextOptions<DockerDbContext> options) : base(options)
        {
        }
    }
}

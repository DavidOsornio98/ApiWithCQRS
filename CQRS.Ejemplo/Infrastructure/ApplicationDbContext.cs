using CQRS.Ejemplo.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Ejemplo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<TaskItem> TaskItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}

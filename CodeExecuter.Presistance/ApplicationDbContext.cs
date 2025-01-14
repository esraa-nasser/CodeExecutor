using CodeExecuter.Application.Common.Interfaces;
using CodeExecuter.Application.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeExecuter.Presistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Code> Codes { get ; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

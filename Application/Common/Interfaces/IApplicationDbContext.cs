using Microsoft.EntityFrameworkCore;

namespace CodeExecuter.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Code> Codes { get; set; }
        int SaveChanges();
    }
}

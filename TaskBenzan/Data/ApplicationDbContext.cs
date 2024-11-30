using TaskBenzan.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TaskBenzan.Data;

public interface IApplicationDbContext
{
    #region Tablas
    DbSet<Cliente> Clientes { get; set; }
    #endregion

    #region Componentes propios de DbContext
    DatabaseFacade Database { get; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    #endregion Componentes propios de DbContext
}

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options), IApplicationDbContext
{
    #region Tablas de mi base de datos
    public virtual DbSet<Cliente> Clientes { get; set; } = null!;

    #endregion

    #region Metodos del contexto de base de datos
    public override int SaveChanges()
    {
        return base.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
    public override DatabaseFacade Database => base.Database;
    #endregion
}

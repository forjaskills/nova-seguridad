using Microsoft.EntityFrameworkCore;

namespace Nova.Seguridad.Adaptadores.Gateways;

/// <summary>Acceso a la base del servicio. Las tablas las crean los scripts de bd/ (Migrador), no EF.</summary>
public sealed class SeguridadDbContext(DbContextOptions<SeguridadDbContext> opciones) : DbContext(opciones)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SeguridadDbContext).Assembly);
}

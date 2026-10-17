using Microsoft.EntityFrameworkCore;
using Nova.Seguridad.Dominio.Usuarios;

namespace Nova.Seguridad.Adaptadores.Gateways.Usuarios;

public sealed class RepositorioUsuarios(SeguridadDbContext bd) : IRepositorioUsuarios
{
    public Task<Usuario?> ObtenerPorNombreAsync(NombreUsuario nombre, CancellationToken cancelacion) =>
        bd.Set<Usuario>()
            .Include(u => u.Roles)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.NombreUsuario == nombre, cancelacion);
}

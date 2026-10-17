using Microsoft.AspNetCore.Identity;
using Nova.Seguridad.Aplicacion.Sesion;
using Nova.Seguridad.Dominio.Usuarios;

namespace Nova.Seguridad.Adaptadores.Gateways.Claves;

/// <summary>Compara la clave con el hash guardado (PBKDF2, el mismo formato de ASP.NET Core Identity).</summary>
public sealed class VerificadorClave : IVerificadorClave
{
    private readonly PasswordHasher<Usuario> _hasher = new();

    public bool Verificar(Usuario usuario, string clave) =>
        _hasher.VerifyHashedPassword(usuario, usuario.HashClave, clave) != PasswordVerificationResult.Failed;
}

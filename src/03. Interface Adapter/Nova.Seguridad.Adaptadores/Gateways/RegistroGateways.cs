using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nova.Seguridad.Adaptadores.Gateways.Claves;
using Nova.Seguridad.Adaptadores.Gateways.Tokens;
using Nova.Seguridad.Adaptadores.Gateways.Usuarios;
using Nova.Seguridad.Aplicacion.Sesion;
using Nova.Seguridad.Dominio.Usuarios;

namespace Nova.Seguridad.Adaptadores.Gateways;

public static class RegistroGateways
{
    public static IServiceCollection AgregarGateways(this IServiceCollection servicios)
    {
        // La cadena sale de appsettings.{Ambiente}.json: autenticación de Windows, sin contraseñas.
        servicios.AddDbContext<SeguridadDbContext>((proveedor, opciones) => opciones.UseSqlServer(
            proveedor.GetRequiredService<IConfiguration>().GetConnectionString("Principal")
            ?? throw new InvalidOperationException("Falta ConnectionStrings:Principal en appsettings.{Ambiente}.json")));
        servicios.AddHealthChecks().AddDbContextCheck<SeguridadDbContext>("base-de-datos");

        servicios.AddOptions<OpcionesTokens>().BindConfiguration("Tokens");
        servicios.AddSingleton(TimeProvider.System);
        servicios.AddSingleton<LlavesFirma>();
        servicios.AddSingleton<IEmisorToken, EmisorTokenJwt>();
        servicios.AddSingleton<IVerificadorClave, VerificadorClave>();
        servicios.AddScoped<IRepositorioUsuarios, RepositorioUsuarios>();

        // Repositorios: nuevo-modulo agrega aquí los de cada módulo.
        return servicios;
    }
}

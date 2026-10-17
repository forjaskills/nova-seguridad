using Microsoft.Extensions.DependencyInjection;
using Nova.Seguridad.Aplicacion.Sesion;

namespace Nova.Seguridad.Aplicacion;

public static class RegistroAplicacion
{
    public static IServiceCollection AgregarAplicacion(this IServiceCollection servicios)
    {
        servicios.AddScoped<IIniciarSesion, IniciarSesion>();

        // Casos de uso: nuevo-modulo agrega aquí los de cada módulo.
        return servicios;
    }
}

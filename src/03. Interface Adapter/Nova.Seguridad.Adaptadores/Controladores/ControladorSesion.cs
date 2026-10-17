using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Nova.Seguridad.Adaptadores.Presentadores;
using Nova.Seguridad.Aplicacion.Sesion;

namespace Nova.Seguridad.Adaptadores.Controladores;

[ApiController]
[Route("api/v1/sesion")]
[AllowAnonymous]
public sealed class ControladorSesion(IIniciarSesion iniciarSesion) : ControllerBase
{
    /// <summary>Inicia sesión y devuelve un JWT firmado por nova-seguridad.</summary>
    [HttpPost]
    [EnableRateLimiting(Politicas.LimiteEstricto)]
    [ProducesResponseType<TokenEmitido>(StatusCodes.Status200OK)]
    [ProducesResponseType<ProblemDetails>(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Iniciar(SolicitudInicioSesion solicitud, CancellationToken cancelacion)
    {
        Response.Headers.CacheControl = "no-store";
        return this.Presentar(await iniciarSesion.EjecutarAsync(solicitud, cancelacion));
    }
}

namespace Nova.Seguridad.Adaptadores.Controladores;

/// <summary>Nombres de las políticas que usan los controladores; la Api las define.</summary>
public static class Politicas
{
    /// <summary>Exige el scope <c>seguridad.leer</c> en el token.</summary>
    public const string Lectura = "lectura";

    /// <summary>Exige el scope <c>seguridad.escribir</c> en el token.</summary>
    public const string Escritura = "escritura";

    /// <summary>Límite de intentos para endpoints sensibles (login).</summary>
    public const string LimiteEstricto = "estricto";

    public const string ScopeLectura = "seguridad.leer";

    public const string ScopeEscritura = "seguridad.escribir";
}

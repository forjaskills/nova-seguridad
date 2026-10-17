namespace Nova.Seguridad.Aplicacion.Sesion;

public sealed record SolicitudInicioSesion(string Usuario, string Clave);

public sealed record TokenEmitido(string TokenAcceso, string Tipo, int ExpiraEnSegundos);

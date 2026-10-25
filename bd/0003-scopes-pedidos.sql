-- =============================================================================
-- 0003-scopes-pedidos.sql
-- Proyecto  : nova-seguridad · permisos del servicio nova-pedidos (creado por la skill nuevo-modulo)
-- Qué hace  : da pedidos.leer y pedidos.escribir a los roles cliente, operador y admin
--             (qué registros ve cada uno lo decide nova-pedidos: el cliente, solo los suyos)
-- Ambiente  : cualquiera (el ejecutor elige la base; aquí no hay USE)
-- Respaldo  : no requiere (solo inserta lo que falta)
-- =============================================================================
SET NOCOUNT ON;
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRAN;

    PRINT 'Paso 1/1: scopes de pedidos por rol';
    INSERT INTO dbo.RolScopes (RolId, Scope)
    SELECT v.RolId, v.Scope
    FROM (VALUES
        (1, N'pedidos.leer'), (1, N'pedidos.escribir'),
        (2, N'pedidos.leer'), (2, N'pedidos.escribir'),
        (3, N'pedidos.leer'), (3, N'pedidos.escribir'))
        AS v (RolId, Scope)
    WHERE NOT EXISTS (SELECT 1 FROM dbo.RolScopes rs WHERE rs.RolId = v.RolId AND rs.Scope = v.Scope);

    -- Validación posterior: los 3 roles tienen los 2 scopes.
    IF (SELECT COUNT(*) FROM dbo.RolScopes WHERE RolId IN (1, 2, 3) AND Scope IN (N'pedidos.leer', N'pedidos.escribir')) <> 6
        THROW 50003, 'Validación: faltan scopes de pedidos en algún rol.', 1;

    COMMIT;
    PRINT 'OK: scopes de pedidos listos.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK;
    THROW;
END CATCH

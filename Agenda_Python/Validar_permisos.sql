
USE AgendaContactos;
GO

SELECT
    SUSER_SNAME() AS InicioSesionWindows,
    USER_NAME() AS UsuarioBaseDatos,
    DB_NAME() AS BaseDatos,
    HAS_PERMS_BY_NAME(
        'dbo.Contactos', 'OBJECT', 'SELECT'
    ) AS PuedeConsultar,
    HAS_PERMS_BY_NAME(
        'dbo.Contactos', 'OBJECT', 'INSERT'
    ) AS PuedeInsertar,
    HAS_PERMS_BY_NAME(
        'dbo.Contactos', 'OBJECT', 'UPDATE'
    ) AS PuedeActualizar,
    HAS_PERMS_BY_NAME(
        'dbo.Contactos', 'OBJECT', 'DELETE'
    ) AS PuedeEliminar;
GO

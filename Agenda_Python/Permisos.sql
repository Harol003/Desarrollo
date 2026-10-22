
-- ============================================================
-- PROYECTO: AGENDA DE CONTACTOS
-- PASO 6: CONFIGURAR PERMISOS PARA PYTHON
-- AUTENTICACION: WINDOWS
-- ============================================================

USE master;
GO

-- Crear el inicio de sesion de Windows si no existe
IF SUSER_ID(N'DESKTOP-D3D8QCB\Harol') IS NULL
BEGIN
    CREATE LOGIN [DESKTOP-D3D8QCB\Harol]
    FROM WINDOWS;
END;
GO

-- ============================================================
-- CREAR O VERIFICAR EL USUARIO EN AgendaContactos
-- ============================================================

USE AgendaContactos;
GO

IF DATABASE_PRINCIPAL_ID(N'DESKTOP-D3D8QCB\Harol') IS NULL
BEGIN
    CREATE USER [DESKTOP-D3D8QCB\Harol]
    FOR LOGIN [DESKTOP-D3D8QCB\Harol]
    WITH DEFAULT_SCHEMA = dbo;
END;
GO

-- ============================================================
-- PERMISO DE LECTURA
-- SELECT
-- ============================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members AS drm
    INNER JOIN sys.database_principals AS roles
        ON roles.principal_id = drm.role_principal_id
    INNER JOIN sys.database_principals AS usuarios
        ON usuarios.principal_id = drm.member_principal_id
    WHERE roles.name = N'db_datareader'
      AND usuarios.name = N'DESKTOP-D3D8QCB\Harol'
)
BEGIN
    ALTER ROLE db_datareader
    ADD MEMBER [DESKTOP-D3D8QCB\Harol];
END;
GO

-- ============================================================
-- PERMISO DE ESCRITURA
-- INSERT, UPDATE Y DELETE
-- ============================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members AS drm
    INNER JOIN sys.database_principals AS roles
        ON roles.principal_id = drm.role_principal_id
    INNER JOIN sys.database_principals AS usuarios
        ON usuarios.principal_id = drm.member_principal_id
    WHERE roles.name = N'db_datawriter'
      AND usuarios.name = N'DESKTOP-D3D8QCB\Harol'
)
BEGIN
    ALTER ROLE db_datawriter
    ADD MEMBER [DESKTOP-D3D8QCB\Harol];
END;
GO

-- ============================================================
-- PASO 7: VERIFICAR LOS ROLES ASIGNADOS
-- ============================================================

SELECT
    usuarios.name AS Usuario,
    roles.name AS Rol
FROM sys.database_role_members AS drm
INNER JOIN sys.database_principals AS roles
    ON roles.principal_id = drm.role_principal_id
INNER JOIN sys.database_principals AS usuarios
    ON usuarios.principal_id = drm.member_principal_id
WHERE usuarios.name = N'DESKTOP-D3D8QCB\Harol'
ORDER BY roles.name;
GO

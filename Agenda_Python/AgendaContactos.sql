
-- ============================================================
-- PROYECTO: AGENDA DE CONTACTOS
-- PASO 1: CREAR LA BASE DE DATOS SI NO EXISTE
-- ============================================================

USE master;
GO

IF DB_ID(N'AgendaContactos') IS NULL
BEGIN
    CREATE DATABASE AgendaContactos;
END;
GO

-- ============================================================
-- PASO 2: SELECCIONAR LA BASE DE DATOS
-- ============================================================

USE AgendaContactos;
GO

-- ============================================================
-- PASO 3: CREAR LA TABLA DE CONTACTOS
-- ============================================================

IF OBJECT_ID(N'dbo.Contactos', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Contactos (
        id INT IDENTITY(1,1) NOT NULL,
        nombre NVARCHAR(100) NOT NULL,
        edad INT NOT NULL,
        identificacion NVARCHAR(30) NOT NULL,
        telefono NVARCHAR(25) NOT NULL,
        correo NVARCHAR(150) NOT NULL,

        CONSTRAINT PK_Contactos
            PRIMARY KEY (id),

        CONSTRAINT UQ_Contactos_Identificacion
            UNIQUE (identificacion),

        CONSTRAINT CK_Contactos_Edad
            CHECK (edad BETWEEN 0 AND 130)
    );
END;
GO

-- ============================================================
-- PASO 4: VERIFICAR LA ESTRUCTURA
-- ============================================================

EXEC sp_help 'dbo.Contactos';
GO


-- ============================================================
-- INSERTAR CONTACTOS DE PRUEBA
-- BASE DE DATOS: AgendaContactos
-- ============================================================

USE AgendaContactos;
GO

INSERT INTO dbo.Contactos
    (nombre, edad, identificacion, telefono, correo)
SELECT
    datos.nombre,
    datos.edad,
    datos.identificacion,
    datos.telefono,
    datos.correo
FROM (
    VALUES
    (N'Ana Martinez', 25, N'TEST-1001',
     N'3001112233', N'ana.prueba@example.com'),

    (N'Carlos Rodriguez', 32, N'TEST-1002',
     N'3002223344', N'carlos.prueba@example.com'),

    (N'Laura Gomez', 19, N'TEST-1003',
     N'3003334455', N'laura.prueba@example.com'),

    (N'Andres Perez', 41, N'TEST-1004',
     N'3004445566', N'andres.prueba@example.com'),

    (N'Sofia Torres', 28, N'TEST-1005',
     N'3005556677', N'sofia.prueba@example.com')
) AS datos(nombre, edad, identificacion, telefono, correo)
WHERE NOT EXISTS (
    SELECT 1
    FROM dbo.Contactos AS c
    WHERE c.identificacion = datos.identificacion
);
GO

-- ============================================================
-- PASO 5: CONSULTAR LOS CONTACTOS
-- ============================================================

SELECT
    id,
    nombre,
    edad,
    identificacion,
    telefono,
    correo
FROM dbo.Contactos
ORDER BY id;
GO

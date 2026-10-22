
# ============================================================
# PROYECTO: AGENDA DE CONTACTOS
# LENGUAJE: PYTHON
# BASE DE DATOS: MICROSOFT SQL SERVER
# INTERFAZ: CONSOLA
# OBJETIVO: IMPLEMENTAR LAS OPERACIONES CRUD
# ============================================================

# Importar la biblioteca para conectarse a SQL Server
import pyodbc


# ============================================================
# 1. CONFIGURACION DE LA CONEXION
# ============================================================

# Nombre del servidor SQL Server.
# localhost corresponde a la instancia predeterminada.
SERVIDOR = r"localhost"

# Nombre de la base de datos
BASE_DATOS = "AgendaContactos"

# Cadena de conexion con autenticacion de Windows
CADENA_CONEXION = (
    "DRIVER={ODBC Driver 18 for SQL Server};"
    f"SERVER={SERVIDOR};"
    f"DATABASE={BASE_DATOS};"
    "Trusted_Connection=yes;"
    "Encrypt=yes;"
    "TrustServerCertificate=yes;"
)


# ============================================================
# 2. FUNCION PARA CONECTARSE A SQL SERVER
# ============================================================

def conectar():
    """Establece una conexion con la base de datos."""
    return pyodbc.connect(CADENA_CONEXION, timeout=5)


# ============================================================
# 3. CREAR LA TABLA SI NO EXISTE
# ============================================================

def crear_tabla():
    """Crea la tabla Contactos si no existe."""

    consulta = """
    IF OBJECT_ID('dbo.Contactos', 'U') IS NULL
    BEGIN
        CREATE TABLE dbo.Contactos (
            id INT IDENTITY(1,1) PRIMARY KEY,
            nombre NVARCHAR(100) NOT NULL,
            edad INT NOT NULL CHECK (edad BETWEEN 0 AND 130),
            identificacion NVARCHAR(30) NOT NULL UNIQUE,
            telefono NVARCHAR(25) NOT NULL,
            correo NVARCHAR(150) NOT NULL
        );
    END;
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta)
            conexion.commit()

    except pyodbc.Error as error:
        print("[ERROR] No fue posible crear o verificar la tabla.")
        print(error)


# ============================================================
# 4. FUNCION PARA LEER NUMEROS ENTEROS
# ============================================================

def leer_entero(mensaje, minimo=None, maximo=None):
    """Solicita un entero y valida el rango cuando corresponde."""

    while True:
        try:
            numero = int(input(mensaje))

            if minimo is not None and numero < minimo:
                print(f"El numero debe ser como minimo {minimo}.")
                continue

            if maximo is not None and numero > maximo:
                print(f"El numero debe ser como maximo {maximo}.")
                continue

            return numero

        except ValueError:
            print("Entrada invalida. Debes escribir un numero entero.")


# ============================================================
# 5. REGISTRAR UN CONTACTO (CREATE)
# ============================================================

def registrar_contacto():
    print("\n--- REGISTRAR CONTACTO ---")

    nombre = input("Nombre completo: ").strip()

    if not nombre:
        print("El nombre es obligatorio.")
        return

    edad = leer_entero("Edad: ", 0, 130)

    identificacion = input("Identificacion: ").strip()
    telefono = input("Telefono: ").strip()
    correo = input("Correo electronico: ").strip()

    if not identificacion or not telefono or not correo:
        print("La identificacion, el telefono y el correo son obligatorios.")
        return

    consulta = """
    INSERT INTO dbo.Contactos
        (nombre, edad, identificacion, telefono, correo)
    VALUES (?, ?, ?, ?, ?);
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(
                consulta,
                nombre,
                edad,
                identificacion,
                telefono,
                correo
            )
            conexion.commit()

        print("[OK] Contacto registrado correctamente.")

    except pyodbc.IntegrityError:
        print(
            "[ERROR] La identificacion ya existe "
            "o se incumplio una restriccion."
        )

    except pyodbc.Error as error:
        print("[ERROR] No fue posible registrar el contacto.")
        print(error)


# ============================================================
# 6. LISTAR TODOS LOS CONTACTOS (READ)
# ============================================================

def listar_contactos():
    print("\n--- LISTA DE CONTACTOS ---")

    consulta = """
    SELECT id, nombre, edad, identificacion, telefono, correo
    FROM dbo.Contactos
    ORDER BY nombre;
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta)
            contactos = cursor.fetchall()

        if not contactos:
            print("No hay contactos registrados.")
            return

        for contacto in contactos:
            print("-" * 55)
            print(f"ID:             {contacto.id}")
            print(f"Nombre:         {contacto.nombre}")
            print(f"Edad:           {contacto.edad}")
            print(f"Identificacion: {contacto.identificacion}")
            print(f"Telefono:       {contacto.telefono}")
            print(f"Correo:         {contacto.correo}")

        print("-" * 55)
        print(f"Total de contactos: {len(contactos)}")

    except pyodbc.Error as error:
        print("[ERROR] No fue posible consultar los contactos.")
        print(error)


# ============================================================
# 7. BUSCAR UN CONTACTO POR ID (READ)
# ============================================================

def buscar_contacto():
    print("\n--- BUSCAR CONTACTO ---")

    id_contacto = leer_entero("Ingresa el ID del contacto: ", 1)

    consulta = """
    SELECT id, nombre, edad, identificacion, telefono, correo
    FROM dbo.Contactos
    WHERE id = ?;
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta, id_contacto)
            contacto = cursor.fetchone()

        if contacto is None:
            print("No existe un contacto con ese ID.")
            return

        print("\n--- CONTACTO ENCONTRADO ---")
        print(f"ID:             {contacto.id}")
        print(f"Nombre:         {contacto.nombre}")
        print(f"Edad:           {contacto.edad}")
        print(f"Identificacion: {contacto.identificacion}")
        print(f"Telefono:       {contacto.telefono}")
        print(f"Correo:         {contacto.correo}")

    except pyodbc.Error as error:
        print("[ERROR] No fue posible buscar el contacto.")
        print(error)


# ============================================================
# 8. ACTUALIZAR UN CONTACTO (UPDATE)
# ============================================================

def actualizar_contacto():
    print("\n--- ACTUALIZAR CONTACTO ---")

    id_contacto = leer_entero(
        "ID del contacto que deseas actualizar: ", 1
    )

    consulta_busqueda = """
    SELECT id, nombre, edad, identificacion, telefono, correo
    FROM dbo.Contactos
    WHERE id = ?;
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta_busqueda, id_contacto)
            contacto = cursor.fetchone()

        if contacto is None:
            print("No existe un contacto con ese ID.")
            return

        print("\nDeja el campo vacio para conservar el valor actual.")
        print(f"Nombre actual:        {contacto.nombre}")
        print(f"Edad actual:           {contacto.edad}")
        print(f"Identificacion actual: {contacto.identificacion}")
        print(f"Telefono actual:       {contacto.telefono}")
        print(f"Correo actual:         {contacto.correo}")

        nombre = input("Nuevo nombre: ").strip() or contacto.nombre

        edad_texto = input("Nueva edad: ").strip()

        if edad_texto:
            try:
                edad = int(edad_texto)

                if not 0 <= edad <= 130:
                    print("La edad debe estar entre 0 y 130.")
                    return

            except ValueError:
                print("La edad debe ser un numero entero.")
                return
        else:
            edad = contacto.edad

        identificacion = (
            input("Nueva identificacion: ").strip()
            or contacto.identificacion
        )

        telefono = (
            input("Nuevo telefono: ").strip()
            or contacto.telefono
        )

        correo = (
            input("Nuevo correo: ").strip()
            or contacto.correo
        )

        consulta_actualizar = """
        UPDATE dbo.Contactos
        SET nombre = ?,
            edad = ?,
            identificacion = ?,
            telefono = ?,
            correo = ?
        WHERE id = ?;
        """

        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(
                consulta_actualizar,
                nombre,
                edad,
                identificacion,
                telefono,
                correo,
                id_contacto
            )
            conexion.commit()

        print("[OK] Contacto actualizado correctamente.")

    except pyodbc.IntegrityError:
        print(
            "[ERROR] No se pudo actualizar. "
            "La identificacion puede pertenecer a otro contacto."
        )

    except pyodbc.Error as error:
        print("[ERROR] No fue posible actualizar el contacto.")
        print(error)


# ============================================================
# 9. ELIMINAR UN CONTACTO (DELETE)
# ============================================================

def eliminar_contacto():
    print("\n--- ELIMINAR CONTACTO ---")

    id_contacto = leer_entero(
        "ID del contacto que deseas eliminar: ", 1
    )

    consulta_busqueda = """
    SELECT nombre
    FROM dbo.Contactos
    WHERE id = ?;
    """

    try:
        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta_busqueda, id_contacto)
            contacto = cursor.fetchone()

        if contacto is None:
            print("No existe un contacto con ese ID.")
            return

        print(f"Contacto seleccionado: {contacto.nombre}")

        confirmacion = input(
            "¿Confirmas la eliminacion? (S/N): "
        ).strip().upper()

        if confirmacion != "S":
            print("Operacion cancelada.")
            return

        consulta_eliminar = """
        DELETE FROM dbo.Contactos
        WHERE id = ?;
        """

        with conectar() as conexion:
            cursor = conexion.cursor()
            cursor.execute(consulta_eliminar, id_contacto)
            eliminado = cursor.rowcount
            conexion.commit()

        if eliminado > 0:
            print("[OK] Contacto eliminado correctamente.")
        else:
            print("No se encontro el contacto para eliminar.")

    except pyodbc.Error as error:
        print("[ERROR] No fue posible eliminar el contacto.")
        print(error)


# ============================================================
# 10. PROBAR CONEXION Y BASE DE DATOS
# ============================================================

def probar_base_datos():
    print("\n--- PRUEBA DE CONEXION Y BASE DE DATOS ---")

    try:
        # Paso 1: comprobar la conexion
        with conectar() as conexion:
            print("[OK] Conexion con SQL Server establecida.")

            cursor = conexion.cursor()

            # Paso 2: verificar el servidor y la base de datos
            cursor.execute("""
                SELECT
                    @@SERVERNAME AS servidor,
                    DB_NAME() AS base_datos
            """)

            resultado = cursor.fetchone()

            print(f"[OK] Servidor: {resultado.servidor}")
            print(f"[OK] Base de datos: {resultado.base_datos}")

            # Paso 3: comprobar si la tabla existe
            cursor.execute("""
                SELECT OBJECT_ID('dbo.Contactos', 'U')
            """)

            tabla = cursor.fetchone()[0]

            if tabla is None:
                print("[ERROR] No existe la tabla dbo.Contactos.")
                print("Ejecuta nuevamente el programa para verificarla.")
                return

            print("[OK] La tabla dbo.Contactos existe.")

            # Paso 4: comprobar que la tabla se puede consultar
            cursor.execute("""
                SELECT COUNT(*)
                FROM dbo.Contactos
            """)

            total = cursor.fetchone()[0]

            print("[OK] Consulta de prueba ejecutada correctamente.")
            print(f"[OK] Contactos registrados: {total}")

            print("\nResultado: todas las pruebas finalizaron correctamente.")

    except pyodbc.Error as error:
        print("\n[ERROR] No fue posible completar la prueba.")
        print("Detalle:", error)


# ============================================================
# 11. MENU PRINCIPAL
# ============================================================

def mostrar_menu():
    print("\n" + "=" * 45)
    print("         AGENDA DE CONTACTOS")
    print("=" * 45)
    print("1. Registrar contacto")
    print("2. Listar contactos")
    print("3. Buscar contacto por ID")
    print("4. Actualizar contacto")
    print("5. Eliminar contacto")
    print("6. Salir")
    print("-" * 45)
    print("7. Probar conexion y base de datos")
    print("=" * 45)


# ============================================================
# 12. EJECUCION DEL PROGRAMA
# ============================================================

def main():
    # Verificar o crear la tabla al iniciar
    crear_tabla()

    while True:
        mostrar_menu()

        opcion = input("Selecciona una opcion: ").strip()

        if opcion == "1":
            registrar_contacto()

        elif opcion == "2":
            listar_contactos()

        elif opcion == "3":
            buscar_contacto()

        elif opcion == "4":
            actualizar_contacto()

        elif opcion == "5":
            eliminar_contacto()

        elif opcion == "6":
            print("Gracias por utilizar la Agenda de Contactos.")
            break

        elif opcion == "7":
            probar_base_datos()

        else:
            print("Opcion invalida. Selecciona un numero del 1 al 7.")


# Ejecutar el programa cuando se abre este archivo
if __name__ == "__main__":
    main()

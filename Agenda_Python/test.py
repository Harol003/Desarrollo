import pyodbc

SERVIDOR = r"localhost"
BASE_DATOS = "AgendaContactos"

conexion = (
    "DRIVER={ODBC Driver 18 for SQL Server};"
    f"SERVER={SERVIDOR};"
    f"DATABASE={BASE_DATOS};"
    "Trusted_Connection=yes;"
    "Encrypt=yes;"
    "TrustServerCertificate=yes;"
)

try:
    with pyodbc.connect(conexion, timeout=5) as cn:
        cursor = cn.cursor()
        cursor.execute("SELECT @@SERVERNAME, DB_NAME()")
        resultado = cursor.fetchone()

        print("Conexion exitosa.")
        print("Servidor:", resultado[0])
        print("Base de datos:", resultado[1])

except pyodbc.Error as error:
    print("No fue posible conectar con SQL Server.")
    print(error)
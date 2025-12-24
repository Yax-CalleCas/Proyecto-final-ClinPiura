# ClinPiura

ClinPiura es una aplicación web para la gestión integral de una clínica médica digital. Ha sido desarrollada utilizando el patrón **ASP.NET Core MVC**, con **Razor Pages**, **Bootstrap 5** y **SQL Server**, siguiendo una arquitectura basada en servicios e inyección de dependencias.

El sistema permite administrar citas médicas, usuarios, personal médico, farmacia en línea, ventas, historiales clínicos y reportes, bajo un esquema de seguridad por roles y autenticación mediante cookies.

## Credenciales por defecto

Durante la primera ejecución del sistema, se crea automáticamente un usuario administrador mediante un proceso de inicialización (Seed).

**Credenciales iniciales:**
- **Correo:** `admin@clinpiura.com`
- **Nombre:** Jack Cibertec
- **Clave:** `admin123`
- **Rol:** Administrador

> **Recomendación:** Cambiar la contraseña inmediatamente después del primer inicio de sesión.

## Características principales

### Gestión de accesos y roles
El sistema cuenta con control de acceso basado en roles:

- **Administrador**
  - Gestión de usuarios del sistema
  - Administración del personal médico
  - Gestión del catálogo de medicamentos
  - Visualización de reportes y estadísticas

- **Médico**
  - Visualización de citas asignadas
  - Gestión de agenda diaria

- **Paciente**
  - Reserva de citas médicas
  - Compra de medicamentos
  - Consulta de historial clínico personal

### Sistema de citas médicas
- Generación automática de disponibilidad médica mediante `HorarioService`.
- Proyección de horarios para los próximos siete días al registrar un médico.
- Filtros de disponibilidad que excluyen horarios pasados y turnos ya reservados.
- Configuración de jornada laboral, incluyendo pausas de almuerzo y bloqueos de seguridad.

### Farmacia en línea
- Catálogo dinámico de medicamentos organizado por categorías.
- Gestión de productos con imágenes, descripciones y promociones porcentuales.
- Carrito de compras persistente almacenado en la base de datos.
- Procesamiento de ventas con cálculo automático de subtotal, IGV y total.
- Uso de **Table-Valued Parameters (TVP)** para optimizar operaciones complejas.

### Seguridad y diseño
- Autenticación basada en cookies.
- Protección de credenciales mediante hash **SHA256**.
- Inicialización automática del usuario administrador mediante `SeedService`.
- Interfaz responsive con navegación dinámica según el rol del usuario.
- Manejo de sesiones con expiración configurable (20 minutos por defecto).

## Tecnologías utilizadas

- **Backend:** ASP.NET Core MVC (.NET 8)
- **Persistencia de datos:** ADO.NET con procedimientos almacenados
- **Base de datos:** SQL Server
- **Frontend:** Razor Pages, Bootstrap 5, SweetAlert2, jQuery
- **Autenticación:** Cookies
- **Control de versiones:** Git y GitHub

## Requisitos del entorno

- Visual Studio 2022 con carga de trabajo ASP.NET y desarrollo web
- .NET SDK 8.0
- SQL Server (LocalDB, Express o versión completa)
- Git

## Instalación y configuración
2. Configuración de la base de datos
Ejecutar los scripts de creación de tablas y procedimientos almacenados incluidos en el proyecto en una instancia de SQL Server.
3. Configuración de la cadena de conexión
Modificar el archivo appsettings.json según tu entorno local:
{
  "ConnectionStrings": {
    "CadenaSQL": "Server=LAPTOP-1E2VL582\\SQLEXPRESS;Database=BD_ClinPiura;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"
  }
}
4. Ejecución de la aplicación
Desde Visual Studio o mediante la línea de comandos:
dotnet run
Configuración interna del sistema
Registro de servicios
La aplicación utiliza inyección de dependencias para desacoplar la lógica de negocio. Entre los principales servicios registrados se encuentran:

Usuarios
Citas médicas
Medicamentos
Ventas
Reportes
Horarios médicos
Administración y estadísticas
Autenticación y sesiones

Inicialización automática (Seed)
Durante el arranque de la aplicación, se ejecuta un proceso automático que verifica la existencia del usuario administrador y lo crea si no existe. Este proceso se ejecuta una sola vez.
Estado del proyecto
Proyecto funcional, estructurado y orientado a la gestión clínica integral.
Preparado para presentación académica y con posibilidad de ampliación futura.

### 1. Clonar el repositorio
```bash
git clone https://github.com/Yax-CalleCas/Proyecto-final-ClinPiura.git

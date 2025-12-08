# Sistema de Reservaciones de Vuelos - Backend

## Descripción del Proyecto

Sistema backend de reservaciones de vuelos desarrollado con WCF (Windows Communication Foundation) y .NET Framework. Este proyecto proporciona una API de servicios web para gestionar reservaciones de vuelos, incluyendo la administración de aerolíneas, aeropuertos, ciudades, clientes, vuelos y pagos.

El sistema implementa una arquitectura en capas que permite la separación de responsabilidades y facilita el mantenimiento y escalabilidad del código. Está diseñado para ser consumido por aplicaciones frontend que requieran funcionalidades de reservación de vuelos.

## Características Principales

- **Gestión de Aerolíneas**: CRUD completo para administrar aerolíneas
- **Gestión de Aeropuertos**: Administración de aeropuertos y sus ubicaciones
- **Gestión de Ciudades**: Control de ciudades disponibles
- **Gestión de Clientes**: Registro y actualización de información de clientes
- **Gestión de Vuelos**: Creación y administración de vuelos con origen, destino, fechas y precios
- **Sistema de Reservaciones**: Proceso completo de reservación de vuelos
- **Gestión de Pagos**: Procesamiento de pagos y métodos de pago
- **Autenticación**: Sistema de autenticación de usuarios con roles

## Arquitectura del Proyecto

El proyecto está organizado en las siguientes capas:

### **UTA.FISEI.FlightsReservations.Domain**
Capa de dominio que contiene las entidades del negocio y DTOs (Data Transfer Objects):
- Entidades: `Airline`, `Airport`, `City`, `Client`, `Flight`, `Reservation`, `Payment`, `User`, `Role`
- DTOs para crear y actualizar entidades

### **UTA.FISEI.FlightsReservations.Contract**
Define los contratos de servicios (interfaces WCF) que exponen las operaciones disponibles

### **UTA.FISEI.FlightsReservations.Interfaces**
Contiene las interfaces de los repositorios y servicios de negocio

### **UTA.FISEI.FlightsReservations.Implementation**
Implementación de la lógica de negocio

### **UTA.FISEI.FlightsReservations.Repository**
Capa de acceso a datos, implementa el patrón Repository para interactuar con la base de datos

### **UTA.FISEI.FlightsReservations.Facade**
Capa de fachada que coordina las operaciones entre la capa de servicios y la lógica de negocio

### **UTA.FISEI.FlightsReservations.WcfService**
Proyecto de servicios WCF que expone los endpoints del sistema:
- `AirlineService.svc`
- `AirportService.svc`
- `CityService.svc`
- `ClientService.svc`
- `FlightService.svc`
- `ReservationService.svc`
- `UserService.svc`
- `AuthService.svc`

## Tecnologías Utilizadas

- **.NET Framework 4.7.2**
- **WCF (Windows Communication Foundation)** - Framework para servicios web
- **Entity Framework** - ORM para acceso a datos
- **SQL Server** - Base de datos
- **System.Text.Json** - Serialización JSON
- **Microsoft.IdentityModel** - Autenticación y tokens JWT

## Requisitos Previos

- Visual Studio 2019 o superior
- .NET Framework 4.7.2 o superior
- SQL Server 2016 o superior
- IIS (Internet Information Services) para deployment

## Instalación y Configuración

### 1. Clonar el Repositorio

```bash
git clone https://github.com/IAlexLizano/flights-reservations-backend.git
cd flights-reservations-backend
```

### 2. Configurar la Base de Datos

1. Abrir SQL Server Management Studio
2. Crear una nueva base de datos para el proyecto
3. Actualizar la cadena de conexión en el archivo `Web.config` del proyecto `UTA.FISEI.FlightsReservations.WcfService`

```xml
<connectionStrings>
    <add name="FlightsReservationsDB" 
         connectionString="Server=tu_servidor;Database=tu_base_datos;User Id=tu_usuario;Password=tu_password;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Restaurar Paquetes NuGet

Abrir la solución en Visual Studio y restaurar los paquetes NuGet:

```
Tools > NuGet Package Manager > Restore NuGet Packages
```

### 4. Compilar la Solución

```
Build > Build Solution
```

O usar la línea de comandos:

```bash
msbuild UTA.FISEI.FlightsReservations.Domain.sln
```

### 5. Ejecutar el Proyecto

1. Establecer `UTA.FISEI.FlightsReservations.WcfService` como proyecto de inicio
2. Presionar F5 o hacer clic en "Start" en Visual Studio
3. El servicio WCF se ejecutará en IIS Express

## Endpoints de Servicios

Los servicios están disponibles en las siguientes rutas (según configuración local):

- `http://localhost:[puerto]/AirlineService.svc` - Gestión de aerolíneas
- `http://localhost:[puerto]/AirportService.svc` - Gestión de aeropuertos
- `http://localhost:[puerto]/CityService.svc` - Gestión de ciudades
- `http://localhost:[puerto]/ClientService.svc` - Gestión de clientes
- `http://localhost:[puerto]/FlightService.svc` - Gestión de vuelos
- `http://localhost:[puerto]/ReservationService.svc` - Gestión de reservaciones
- `http://localhost:[puerto]/UserService.svc` - Gestión de usuarios
- `http://localhost:[puerto]/AuthService.svc` - Autenticación

## Uso

Para consumir los servicios WCF desde una aplicación cliente:

1. Agregar una referencia de servicio en el proyecto cliente
2. Usar la URL del servicio (por ejemplo: `http://localhost:puerto/FlightService.svc`)
3. Visual Studio generará automáticamente las clases proxy para consumir el servicio

Ejemplo de uso básico:

```csharp
FlightServiceClient client = new FlightServiceClient();
var flights = client.GetAllFlights();
```

## Estructura de la Base de Datos

El sistema maneja las siguientes entidades principales:

- **Airlines**: Aerolíneas
- **Airports**: Aeropuertos
- **Cities**: Ciudades
- **Clients**: Clientes
- **Flights**: Vuelos
- **Reservations**: Reservaciones
- **Payments**: Pagos
- **PaymentMethods**: Métodos de pago
- **Users**: Usuarios del sistema
- **Roles**: Roles de usuarios

## Colaboradores

Este proyecto ha sido desarrollado por:

### 👨‍💻 Desarrolladores Full Stack
- **[IAlexLizano](https://github.com/IAlexLizano)** - Full Stack Developer
- **[Davidl2002](https://github.com/Davidl2002)** - Full Stack Developer

### 🎨 Desarrollador Frontend
- **[JaviFiallos](https://github.com/JaviFiallos)** - Frontend Developer

## Contribuciones

Las contribuciones son bienvenidas. Por favor, sigue estos pasos:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## Licencia

Este proyecto es parte de un trabajo académico de la Universidad Técnica de Ambato - Facultad de Ingeniería en Sistemas, Electrónica e Industrial (UTA - FISEI).

## Contacto

Para más información sobre el proyecto, contacta a los colaboradores a través de sus perfiles de GitHub.

---

**Universidad Técnica de Ambato**  
**Facultad de Ingeniería en Sistemas, Electrónica e Industrial (FISEI)**

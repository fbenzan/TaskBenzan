# TaskBenzan - Sistema de Gestión de Clientes

## Descripción
TaskBenzan es una aplicación web desarrollada con Blazor que proporciona una plataforma completa para la gestión de clientes. El sistema permite administrar la información de clientes de manera eficiente y segura.

## Estructura del Proyecto
```
TaskBenzan/
├── Components/          # Componentes reutilizables
│   ├── Account/        # Componentes relacionados con la autenticación
│   └── Layout/         # Componentes de diseño base
├── Pages/              # Páginas de la aplicación
│   └── Clientes/       # Módulo de gestión de clientes
├── Data/               # Capa de datos
│   ├── Business/       # Lógica de negocio
│   ├── DTOs/          # Objetos de transferencia de datos
│   ├── Entities/      # Modelos de dominio
│   ├── Migrations/    # Migraciones de base de datos
│   └── Repositories/  # Repositorios para acceso a datos
```

## Características Principales
- Gestión completa de clientes (CRUD)
- Sistema de autenticación y autorización
- Interfaz de usuario responsiva
- Arquitectura en capas
- Persistencia de datos con Entity Framework Core

## Requisitos Técnicos
- .NET 8.0 o superior
- Entity Framework Core
- SQL Server (como motor de base de datos)

## Instalación y Configuración de Migraciones

### 1. Instalación de Herramientas
Antes de comenzar, instale la herramienta Entity Framework Core CLI globalmente:
```bash
dotnet tool install --global dotnet-ef
```

### 2. Gestión de Migraciones
Para agregar nuevas migraciones al proyecto, utilice el siguiente comando:
```bash
dotnet ef migrations add AccionQueEstaHaciendo --context ApplicationDbContext --output-dir Data/Migrations
```

### 3. Pasos de Instalación General
1. Clone el repositorio:
```bash
git clone [[URL_del_repositorio](https://github.com/fbenzan/TaskBenzan.git)]
```

2. Restaure las dependencias:
```bash
dotnet restore
```

3. Actualice la base de datos:
```bash
dotnet ef database update
```

4. Execute la aplicación:
```bash
dotnet run
```

## Configuración
La aplicación utiliza `appsettings.json` para la configuración principal. Asegúrese de actualizar las siguientes secciones según su entorno:
- Cadena de conexión a la base de datos
- Configuraciones de autenticación
- Otras configuraciones específicas del entorno

## Estructura de Datos
El sistema utiliza las siguientes entidades principales:
- Cliente: Entidad principal para el almacenamiento de información de clientes
- ApplicationUser: Modelo de usuario para la autenticación

## Contribución
Para contribuir al proyecto:
1. Cree un branch para su característica (`git checkout -b feature/AmazingFeature`)
2. Realice sus cambios
3. Commit sus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push al branch (`git push origin feature/AmazingFeature`)
5. Abra un Pull Request

## Licencia
Este proyecto no está bajo licencia de propiedad intelectual.

## Contacto
Felix Ramon Benzan Castro

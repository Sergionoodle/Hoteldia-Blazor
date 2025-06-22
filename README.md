# 🏨 HotelDia

**HotelDia** es una aplicación de gestión hotelera desarrollada con **Blazor Server** y **.NET 8**. Es un proyecto educativo que tiene como objetivo practicar y aplicar principios de desarrollo web full-stack utilizando tecnologías modernas del ecosistema .NET.

---

## 🎯 Objetivo del proyecto

El propósito principal de **HotelDia** es consolidar conocimientos en el desarrollo de aplicaciones web robustas utilizando Blazor y C#, implementando patrones y buenas prácticas como:

- Arquitectura por capas
- Inyección de dependencias
- Uso de Entity Framework Core para la persistencia de datos
- Implementación de DTOs y mapeo con AutoMapper
- Relación entre entidades (uno a muchos, muchos a muchos)
- CRUD completos en componentes Blazor
- Separación de responsabilidades (UI, lógica, acceso a datos)

---

## 🧱 Funcionalidades en desarrollo

Actualmente, el sistema se encuentra en proceso de implementación de:

- **Gestión de categorías y propiedades** con relación uno a muchos
- Componentes Blazor con formularios para creación y edición de entidades
- Dropdowns dinámicos utilizando datos de la base de datos
- Servicios desacoplados mediante interfaces
- Uso de DTOs para evitar exposición directa de entidades
- Migraciones controladas con EF Core
- Validación de formularios e interacción fluida en la UI

---

## 🔧 Tecnologías utilizadas

- **Blazor Server** (Interfaz de usuario interactiva y en tiempo real)
- **.NET 8** (Framework principal del proyecto)
- **C#** (Lenguaje de programación)
- **Entity Framework Core** (ORM para acceso a base de datos)
- **SQL Server** (Motor de base de datos)
- **AutoMapper** (Mapeo automático entre modelos y DTOs)
- **Inyección de Dependencias** (Gestión de servicios)
- **Migrations** (Control de versiones del esquema de base de datos)
- **Visual Studio 2022** (IDE principal)
- **SQL Server Management Studio** (Gestión visual de la base de datos)

---

## 🏗️ Estructura del proyecto

El proyecto está dividido de forma modular para facilitar el mantenimiento, escalabilidad y comprensión:
/Models -> Entidades de base de datos (EF Core)
/DTOs -> Objetos de transferencia de datos utilizados entre capas
/Repositories -> Clases que contienen la lógica de acceso a datos
/Interfaces -> Interfaces para los repositorios (contratos)
/Pages -> Componentes Blazor (interfaz de usuario)
/Mapper -> Configuración de AutoMapper (perfiles de mapeo entre Model y DTO)
/Data -> ApplicationDbContext y configuración de EF Core
/Shared -> Componentes reutilizables (layouts, navegación, etc.)
/wwwroot -> Archivos estáticos (CSS, JS, imágenes)


---

## 🗃️ Base de datos

La base de datos utilizada es **SQL Server**, gestionada mediante **Entity Framework Core**. Las tablas se generan a partir de las entidades definidas en `/Models` y las relaciones entre ellas.

Los cambios en el esquema de la base de datos se aplican mediante migraciones:

```bash
Add-Migration NombreMigracion
Update-Database


## 🚧 Funcionalidades en desarrollo

Actualmente se están desarrollando e implementando:

- **Gestión CRUD** de entidades como **Categoría** y **Propiedad**
- **Formularios interactivos** en Blazor con validaciones (tanto del lado del cliente como del servidor)
- **Dropdowns dinámicos** para seleccionar relaciones entre entidades (por ejemplo, seleccionar una categoría al crear una propiedad)
- **Mapeo entre entidades y DTOs** mediante AutoMapper, evitando la exposición directa de las entidades del modelo
- **Inyección de dependencias** configurada en `Program.cs` para desacoplar lógica y facilitar pruebas
- **Repositorios e interfaces personalizados**, incluyendo métodos específicos de consulta y lógica de negocio
- **Renderizado dinámico** de componentes Blazor en función del estado del modelo o los datos recibidos
- **Gestión de errores y validaciones** utilizando bloques `try-catch`, validaciones por atributos y control del estado de los formularios

---

## 💡 Buenas prácticas aplicadas

- **Arquitectura en capas**: separación clara entre entidades, DTOs, lógica de negocio y presentación
- **DTOs personalizados**: utilizados para controlar qué información se expone o recibe en cada caso de uso
- **AutoMapper**: se encarga del mapeo automático entre modelos y DTOs, evitando código repetitivo
- **Uso de migraciones con EF Core**: permite versionar y aplicar cambios en el esquema de la base de datos de manera controlada
- **Inyección de dependencias** (`AddScoped`) para gestionar los ciclos de vida de los servicios de forma eficiente
- **Componentes reutilizables en Blazor**: layout, formularios y dropdowns
- **Uso del patrón repositorio** para desacoplar el acceso a datos de la lógica de negocio

---

## 👨‍💻 Autor

Proyecto creado por [Sergionoodle](https://github.com/Sergionoodle) como parte de su proceso de aprendizaje en desarrollo web full-stack con tecnologías modernas de Microsoft (.NET, Blazor, EF Core).

---

## 📄 Licencia

Este proyecto está disponible con fines educativos bajo una licencia de uso libre. Puedes usarlo, modificarlo y compartirlo siempre que se dé el crédito correspondiente al autor.

---



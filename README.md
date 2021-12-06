# ToDoApp

Desafio Envolvers

## Tecnologias

* [ASP.NET Core 5](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [Entity Framework Core 5](https://docs.microsoft.com/en-us/ef/core/)
* [Angular 12.2.13](https://angular.io/)
* [MediatR](https://github.com/jbogard/MediatR)
* [AutoMapper](https://automapper.org/)
* [FluentValidation](https://fluentvalidation.net/)

## Como empezar
1. Ir a `src/ToDo.Api/appsettings.json` y configurar el servidor `Server=(YourServer)` de la cadena de conexión por tu propio servidor.
2. Abrir el `Package Manager Console` y ejecutar el comando `update-database` asegurandose de tener el proyecto `ToDo.Api` como `Startup Proyect`.
3. Abrir el `Powershell` navegar a `src/ToDo.Api/ToDoUI` y ejecutar el comando `npm install`.
4. Navegar a `src/ToDo.Api/ToDoUI` y ejecutar el comando `ng serve -o` para ejecutar el front end (Angular)
5. Navegar a `src/WebUI` y ejecutar el comando `dotnet run` para ejecutar el back end (ASP.NET Core Web API)
6. Por defecto se creara un usuario el ejecutar el back end, con ese usuario ingresaremos en la aplicacion `email:` admin@email.com y `password:` Admin-123

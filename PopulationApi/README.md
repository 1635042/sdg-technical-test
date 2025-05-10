# Population API - Prueba técnica SDG Group

API REST desarrollada en C# con ASP.NET Core para consultar y almacenar datos poblacionales desde la API pública [restcountries.com](https://restcountries.com/).

## Funcionalidad

- `POST /api/v1/data/country`  
  Recupera todos los países y guarda su nombre y población en una base de datos SQLite.

- `GET /api/v1/data/country`  
  Devuelve los países guardados.

## Tecnologías

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQLite

## Instrucciones

1. Clona el proyecto, restaura dependencias, crea la base de datos y ejecuta la API:

   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run

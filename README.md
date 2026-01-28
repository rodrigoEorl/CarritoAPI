# Carrito API

API REST para la gestión de un carrito de compras con productos personalizables.

## Requisitos
- .NET 8 SDK
- Visual Studio 2022

## Ejecución local

1. Clonar el repositorio
2. Abrir la solución `Carrito.sln`
3. Establecer `Carrito.Api` como proyecto de inicio
4. Seleccionar IIS como perfil
5. Ejecutar el proyecto

La API se iniciará en:
https://localhost:44379

Swagger disponible en:
https://localhost:44379/swagger

## Endpoints principales

### Agregar producto al carrito
POST `/carrito/items`

```json
{
  "productoId": "3546345",
  "grupos": [
    {
      "grupoId": "241887",
      "opciones": [
        {
          "opcionId": "968636",
          "cantidad": 1
        }
      ]
    },
    {
      "grupoId": "241888",
      "opciones": [
        {
          "opcionId": "968639",
          "cantidad": 2
        }
      ]
    },
    {
      "grupoId": "241891",
      "opciones": [
        {
          "opcionId": "968663",
          "cantidad": 1
        }
      ]
    },
    {
      "grupoId": "241892",
      "opciones": [
        {
          "opcionId": "968670",
          "cantidad": 1
        }
      ]
    }
  ]
}

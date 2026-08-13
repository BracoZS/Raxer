# Raxer

Repo indie: código libre, sin convenciones impuestas por frameworks o arquitecturas conocidas (nada de clean, hexagonal, CQRS). Se parece a vertical slice solo en que tiene módulos. Buenas ideas ajenas se toman, pero la convención es la propia.
Este código es artisan.

## Estructura

Ver [docs/estructura.md](docs/estructura.md).

- `Modules/` → features de la app, cada una es su propia unidad
- `Infra/` → infraestructura reusable por cualquier módulo: persistencia, I/O, servicios externos (estilo hex/clean)

## Reglas

- Sin dependency injection. Sin interfaces de adorno.
- Módulos usan `Infra` libremente.
- Dependencia única: `CommunityToolkit.Mvvm`.
- Idioma libre (inglés, español, spanglish), pero mantener cierta normalidad.

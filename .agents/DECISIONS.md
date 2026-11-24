# Decisions

Append-only. Una entrada por decisión. Si una decisión se revierte, no la borres: cambia su status y agrega una entrada nueva.

## D-001: Migrar target framework a .NET 11 (2026-11-23)
- Decision: Actualizar el proyecto de `net10.0-windows` a `net11.0-windows`.
- Reason: Mantener la app al día con .NET 11 antes de continuar con nuevas features.
- Alternatives discarded: Mantenerse en `.NET 10`.
- Status: active

## D-002: Separar settings locales de config.rxconfig y modelar Perfiles/Filtros planos (2026-11-23)
- Decision: Mantener `settings.json` (`LocalSettingsJson`) para preferencias locales de la máquina (`ArrancarConWindows`, `ActiveProfileId`, `ConfigPath`) y persistir perfiles/filtros/remaps en `config.rxconfig` (JSON portable vía `ConfigStorage` con `System.Text.Json`, modelos planos sin polimorfismo para migrarlo fácil a `LocalSettingsJson` cuando se actualice la librería). Los filtros son independientes por `FilterId` (0..1 por perfil) y cada `RemapEntry` modela `MouseAccion` + `Modificador` → `ActionKind` tipado.
- Reason: Permitir respaldar/importar `.rxconfig` aparte de preferencias locales de la PC, compartir filtros entre perfiles y evitar complejidad/polimorfismo en JSON.
- Alternatives discarded: Guardar todo dentro de `settings.json`, un archivo JSON por perfil/filtro, o embeber filtros dentro de cada perfil.
- Status: active

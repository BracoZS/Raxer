# Status

Updated: 2026-11-23
Current focus: UI (mocks en Infra/Dev/) y Backend de CRUD Perfiles/Filtros/Remaps por separado

## Done
- `Modelo de Perfiles + Filtros y persistencia (.rxconfig)` cerrado (`29caab0`).
- `Remapping end-to-end` conectado (`AppFilter.IsActive`, `MouseReasignRegistry`, `MouseDispatcher`, `ProfileMapper`, `MouseHook` + fix de 6 `EntryPoint` `*W` en `WinApi.cs`, `Loader`/`PerfilesVM`) y verificado compilando limpio.
- Norma de `dotnet build` con criterio actualizada en `AGENTS.md` y `.agents/STACK.md`.
- Registrada `D-003` en `.agents/DECISIONS.md` para trabajar UI (mocks en `Infra/Dev/`) y backend por separado antes del wiring.

## In progress
- Ninguno (listo para arrancar siguiente sesión bajo `D-003`).

## Next
1. Wiring final UI ↔ Backend de CRUD Perfiles/Filtros/Remaps.
2. Migrar `ConfigStorage` a `LocalSettingsJson` cuando soporte rutas custom.

## Blockers y preguntas
- Ninguno.

## Do not touch yet
- Items bajo `Later` en `.agents/ROADMAP.md` (`TestsWindow` cleanup, `TestLangChange()`).
- Todo lo que entre en `Out of scope` en `.agents/PROJECT.md`.

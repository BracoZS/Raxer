# Status

Updated: 2026-11-23
Current focus: Conectar Remapping end-to-end (Loader → MouseReasignRegistry → MouseHook + AppFilter)

## Done
- Estructura `.agents/` creada y `AGENTS.md` fusionado.
- `docs/` obsoleto limpiado y proyecto migrado a `.NET 11` (`net11.0-windows7.0`, C# 15).
- `WindowManager` movido de `Modules/` a `Infra/WindowManagement/`.
- `Modelo de Perfiles + Filtros y persistencia (.rxconfig)` cerrado: modelos en `Modules/Profiles/`, `ConfigStorage` (`.rxconfig`), wiring en `App`/`AppSettings`/`Loader`, VMs + `InicioPage`/`PerfilesPage` sin mocks y `d:Visibility` documentado en `STACK.md`.

## In progress
- Ninguno (cambios de Perfiles/Filtros verificados en ejecución, pendientes de commit).

## Next
1. Conectar Remapping end-to-end (`Loader` → `MouseReasignRegistry` → `MouseHook` + `AppFilter`).
2. CRUD visual de Perfiles, Filtros y Remaps en Settings.
3. Migrar `ConfigStorage` a `LocalSettingsJson` cuando soporte rutas custom.

## Blockers y preguntas
- Ninguno.

## Do not touch yet
- Items bajo `Later` en `.agents/ROADMAP.md` (`TestsWindow` cleanup, `TestLangChange()`).
- Todo lo que entre en `Out of scope` en `.agents/PROJECT.md`.

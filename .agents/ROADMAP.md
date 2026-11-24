# Roadmap

Solo se trabaja en el ítem marcado `← CURRENT`.

## Final goal
Ninguna, proyecto continuo.

## Current focus ← CURRENT
UI (mocks en `Infra/Dev/`) y Backend de CRUD Perfiles/Filtros/Remaps por separado (contratos 100% compatibles para wiring)
Done when:
- [ ] Mocks de datos/acciones coherentes en `Raxer/Infra/Dev/` (compatibles 1:1 con `Modules/Profiles/` y `Modules/Remapping/`).
- [ ] Vistas/interacciones de `Settings` (`PerfilesPage`, `FiltrosPage`, `InicioPage`) iteradas sobre mocks en `Infra/Dev/`.
- [ ] Operaciones CRUD de backend (perfiles, filtros, remaps y persistencia) listas e independientes de la UI.
- [ ] Verificado en compilación/diseñador por el developer.

## Next
1. Wiring final UI ↔ Backend de CRUD Perfiles/Filtros/Remaps.

## Completed
- [x] Modelo de Perfiles + Filtros y persistencia (`.rxconfig`) — spec: `.agents/specs/profiles-and-filters.md`
- [x] Conectar Remapping end-to-end (`Loader` → `MouseReasignRegistry` → `MouseHook` + `AppFilter`) — spec: `.agents/specs/remapping-end-to-end.md`

## Later
- Limpiar cambios pendientes de `TestsWindow.xaml/.cs` (decidir commit propio).
- Quitar hook de prueba `TestLangChange()` en `Settings.xaml.cs` antes de release.

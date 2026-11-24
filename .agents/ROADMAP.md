# Roadmap

Solo se trabaja en el ítem marcado `← CURRENT`.

## Final goal
Ninguna, proyecto continuo.

## Current focus ← CURRENT
Conectar Remapping end-to-end (`Loader` → `MouseReasignRegistry` → `MouseHook` + `AppFilter`)
Done when:
- [ ] Traducir `Profile.Remaps` + `FilterDefinition.ToAppFilter()` hacia `MouseReasignRegistry` y `Modules/Actions`.
- [ ] Enganchar `MouseHook.Start()`/`Stop()` en `Loader` y reactualizar al cambiar `ActiveProfileId`.
- [ ] Verificado en ejecución por el developer.

## Next
1. CRUD visual de Perfiles, Filtros y Remaps en Settings.

## Completed
- [x] Modelo de Perfiles + Filtros y persistencia (`.rxconfig`) — spec: `.agents/specs/profiles-and-filters.md`

## Later
- Limpiar cambios pendientes de `TestsWindow.xaml/.cs` (decidir commit propio).
- Quitar hook de prueba `TestLangChange()` en `Settings.xaml.cs` antes de release.

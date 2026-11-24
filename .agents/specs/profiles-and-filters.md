# Spec: Modelo de Perfiles + Filtros y persistencia (.rxconfig)

Status: done
Focus: Modelo de Perfiles + Filtros y persistencia (.rxconfig)
<!-- Statuses: draft, in progress, done. -->

## What it does
Define los modelos planos de dominio para `Profile`, `FilterDefinition`, `RemapEntry`, `ActionKind` y `RaxerConfig`, junto con su persistencia JSON portable en `.rxconfig` (`ConfigStorage` usando `System.Text.Json`), conectados a `App.Config`, `AppSettings`, `Loader` y los ViewModels de `Settings`.

## Out of scope
- Conectar los remaps cargados al hook de mouse (`MouseHook` / `MouseReasignRegistry` / `Accion`).
- CRUD y editor visual de perfiles, filtros y remaps en la UI.
- Selector interactivo de archivo `.rxconfig` o cambio en caliente desde `InicioPage`.
- Migración de `ConfigStorage` a `LocalSettingsJson` (queda preparada para cuando la librería soporte rutas/archivos custom).

## Behavior and edge cases
- `ConfigStorage.DefaultPath` apunta a `%LocalAppData%\Raxer\config.rxconfig`, o usa `AppSettings.ConfigPath` si está configurado.
- Si el archivo `.rxconfig` no existe al arrancar, `ConfigStorage.Load` crea uno por defecto con un perfil `"Default"` y lo guarda en disco.
- Si el JSON está corrupto, es nulo o queda sin perfiles, registra el fallo vía `Log(...)` y garantiza al menos un perfil `"Default"`.
- `FilterDefinition` es independiente del perfil; `Profile.FilterId` referencia 0 o 1 filtro por ID y `ToAppFilter()` genera el `AppFilter` inmutable para runtime.
- `Loader.Startup()` valida `AppSettings.ActiveProfileId` contra `App.Config.Profiles` (si falta o no existe, selecciona el primero).
- Los PageVMs (`PerfilesVM`, `FiltrosVM`, `InicioVM`) toleran `App.Config == null` para no romper el diseñador XAML.

## Files involved
- `Raxer/Modules/Profiles/ActionKind.cs`
- `Raxer/Modules/Profiles/RemapEntry.cs`
- `Raxer/Modules/Profiles/FilterDefinition.cs`
- `Raxer/Modules/Profiles/Profile.cs`
- `Raxer/Modules/Profiles/RaxerConfig.cs`
- `Raxer/Modules/Profiles/ConfigStorage.cs`
- `Raxer/Modules/Settings/AppSettings.cs`
- `Raxer/App.xaml.cs`
- `Raxer/Modules/Loader/Loader.cs`
- `Raxer/Modules/Settings/PageVMs/PerfilesVM.cs`
- `Raxer/Modules/Settings/PageVMs/FiltrosVM.cs`
- `Raxer/Modules/Settings/PageVMs/InicioVM.cs`
- `Raxer/Modules/Settings/Pages/InicioPage.xaml`
- `Raxer/Modules/Settings/Pages/PerfilesPage.xaml`

## Acceptance criteria
- [x] El proyecto compila limpio en Visual Studio sin errores ni advertencias de modelos/VMs.
- [x] Al arrancar la app por primera vez, se crea `config.rxconfig` en `%LocalAppData%\Raxer\` con el perfil `"Default"` y se carga sin errores.
- [x] `InicioPage`, `PerfilesPage` y `FiltrosPage` abren sin datos mock (`DemoProfile` / `DemoFilter`) ni excepciones.

## Related decisions
- D-002

# Log

Prepend-only (más reciente primero), una entrada por sesión (`## YYYY-MM-DD (hh:mm am/pm) — <título>`, 12h). Nunca leer completo: cuando haya duda, leer solo las primeras 20 líneas.

## 2026-11-23 (06:54 pm) — Migración a .NET 11 y limpieza de docs
- Done: Target actualizado a `net11.0-windows7.0` (C# 15), compilando limpio; eliminada carpeta `docs/` y referencias al código viejo.
- Pending: Definir próximo foco en `.agents/ROADMAP.md`.

## 2026-11-23 (06:30 pm) — Bootstrap de contexto (.agents/)
- Done: Creada estructura `.agents/`, fusionado `AGENTS.md` y migrado historial previo desde `AGENTS.md`.
- Pending: Revisar `.agents/PROJECT.md` y `.agents/ROADMAP.md`; iniciar migración a `.NET 11`.

## 2026-08-17 — i18n con ResxDictionary + resx
- `ResxDictionary.cs` (ResourceDictionary que vuelca el ResourceSet de `Properties.Resources` a keys) en `Infra/Lang/` (reemplazado luego por paquete `LangRX` en commit `a26d1c9`).
- `App.xaml`, `Loader.cs`, `Settings.xaml` y `TrayIcon.cs` conectados a recursos `.resx` con keys en kebab-case.
- Commit `84df97d` en `rewrite`, pusheado a `origin/rewrite`.
- Pending: `TestsWindow.xaml/.cs` con cambios sin commitear; `TestLangChange()` de prueba en `Settings.xaml.cs` por quitar antes de release.

## 2026-08-13/14 — Scaffolding completo del rewrite
- `Infra/Native` (`Hook.cs`, `WinApi.cs`, `Constants.cs`, `Enums.cs`), `Infra/Storage` (`AppSettings.cs`), `Infra/Tools`, `Infra/Shared`, `Infra/Dev`.
- `Modules/` (`Remapping`, `Actions`, `Loader`, `Tray`, `Settings`, `WindowManagement`), `App.xaml/cs` con `ShutdownMode.OnExplicitShutdown`, y `Assets` SVG/`.ico`.
- Verificación: `dotnet build` 0 warnings / 0 errors. Push a rama `rewrite`.

## 2026-08-13 — Migración a `[LibraryImport]`
- Todos los P/Invoke de `Infra/Native` pasaron de `[DllImport]` a `[LibraryImport]` (`WinApi.cs` 19 métodos, `SendInput` en `Messenger.cs` → `partial`).
- `bool` con `[return: MarshalAs(UnmanagedType.Bool)]`, `EntryPoint` preservado cuando difiere, `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>` en `Raxer.csproj`.
- Verificación: `dotnet build` 0 warnings / 0 errors. Push a rama `rewrite`.

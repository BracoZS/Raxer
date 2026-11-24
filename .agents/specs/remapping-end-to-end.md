# Spec: Conectar Remapping end-to-end

Status: done
Focus: Conectar Remapping end-to-end (`Loader` → `MouseReasignRegistry` → `MouseHook` + `AppFilter`)
<!-- Statuses: draft, in progress, done. -->

## What it does
Conecta el ciclo completo de remapping en runtime: traduce los `RemapEntry` y `FilterDefinition` del perfil activo en `App.Config` hacia `MouseReasignRegistry`, activa/desactiva `MouseHook` en `Loader.Startup()`/`Shutdown()`, filtra por modificadores y aplicación bajo el cursor en `MouseDispatcher`, y recarga el mapa al cambiar el perfil activo desde `PerfilesVM`.

## Out of scope
- Editor visual o CRUD de remaps, perfiles y filtros en la UI de `Settings`.
- Atajo de teclado global para cambiar perfil (`Profile.Shortcut`).
- Soporte de eventos `Hold`/`TeclaDown` + `TeclaUp` continuos o `Dragmove` (`StartDragPoint`).
- Normalización de sufijo `.exe` en `AppFilter`.

## Behavior and edge cases
- `MouseHook.Start()` ignora llamadas repetidas si el hook ya está instalado; `Stop()` desinstala, resetea `_hookID = nint.Zero` y solo registra log si estaba activo.
- `MouseHook.LowLevelMouseProc` ignora eventos sintéticos (`(hook.Flags & 1) != 0`, `LLMHF_INJECTED`) para evitar loops cuando se ejecuta `ActionKind.MouseEvent`.
- `MouseReasignRegistry` indexa slots `(MouseAccion, Modificador)` con un arreglo plano (16 combinaciones `Alt|Control|Shift|Win`) más bitmask `_registeredTriggers` para `HasTrigger` O(1) zero-allocation en el hot path.
- `MouseDispatcher.Handle` solo consulta `SystemTools.GetPressedModificador()` si `HasTrigger(accion)` es `true`, y solo llama `SystemTools.GetCursorAppExeName()` si `ActiveFilter.IsActive` es `true`.
- `ProfileMapper.Apply` limpia primero el registry; si `profile` es `null`, queda en passthrough. Entradas con `Trigger == MouseAccion.None`, `Action == ActionKind.None` o argumentos inválidos se registran en log (DEBUG) y se ignoran.
- Al cambiar `PerfilSeleccionado` en `PerfilesVM`, actualiza `App.Settings.ActiveProfileId` y reaplica el perfil en caliente vía `Loader.ApplyActiveProfile()`.

## Files involved
- `Raxer/Modules/Remapping/AppFilter.cs`
- `Raxer/Modules/Remapping/MouseReasignRegistry.cs`
- `Raxer/Modules/Remapping/MouseDispatcher.cs`
- `Raxer/Modules/Remapping/ProfileMapper.cs`
- `Raxer/Infra/Native/Hook.cs`
- `Raxer/Modules/Loader/Loader.cs`
- `Raxer/Modules/Settings/PageVMs/PerfilesVM.cs`

## Acceptance criteria
- [x] El proyecto compila limpio en Visual Studio sin errores ni advertencias en Remapping/Loader/Hook.
- [x] Al arrancar la app, `Loader` aplica el perfil activo e inicia `MouseHook`; al cerrar detiene `MouseHook` y limpia `MouseReasignRegistry`.
- [x] Con un remap configurado en `config.rxconfig` (p. ej. `SideButton1Down` → `MediaPlayPause` o `Copy`), el botón ejecuta la acción y consume el evento original, respetando `Modifiers` y `FilterDefinition` cuando están configurados.
- [x] Cambiar de perfil en `PerfilesPage` reaplica los remaps en caliente.

## Related decisions
- D-002

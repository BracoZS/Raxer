using Raxer.Infra.Native;
using Raxer.Modules.Actions;
using Raxer.Modules.Profiles;
using static Raxer.Infra.Native.Messenger;

namespace Raxer.Modules.Remapping;

/// <summary>
/// Traduce un <see cref="Profile"/> y su <see cref="FilterDefinition"/> al estado runtime de <see cref="MouseReasignRegistry"/>.
/// </summary>
public static class ProfileMapper
{
    public static void Apply(Profile? profile, RaxerConfig? config)
    {
        MouseReasignRegistry.Limpiar();

        if (profile is null)
        {
            Log("Remapping: sin perfil activo (passthrough)");
            return;
        }

        var filterDef = config?.FindFilter(profile.FilterId);
        MouseReasignRegistry.ActiveFilter = filterDef?.ToAppFilter() ?? AppFilter.None;

        var applied = 0;
        foreach (var entry in profile.Remaps)
        {
            if (entry.Trigger == MouseAccion.None || entry.Action == ActionKind.None)
                continue;

            var handler = ResolveAction(entry);
            if (handler is null)
                continue;

            MouseReasignRegistry.Marcar(entry.Trigger, entry.Modifiers, handler);
            applied++;
        }

        Log($"Remapping: perfil '{profile.Name}' aplicado ({applied} remaps, filtro: {filterDef?.Name ?? "ninguno"})");
    }

    internal static Action? ResolveAction(RemapEntry entry) => entry.Action switch
    {
        // Edición
        ActionKind.Copy => Accion.Copiar,
        ActionKind.Paste => Accion.Pegar,
        ActionKind.Cut => Accion.Cortar,
        ActionKind.Undo => Accion.Deshacer,
        ActionKind.Redo => Accion.Rehacer,
        ActionKind.SelectAll => Accion.SeleccionarTodo,
        ActionKind.Save => Accion.Guardar,
        ActionKind.OpenFile => Accion.AbrirArchivo,
        ActionKind.NewFile => Accion.Nuevo,
        ActionKind.Find => Accion.Buscar,
        ActionKind.Print => Accion.Imprimir,

        // Multimedia
        ActionKind.MediaMute => Accion.MediaMute,
        ActionKind.MediaVolumeDown => Accion.MediaBajarVolumen,
        ActionKind.MediaVolumeUp => Accion.MediaSubirVolumen,
        ActionKind.MediaPrevTrack => Accion.MediaPistaAnterior,
        ActionKind.MediaPlayPause => Accion.MediaPlayPause,
        ActionKind.MediaNextTrack => Accion.MediaPistaSiguiente,
        ActionKind.MediaStop => Accion.MediaStop,
        ActionKind.MicToggleMute => Accion.SwitchMicrofono,
        ActionKind.MicVolumeUp => Accion.MicrofonoSubirVolumen,
        ActionKind.MicVolumeDown => Accion.MicrofonoBajarVolumen,

        // Ventanas
        ActionKind.WindowMinimize => Accion.MinimizarVentana,
        ActionKind.WindowMaximize => Accion.MaximizarVentana,
        ActionKind.WindowClose => Accion.CerrarVentana,
        ActionKind.WindowMinimizeAll => Accion.MinimizarTodo,
        ActionKind.WindowKill => Accion.KillWindow,
        ActionKind.WindowSmartMinimize => Accion.SmartSwitchMinimizar,
        ActionKind.WindowSmartMaximize => Accion.SmartSwitchMaximizar,

        // Mouse y puntero
        ActionKind.MouseEvent when Enum.TryParse<MouseArti>(entry.Arg, ignoreCase: true, out var btn)
            => () => Accion.LanzarMouseEvent(btn),
        ActionKind.SetPointerSpeed when int.TryParse(entry.Arg, out var speed)
            => () => Accion.SetPunteroSpeed(speed),
        ActionKind.ChangePointerSpeed when int.TryParse(entry.Arg, out var delta)
            => () => Accion.ChangePunteroSpeed(delta),
        ActionKind.ResetPointerSpeed => Accion.ResetMouseSpeed,
        ActionKind.LockAxisX => Accion.FijarEjeX,
        ActionKind.LockAxisY => Accion.FijarEjeY,
        ActionKind.UnlockAxis => Accion.SoltarEje,

        // Teclado
        ActionKind.SendKey when entry.Keys is [var key, ..]
            => () => Accion.LanzarTecla(key),
        ActionKind.SendKeyCombo when entry.Keys is { Count: > 0 } keys
            => CreateComboHandler(keys),

        // Abrir
        ActionKind.OpenUrl when entry.Arg is { Length: > 0 } url && !string.IsNullOrWhiteSpace(url)
            => () => Accion.IrAWeb(url),
        ActionKind.OpenPath when entry.Arg is { Length: > 0 } path && !string.IsNullOrWhiteSpace(path)
            => () => Accion.AbrirRuta(path),

        _ => LogIgnored(entry)
    };

    private static Action CreateComboHandler(List<KeyArti> keys)
    {
        var arr = keys.ToArray();
        return () => Accion.LanzarCombo(arr);
    }

    private static Action? LogIgnored(RemapEntry entry)
    {
        Log($"Remapping: entrada ignorada ({entry.Trigger} -> {entry.Action})");
        return null;
    }
}

using System.Runtime.CompilerServices;
using Raxer.Infra.Native;

namespace Raxer.Modules.Remapping;

/// <summary>
/// Marca qué acciones del mouse (+ modificadores) están reasignadas y expone el filtro activo.
/// El hook consulta esto en zero-allocation para decidir si consume el evento o lo deja pasar.
/// </summary>
public static class MouseReasignRegistry
{
    private const int ModMask = 0x0F;
    private const int ModCount = 16; // combinaciones de Alt(1), Control(2), Shift(4), Win(8)

    private static readonly Action?[] _remappedActions =
        new Action?[Enum.GetValues<MouseAccion>().Length * ModCount];

    // Bitmask por (int)MouseAccion para early-out O(1) antes de leer GetAsyncKeyState.
    private static int _registeredTriggers;
    private static AppFilter _activeFilter = AppFilter.None;

    public static AppFilter ActiveFilter
    {
        get => Volatile.Read(ref _activeFilter);
        set => Volatile.Write(ref _activeFilter, value ?? AppFilter.None);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static int Index(MouseAccion accion, Modificador mods)
        => ((int)accion * ModCount) + ((int)mods & ModMask);

    /// <summary>Indica rápido si la acción tiene al menos un remap registrado (con o sin modificadores).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool HasTrigger(MouseAccion accion)
        => (Volatile.Read(ref _registeredTriggers) & (1 << (int)accion)) != 0;

    /// <summary>Obtiene el remap registrado para la acción y modificadores. null = no reasignada.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Action? GetRemap(MouseAccion accion, Modificador mods = Modificador.None)
        => Volatile.Read(ref _remappedActions[Index(accion, mods)]);

    /// <summary>Marca la acción sin modificadores como reasignada y guarda su callback.</summary>
    public static void Marcar(MouseAccion accion, Action handler)
        => Marcar(accion, Modificador.None, handler);

    /// <summary>Marca la acción + modificadores como reasignada y guarda su callback.</summary>
    public static void Marcar(MouseAccion accion, Modificador mods, Action handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        Volatile.Write(ref _remappedActions[Index(accion, mods)], handler);
        Interlocked.Or(ref _registeredTriggers, 1 << (int)accion);
    }

    /// <summary>Desmarca la acción + modificadores (vuelve a pasar al sistema).</summary>
    public static void Desmarcar(MouseAccion accion, Modificador mods = Modificador.None)
    {
        Volatile.Write(ref _remappedActions[Index(accion, mods)], null);

        int baseIndex = (int)accion * ModCount;
        for (int i = 0; i < ModCount; i++)
        {
            if (Volatile.Read(ref _remappedActions[baseIndex + i]) is not null)
                return;
        }

        Interlocked.And(ref _registeredTriggers, ~(1 << (int)accion));
    }

    /// <summary>Limpia todas las marcas y resetea el filtro activo.</summary>
    public static void Limpiar()
    {
        Volatile.Write(ref _registeredTriggers, 0);
        Array.Clear(_remappedActions);
        Volatile.Write(ref _activeFilter, AppFilter.None);
    }
}

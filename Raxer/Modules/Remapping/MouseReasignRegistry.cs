using System.Runtime.CompilerServices;

namespace Raxer.Modules.Remapping;

/// <summary>
/// Marca qué acciones del mouse están reasignadas.
/// El hook consulta esto para decidir si consume el evento o lo deja pasar.
/// </summary>
public static class MouseReasignRegistry
{
    // Remap por cada MouseAccion reasignada. null = no reasignada.
    private static readonly Action?[] _remappedActions =
        new Action?[Enum.GetValues<MouseAccion>().Length];

    /// <summary>Obtiene el remap registrado para la acción. null = no reasignada.</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Action? GetRemap(MouseAccion accion)
    {
        return Volatile.Read(ref _remappedActions[(int)accion]);
    }

    /// <summary>Marca la acción como reasignada y guarda su callback.</summary>
    public static void Marcar(MouseAccion accion, Action handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        Volatile.Write(ref _remappedActions[(int)accion], handler);
    }

    /// <summary>Desmarca la acción (vuelve a pasar al sistema).</summary>
    public static void Desmarcar(MouseAccion accion)
    {
        Volatile.Write(ref _remappedActions[(int)accion], null);
    }

    /// <summary>Limpia todas las marcas (reset de mapa).</summary>
    public static void Limpiar()
    {
        Array.Clear(_remappedActions);
    }
}

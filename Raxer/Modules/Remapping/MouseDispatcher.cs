using System.Runtime.CompilerServices;
using Raxer.Infra.Tools;
using ResultPattern;

namespace Raxer.Modules.Remapping;

public static class MouseDispatcher
{
    /// <summary>Ejecuta el handler si la acción está reasignada y pasa el filtro de apps.
    /// Devuelve true si consumió el evento (el hook no lo pasa al sistema).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Handle(MouseAccion accion)
    {
        if (!MouseReasignRegistry.HasTrigger(accion))
            return false;

        var mods = SystemTools.GetPressedModificador();
        var remap = MouseReasignRegistry.GetRemap(accion, mods);
        if (remap is null)
            return false;

        var filter = MouseReasignRegistry.ActiveFilter;
        if (filter.IsActive && filter.IsBlocked(SystemTools.GetCursorAppExeName()))
            return false;

        // fire and forget
        ThreadPool.UnsafeQueueUserWorkItem(
            static state =>
            {
                Result.Try(state)
                    .OnFailure(error => Log(error));
            },
            remap,
            preferLocal: true);

        return true;
    }
}
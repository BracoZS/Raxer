using ResultPattern;
using System.Runtime.CompilerServices;

namespace Raxer.Modules.Remapping;

public static class MouseDispatcher
{
    /// <summary>Ejecuta el handler si la acción está reasignada.
    /// Devuelve true si consumió el evento (el hook no lo pasa al sistema).</summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Handle(MouseAccion accion)
    {
        var remap = MouseReasignRegistry.GetRemap(accion);
        if (remap is null) return false;

        // fire and forget
        ThreadPool.UnsafeQueueUserWorkItem(
            static state =>
            {
                Result.Try(state)
                    .OnFailure(error => Log(error));
            },
            remap!,
            preferLocal: true);

        return true;
    }
}

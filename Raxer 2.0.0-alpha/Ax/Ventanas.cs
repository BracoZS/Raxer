using static Raxer_2_alpha.Utilidades.WinApi;
using static Raxer_2_alpha.Utilidades.Auxiliares;
using Raxer_2_alpha.Modelos;
using System.Diagnostics;
using System.Threading;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    const uint WM_CLOSE = 0x0010;

    private static IntPtr lastMin;
    private static IntPtr lastMax;
    private static Punto mouseDownPos = new Punto();
    private static Punto mouseClientPos = new Punto();

    internal static void MinimizarVentana()
    {
        appBajoCursor = GetCursorMainHandle();

        if(appBajoCursor != GetForegroundWindow())
            SetForegroundWindow(appBajoCursor);

        while(!IsIconic(appBajoCursor))
        {
            LanzarCombo(KeyN.WIN_L, KeyN.DOWN);
            Thread.Sleep(50);
        }
    }

    internal static void MaximizarVentana()
    {
        appBajoCursor = GetCursorMainHandle();

        if(!IsZoomed(appBajoCursor))
        {
            if(appBajoCursor != GetForegroundWindow())
                SetForegroundWindow(appBajoCursor);

            LanzarCombo(KeyN.WIN_L, KeyN.UP);
        }
    }

    internal static void CerrarVentana() => PostMessage(GetCursorMainHandle(), WM_CLOSE, nint.Zero, 0);

    internal static void MinimizarTodo() => LanzarCombo(KeyN.WIN_L, KeyN.M);

    internal static void SwitchMinimizar()
    {
        if(!IsIconic(lastMin))
        {
            MinimizarVentana();
            lastMin = appBajoCursor;
        }
        else
        {
            SwitchToThisWindow(lastMin, true);
            lastMin = IntPtr.Zero;
        }
    }

    internal static void SwitchMaximizar()
    {
        if(!IsZoomed(lastMax))
        {
            MaximizarVentana();
            lastMax = appBajoCursor;
        }
        else
        {
            if(IsZoomed(lastMax))
                LanzarCombo(KeyN.WIN_L, KeyN.DOWN);
            
            lastMax = IntPtr.Zero;
        }
    }

    private static void MoverAtDrag()
    {
        mouseDownPos = GetRataPos();

        SetWindowPos(
            appBajoCursor,
            0,
            mouseDownPos.x - mouseClientPos.x,
            mouseDownPos.y - mouseClientPos.y,
            0,
            0,
            SWP_NOSIZE | SWP_NOZORDER
            );
    }

    internal static void InicioDragPoint()
    {
        mouseDownPos = GetRataPos();

        appBajoCursor = GetCursorMainHandle();
        _ = GetWindowRect(appBajoCursor, out RectAPI zoneVentana);

        mouseClientPos.x = mouseDownPos.x - zoneVentana.left;
        mouseClientPos.y = mouseDownPos.y - zoneVentana.top;

        MouseMap.Actual.Movimiento.LowReasignacion(MoverAtDrag);
    }

    internal static void FinDragPoint() => MouseMap.Actual.Movimiento.EndSeg();

    internal static void KillWindow() => Process.GetProcessById(GetCursorProcessID()).Kill();
}

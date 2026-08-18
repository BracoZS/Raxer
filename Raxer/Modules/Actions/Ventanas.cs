using System.Diagnostics;
using Raxer.Infra.Native;
using Raxer.Infra.Tools;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    private static IntPtr _lastMin;
    private static IntPtr _lastMax;

    public static void MinimizarVentana()
    {
        _cursorOverApp = SystemTools.GetCursorMainHandle();
        if (_cursorOverApp != WinApi.GetForegroundWindow())
        {
            WinApi.SetForegroundWindow(_cursorOverApp);
        }
        LanzarCombo(KeyArti.WIN_L, KeyArti.DOWN);
    }

    public static void MaximizarVentana()
    {
        _cursorOverApp = SystemTools.GetCursorMainHandle();
        if (!WinApi.IsZoomed(_cursorOverApp) && _cursorOverApp != WinApi.GetForegroundWindow())
        {
            WinApi.SetForegroundWindow(_cursorOverApp);
        }
        LanzarCombo(KeyCombos.Maximizar);
    }

    public static void CerrarVentana()
    {
        WinApi.PostMessage(
            SystemTools.GetCursorMainHandle(),
            WindowConstants.WM_CLOSE,
            IntPtr.Zero,
            0);
    }

    public static void MinimizarTodo()
    {
        LanzarCombo(KeyCombos.MinimizarTodo);
    }

    public static void KillWindow()
    {
        try
        {
            using var process = Process.GetProcessById(SystemTools.GetCursorProcessID());
            process.Kill();
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al matar proceso: {ex.Message}");
        }
    }

    public static void SmartSwitchMinimizar()
    {
        if (!WinApi.IsIconic(_lastMin))
        {
            MinimizarVentana();
            _lastMin = _cursorOverApp;
        }
        else
        {
            WinApi.SwitchToThisWindow(_lastMin, true);
            _lastMin = IntPtr.Zero;
        }
    }

    public static void SmartSwitchMaximizar()
    {
        if (!WinApi.IsZoomed(_lastMax))
        {
            MaximizarVentana();
            _lastMax = _cursorOverApp;
        }
        else
        {
            if (WinApi.IsZoomed(_lastMax))
            {
        LanzarCombo(KeyCombos.Minimizar);
            }
            _lastMax = IntPtr.Zero;
        }
    }

    #region Dragmove (temporal)
    private static Punto _mouseDownPos;
    private static Punto _mouseClientPos;

    private static void MoverAtDrag()
    {
        _mouseDownPos = SystemTools.GetRataPos();

        WinApi.SetWindowPos(
            _cursorOverApp,
            0,
            _mouseDownPos.X - _mouseClientPos.X,
            _mouseDownPos.Y - _mouseClientPos.Y,
            0,
            0,
            WindowConstants.SWP_NOSIZE | WindowConstants.SWP_NOZORDER
        );
    }

    internal static void StartDragPoint()
    {
        _mouseDownPos = SystemTools.GetRataPos();
        _cursorOverApp = SystemTools.GetCursorMainHandle(_mouseDownPos);
        _ = WinApi.GetWindowRect(_cursorOverApp, out Rectangulo zoneVentana);

        _mouseClientPos.X = _mouseDownPos.X - zoneVentana.left;
        _mouseClientPos.Y = _mouseDownPos.Y - zoneVentana.top;

        // NOTA: Se asigna la acción de movimiento al sensor de movimiento
        // Esto se enlazará con la clase de remapeo una vez que la mudemos
        //MouseMap.MouseMapActual.Movimiento.LowReasignacion(MoverAtDrag);
    }

    internal static void EndDragPoint()
    {
        //MouseMap.MouseMapActual.Movimiento.End();
    }
    #endregion
}

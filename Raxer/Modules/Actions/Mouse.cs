using Raxer.Infra.Native;
using Raxer.Infra.Tools;
using static Raxer.Infra.Native.Messenger;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    #region Mouse event
    private static IntPtr _cursorOverApp;

    public static void LanzarMouseEvent(MouseArti botonMouse, int mousedata = 0) // up and down, extras (all buttons)
    {
        var input = new INPUT
        {
            type = InputEventType.Mouse,
            union = new MKH_INPUTUNION
            {
                Mouse = new MouseInput
                {
                    dwFlags = botonMouse,
                    mouseData = mousedata 
                }
            }
        };

        INPUT[] inputs = [input];
        SendInput(1, inputs, _genSize);
    }
    #endregion

    #region Puntero del mouse
    private static RectApi _axisX = new() { left = 0, right = MouseConstants.AxisXMax };
    private static RectApi _axisY = new() { top = 0, bottom = MouseConstants.AxisYMax };

    public static void SetPunteroSpeed(int velocidad)
    {
        int speed = Math.Clamp(velocidad, 1, 20);
        SystemTools.SetMouseSpeed((uint)speed);
    }

    public static void ChangePunteroSpeed(int cantidad)
    {
        int currentSpeed = SystemTools.GetMouseSpeedValue();
        SetPunteroSpeed(currentSpeed + cantidad);
    }

    public static void ResetMouseSpeed()
        => SetPunteroSpeed(Infra.Native.MouseConstants.defaultSystemSpeed);

    public static void FijarEjeX()
    {
        var cursorPos = SystemTools.GetRataPos();
        _axisX.top = cursorPos.Y;
        _axisX.bottom = cursorPos.Y + 1;
        WinApi.ClipCursor(_axisX);
    }

    public static void FijarEjeY()
    {
        var cursorPos = SystemTools.GetRataPos();
        _axisY.left = cursorPos.X;
        _axisY.right = cursorPos.X + 1;
        WinApi.ClipCursor(_axisY);
    }

    public static void SoltarEje()
    {
        WinApi.UnclipCursor(IntPtr.Zero);
    }
    #endregion
}

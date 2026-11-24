using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using Raxer.Modules.Remapping;

namespace Raxer.Infra.Native;

[SuppressUnmanagedCodeSecurity]
internal static partial class MouseHook
{
    private static nint _hookID = nint.Zero;
    private static LowHookProc _mouseProc = null!;
    private static nint _handled = 1;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MSLLHOOKSTRUCT
    {
        internal Punto Pt;
        internal int MouseData;   // int obligatorio wm_mousewheel (+↑ -↓, xbutton 1/2)
        internal uint Flags;      // 1 = generado por arti (ignorar)
        internal uint Time;
        internal nint DwExtraInfo;
    }

    public delegate nint LowHookProc(int nCode, nint wParam, nint lParam);

    public static void Start()
    {
        if (_hookID != nint.Zero)
            return;

        _mouseProc = LowLevelMouseProc;
        using var curProcess = Process.GetCurrentProcess();
        using var curModule = curProcess.MainModule!;
        _hookID = WinApi.SetWindowsHookEx(HookConstants.WH_MOUSE_LL, _mouseProc, WinApi.GetModuleHandle(curModule.ModuleName!), 0);

        Log($"Hook iniciado: {DateTime.Now}");
    }

    public static void Stop()
    {
        if (_hookID == nint.Zero)
            return;

        WinApi.UnhookWindowsHookEx(_hookID);
        _hookID = nint.Zero;

        Log($"Hook detenido: {DateTime.Now}");
    }

    /// <summary>
    /// Fun para el delegado que se setea para el hook
    /// </summary>
    /// <param name="nCode">Windows: >=0 → "mira/procesa el evento"; nCode < 0 → "no procesar, solo pasarlo"</param>
    /// <param name="wParam">evento del mouse</param>
    /// <param name="lParam">puntero al struct MSLLHOOKSTRUCT, con la información adicional del evento</param>
    /// <returns></returns>
    private unsafe static nint LowLevelMouseProc(int nCode, nint wParam, nint lParam)
    {
        // early return 🏍️
        if (nCode < 0 || lParam == nint.Zero)   // defensive, avoid read null lParam
            return WinApi.CallNextHookEx(_hookID, nCode, wParam, lParam);

        ref readonly var hook = ref *(MSLLHOOKSTRUCT*)lParam;
        if ((hook.Flags & 1) != 0)              // LLMHF_INJECTED: no re-procesar eventos sintéticos
            return WinApi.CallNextHookEx(_hookID, nCode, wParam, lParam);

        MouseAccion action;

        switch ((MouseMsg)wParam)
        {
            case MouseMsg.Move: // WM_MOUSEMOVE
                action = MouseAccion.Move;
                break;

            case MouseMsg.LeftButtonDown: // WM_LBUTTONDOWN
                action = MouseAccion.LeftDown;
                break;

            case MouseMsg.LeftButtonUp: // WM_LBUTTONUP
                action = MouseAccion.LeftUp;
                break;

            case MouseMsg.RightButtonDown: // WM_RBUTTONDOWN
                action = MouseAccion.RightDown;
                break;

            case MouseMsg.RightButtonUp: // WM_RBUTTONUP
                action = MouseAccion.RightUp;
                break;

            case MouseMsg.MiddleButtonDown: // WM_MBUTTONDOWN
                action = MouseAccion.MiddleDown;
                break;

            case MouseMsg.MiddleButtonUp: // WM_MBUTTONUP
                action = MouseAccion.MiddleUp;
                break;

            case MouseMsg.MouseWheel: // WM_MOUSEWHEEL
            {
                short wheelDelta = (short)(hook.MouseData >> 16);
                action = wheelDelta > 0
                    ? MouseAccion.WheelUp
                    : MouseAccion.WheelDown;
                break;
            }

            case MouseMsg.WheelHorizontal: // WM_MOUSEHWHEEL (Scroll Horizontal)
            {
                short hWheelDelta = (short)(hook.MouseData >> 16);
                action = hWheelDelta > 0
                    ? MouseAccion.WheelRight
                    : MouseAccion.WheelLeft;
                break;
            }

            case MouseMsg.XButtonDown: // WM_XBUTTONDOWN
            {
                ushort xButtonDown = (ushort)(hook.MouseData >> 16);
                action = xButtonDown == 1
                    ? MouseAccion.SideButton1Down
                    : MouseAccion.SideButton2Down;
                break;
            }

            case MouseMsg.XButtonUp: // WM_XBUTTONUP
            {
                ushort xButtonUp = (ushort)(hook.MouseData >> 16);
                action = xButtonUp == 1
                    ? MouseAccion.SideButton1Up
                    : MouseAccion.SideButton2Up;
                break;
            }

            default:
                return WinApi.CallNextHookEx(nint.Zero, nCode, wParam, lParam);
        }

        if (MouseDispatcher.Handle(action))
            return _handled;

        return WinApi.CallNextHookEx(nint.Zero, nCode, wParam, lParam);
    }
}

using System.Runtime.InteropServices;
using System.Security;
using static Raxer_2_alpha.Modelos.MouseMap;
using static Raxer_2_alpha.Utilidades.WinApi;

namespace Raxer_2_alpha.Utilidades;

[SuppressUnmanagedCodeSecurity]
internal static class SafeNativeMethods
{
    private const int mouse_ll = 14;
    private static IntPtr t = 1;
    private static nint _hookID = nint.Zero;
    private delegate IntPtr mouse_llProc(int ncode, IntPtr wParam, MSLLHOOKSTRUCT lParam);
    private static mouse_llProc _mouseProc;

    internal static bool IsRemapActive { get; private set; }

    [SuppressUnmanagedCodeSecurity, DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint SetWindowsHookEx(int idHook, mouse_llProc lpfn, nint hMod, uint dwThreadId);

    [SuppressUnmanagedCodeSecurity, DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(nint hhk);

    [SuppressUnmanagedCodeSecurity, DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern nint CallNextHookEx(IntPtr hhk, int nCode, nint wParam, MSLLHOOKSTRUCT lParam);

    [SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern nint GetModuleHandle(string lpModuleName);


    [StructLayout(LayoutKind.Sequential)]
    private struct MSLLHOOKSTRUCT
    {
        public Punto pt;
        public int mouseData;
        public int flags;
        public int time;
        public nint dwExtraInfo;
    }

    enum MouseMsg
    {
        move = 0x0200,
        leftButtonDown = 0x0201,
        leftButtonUp = 0x0202,
        leftButtonDoubleClick = 0x0203,
        rightButtonDown = 0x0204,
        rightButtonUp = 0x0205,
        rightButtonDoubleClick = 0x0206,
        wheelButtonDown = 0x0207,
        wheelButtonUp = 0x0208,
        wheelVGiro = 0x020A,
        wheelH = 0x020E,
        wheelDoubleClick = 0x0209,
        xButtonDown = 0x020B,
        xButtonUp = 0x020C,
        xButtonDoubleClick = 0x020D
    }

    public static void Start()
    {
        _mouseProc = llMouseProc;
        _hookID = setHook(_mouseProc);

        IsRemapActive = true;
    }

    public static void Stop()
    {
        UnhookWindowsHookEx(_hookID); 

        IsRemapActive = false;
    }

    private static nint setHook(mouse_llProc proc)
    {
        using(ProcessModule curModule = Process.GetCurrentProcess().MainModule)
        {
            return SetWindowsHookEx(
                mouse_ll,
                proc,
                GetModuleHandle(curModule.ModuleName),
                0);
        }
    }

    private static IntPtr llMouseProc(int nCode, nint wParam, MSLLHOOKSTRUCT lParam)
    {
        if(nCode >= 0 && lParam.flags != 1)
        {
            switch((MouseMsg)wParam)
            {
                case MouseMsg.move:
                    Actual.Movimiento.verificarManejo();
                    break;

                case MouseMsg.leftButtonDown:
                    if(Actual.Boton1.VerificarManejo())
                        return t;
                    break;
                case MouseMsg.leftButtonUp:
                    if(Actual.Boton1.VerificarManejo(EstadoBoton.up))
                        return t;
                    break;

                case MouseMsg.rightButtonDown:
                    if(Actual.Boton2.VerificarManejo())
                        return t;
                    break;
                case MouseMsg.rightButtonUp:
                    if(Actual.Boton2.VerificarManejo(EstadoBoton.up))
                        return t;
                    break;

                case MouseMsg.wheelButtonDown:
                    if(Actual.Boton3.VerificarManejo())
                        return t;
                    break;
                case MouseMsg.wheelButtonUp:
                    if(Actual.Boton3.VerificarManejo(EstadoBoton.up))
                        return t;
                    break;

                case MouseMsg.xButtonDown:
                    if((lParam.mouseData >> 16) == 1 && Actual.Boton4.VerificarManejo())
                        return t;
                    else if(Actual.Boton5.VerificarManejo())
                        return t;
                    break;
                case MouseMsg.xButtonUp:
                    if((lParam.mouseData >> 16) == 1 && Actual.Boton4.VerificarManejo(EstadoBoton.up))
                        return t;
                    else if(Actual.Boton5.VerificarManejo(EstadoBoton.up))
                        return t;
                    break;
            }
        }

        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }
}

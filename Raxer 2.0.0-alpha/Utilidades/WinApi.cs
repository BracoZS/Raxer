using System.Runtime.InteropServices;

namespace Raxer_2_alpha.Utilidades;

internal static class WinApi
{
    public const int WM_APPCOMMAND = 0x319;
    internal const uint SPI_GET_MOUSESPEED = 0x0070;      //112
    internal const uint SPI_SET_MOUSESPEED = 0x0071;      //113
    internal const uint SPIF_UPDATEINIFILE = 0x01;
    internal const uint SPIF_SENDCHANGE = 0x02;
    internal const short SWP_NOSIZE = 1;
    internal const short SWP_NOZORDER = 0X0004;

    [StructLayout(LayoutKind.Sequential)] 
    internal struct Punto
    {
        internal int x, y;
    }
    public struct RectAPI
    {
        public int left, top, right, bottom;
    }
    internal enum Ancestro
    {
        GetParent = 1,
        GetRoot = 2,
        GetRootOwner = 3
    }

    #region Ventanas
    // GET
    [DllImport("user32.dll")]
    public static extern bool IsIconic(IntPtr handle);

    [DllImport("user32.dll")]
    public static extern bool IsZoomed(IntPtr handle);

    [DllImport("user32.dll")]
    public static extern IntPtr GetForegroundWindow();

    // SET
    [DllImport("user32.dll")]
    public static extern int SetForegroundWindow(IntPtr hwnd);

    [DllImport("user32.dll")]
    public static extern bool SwitchToThisWindow(IntPtr handle, bool funknow);

    // MOVER
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool GetWindowRect(IntPtr hWnd, out RectAPI lpRect);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern IntPtr SetWindowPos(IntPtr hadnle, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    #endregion

    [DllImport("user32.dll")]
    internal static extern bool GetCursorPos(ref Punto pt);

    [DllImport("user32.dll")]
    internal static extern IntPtr WindowFromPoint(Punto p);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetAncestor(IntPtr hwnd, Ancestro gaFlags);

    [DllImport("user32.dll")]
    internal static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

    [DllImport("User32.dll")]
    internal static extern short GetAsyncKeyState(int keyCode);

    [DllImport("User32.dll", SetLastError = true)]
    internal static extern Boolean SystemParametersInfo(UInt32 uiAction, UInt32 uiParam, IntPtr pvParam, UInt32 fWinIni);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
    public static extern bool GetMouseSpeed(uint uiAction, uint uiParam, out uint pvParam, uint fWinIni);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
    public static extern bool SetMouseSpeed(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "ClipCursor")]
    internal static extern void ClipCursor(RectAPI lpRect);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "ClipCursor")]
    internal static extern int UnclipCursor(nint nullLpRect);

    [DllImport("user32.dll")]
    internal static extern bool PostMessage(nint hWnd, uint Msg, nint wParam, int lParam);
}


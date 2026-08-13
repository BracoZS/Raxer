using System;
using System.Runtime.InteropServices;

namespace Raxer.Infra.Native;

internal static partial class WinApi
{
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


    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool GetWindowRect(IntPtr hWnd, out RectApi lpRect);

    [DllImport("user32.dll", SetLastError = true)]
    internal static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    #endregion

    #region Coords mouse
    [DllImport("user32.dll")]
    internal static extern bool GetCursorPos(ref PointApi pt);
    #endregion

    #region Get Handles
    [DllImport("user32.dll")]
    internal static extern IntPtr WindowFromPoint(PointApi p);

    [DllImport("user32.dll")]
    internal static extern IntPtr GetAncestor(IntPtr hwnd, Ancestro gaFlags);

    #endregion

    #region ID
    [DllImport("user32.dll")]
    internal static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
    #endregion

    #region Estado de tecla
    [DllImport("user32.dll")]
    internal static extern short GetAsyncKeyState(int keyCode);
    #endregion

    #region Parámetros del sistema - SPI
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern bool SystemParametersInfo(
        uint uiAction,
        uint uiParam,
        IntPtr pvParam,
        uint fWinIni
    );
    #endregion

    #region Velocidad del mouse
    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
    public static extern bool GetMouseSpeed(uint uiAction, uint uiParam, out uint pvParam, uint fWinIni);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SystemParametersInfo")]
    public static extern bool SetMouseSpeed(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
    #endregion

    #region Fix axis
    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "ClipCursor")]
    internal static extern void ClipCursor(RectApi lpRect);

    [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "ClipCursor")]
    internal static extern int UnclipCursor(IntPtr nullLpRect);
    #endregion

    #region Sistema
    [DllImport("user32.dll")]
    internal static extern int GetSystemMetrics(int nIndex);
    #endregion

    #region Post async - app command
    [DllImport("user32.dll")]
    public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam);
    #endregion
}

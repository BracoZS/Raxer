using System;
using System.Runtime.InteropServices;
using static Raxer.Infra.Native.MouseHook;

namespace Raxer.Infra.Native;

internal static partial class WinApi
{
    #region Ventanas

    // GET
    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsIconic(IntPtr handle);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool IsZoomed(IntPtr handle);

    [LibraryImport("user32.dll")]
    public static partial IntPtr GetForegroundWindow();

    // SET
    [LibraryImport("user32.dll")]
    public static partial int SetForegroundWindow(IntPtr hwnd);

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool SwitchToThisWindow(IntPtr handle, [MarshalAs(UnmanagedType.Bool)] bool funknow);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool GetWindowRect(IntPtr hWnd, out RectApi lpRect);

    [LibraryImport("user32.dll", SetLastError = true)]
    internal static partial IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, int uFlags);
    
    #endregion

    #region Coords mouse

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool GetCursorPos(ref PointApi pt);

    #endregion

    #region Get Handles

    [LibraryImport("user32.dll")]
    internal static partial IntPtr WindowFromPoint(PointApi p);

    [LibraryImport("user32.dll")]
    internal static partial IntPtr GetAncestor(IntPtr hwnd, Ancestro gaFlags);

    #endregion

    #region ID

    [LibraryImport("user32.dll")]
    internal static partial int GetWindowThreadProcessId(IntPtr handle, out int processId);

    #endregion

    #region Estado de tecla

    [LibraryImport("user32.dll")]
    internal static partial short GetAsyncKeyState(int keyCode);

    #endregion

    #region Parámetros del sistema - SPI

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool SystemParametersInfo(
        uint uiAction,
        uint uiParam,
        IntPtr pvParam,
        uint fWinIni
    );

    #endregion

    #region Velocidad del mouse

    [LibraryImport("user32.dll", EntryPoint = "SystemParametersInfo")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool GetMouseSpeed(uint uiAction, uint uiParam, out uint pvParam, uint fWinIni);

    [LibraryImport("user32.dll", EntryPoint = "SystemParametersInfo")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool SetMouseSpeed(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

    #endregion

    #region Fix axis

    [LibraryImport("user32.dll")]
    internal static partial void ClipCursor(RectApi lpRect);

    [LibraryImport("user32.dll", EntryPoint = "ClipCursor")]
    internal static partial int UnclipCursor(IntPtr nullLpRect);

    #endregion

    #region Sistema

    [LibraryImport("user32.dll")]
    internal static partial int GetSystemMetrics(int nIndex);

    #endregion

    #region Post async - app command

    [LibraryImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static partial bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, int lParam);

    #endregion

    #region Hook

    [LibraryImport("user32.dll", SetLastError = true)]
    internal static partial nint SetWindowsHookEx(int idHook, LowHookProc lpfn, nint hMod, uint dwThreadId);

    [LibraryImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal static partial bool UnhookWindowsHookEx(IntPtr hhk);

    [LibraryImport("user32.dll", SetLastError = true)]
    internal static partial nint CallNextHookEx(nint hhk, int nCode, nint wParam, nint lParam);

    [LibraryImport("kernel32.dll", StringMarshalling = StringMarshalling.Utf16, SetLastError = true)]
    internal static partial IntPtr GetModuleHandle(string lpModuleName);

    #endregion
}

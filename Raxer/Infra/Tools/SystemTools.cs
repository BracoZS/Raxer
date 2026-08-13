using Raxer.Infra.Native;
using System.Diagnostics;

namespace Raxer.Infra.Tools;

/// <summary>
/// Primitive tools
/// </summary>
internal static class SystemTools
{
    internal static void RunAppCommand(AppCmd cmd)
        => WinApi.PostMessage(GetCursorMainHandle(), WindowConstants.WM_APPCOMMAND, IntPtr.Zero, (int)cmd << 16);

    public static bool IsPressed(KeyArti key) 
        => (WinApi.GetAsyncKeyState((int)key) & 0x8000) > 0;

    public static PointApi GetRataPos()
    {
        PointApi rp = new();
        WinApi.GetCursorPos(ref rp);
        return rp;
    }

    public static int GetCursorProcessID()
    {
        WinApi.GetWindowThreadProcessId(GetCursorHandle(), out int processID);
        return processID;
    }

    private static IntPtr GetCursorHandle()
    {
        return WinApi.WindowFromPoint(GetRataPos());
    }

    public static IntPtr GetCursorMainHandle()
    {
        return GetCursorMainHandle(GetRataPos());
    }

    public static IntPtr GetCursorMainHandle(PointApi rataPos)
    {
        return WinApi.GetAncestor(WinApi.WindowFromPoint(rataPos), Ancestro.GetRoot);
    }

    public static int GetMouseSpeedValue()
    {
        if (WinApi.GetMouseSpeed(MouseConstants.SPI_GET_MOUSESPEED, 0, out uint speed, 0))
            return (int)speed;

        return MouseConstants.defaultSystemSpeed;
    }

    public static void SetMouseSpeed(uint speed)
    {
        WinApi.SetMouseSpeed(MouseConstants.SPI_SET_MOUSESPEED, 0, speed, MouseConstants.SPIF_SENDCHANGE);
    }

    public static Modificador GetPressedModificador(bool ignoreIfKeyLaunched = false)
    {
        if (ignoreIfKeyLaunched) return Modificador.None;

        Modificador mods = Modificador.None;

        if (IsPressed(KeyArti.SHIFT)) mods |= Modificador.Shift;
        if (IsPressed(KeyArti.CONTROL)) mods |= Modificador.Control;
        if (IsPressed(KeyArti.MENU)) mods |= Modificador.Alt;
        if (IsPressed(KeyArti.WIN_L) || IsPressed(KeyArti.WIN_R)) mods |= Modificador.Win;

        return mods;
    }

    public static string GetAppExeName()
    {
        try
        {
            using var process = Process.GetProcessById(GetCursorProcessID());
            return process.ProcessName;
        }
        catch
        {
            return string.Empty;
        }
    }
}
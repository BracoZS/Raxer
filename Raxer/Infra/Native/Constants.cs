using Raxer.Infra.Native;

namespace Raxer.Infra.Native;

public static class SystemMetrics
{
    internal const int SM_XVIRTUALSCREEN = 76;
    internal const int SM_YVIRTUALSCREEN = 77;
    internal const int SM_CXVIRTUALSCREEN = 78;
    internal const int SM_CYVIRTUALSCREEN = 79;
}

public static class MouseConstants
{
    public const int defaultSystemSpeed = 10;

    internal const uint SPI_GET_MOUSESPEED = 0x0070;
    internal const uint SPI_SET_MOUSESPEED = 0x0071;
    internal const uint SPIF_UPDATEINIFILE = 0x01;
    internal const uint SPIF_SENDCHANGE = 0x02;
}

public static class WindowConstants
{
    internal const short SWP_NOSIZE = 1;
    internal const short SWP_NOZORDER = 0x0004;

    internal const int WM_CLOSE = 0x0010;
    internal const uint WM_APPCOMMAND = 0x0319;
}

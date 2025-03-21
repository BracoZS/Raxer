using static Raxer_2_alpha.Utilidades.WinApi;
using static Raxer_2_alpha.Utilidades.Auxiliares;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    private const int defaultSystemSpeed = 10;
    private static uint _mouseSpeed;

    public static int MouseSpeed
    {
        get
        {
            if(GetMouseSpeed(SPI_GET_MOUSESPEED, 0, out _mouseSpeed, 0))
                return (int)_mouseSpeed;

            return defaultSystemSpeed;
        }
        set
        {
            var rangoSpeed = value;
            if(rangoSpeed > 20)
                rangoSpeed = 20;

            if(rangoSpeed < 1)
                rangoSpeed = 1;

            SetMouseSpeed(SPI_SET_MOUSESPEED, 0, (uint)rangoSpeed, SPIF_SENDCHANGE);
        }
    }

    internal static void SetPunteroSpeed(int cantidad) => MouseSpeed = cantidad;
    internal static void ChanguePunteroSpeed(int cantidad) => MouseSpeed += cantidad;


    static RectAPI AxisX = new RectAPI() { left = 0, right = 7680 };
    static RectAPI AxisY = new RectAPI() { top = 0, bottom = 4800 };
    private static Punto cursorPos;

    internal static void FijarEjeX()
    {
        cursorPos = GetRataPos();
        AxisX.top = cursorPos.y;
        AxisX.bottom = cursorPos.y + 1;

        ClipCursor(AxisX);
    }

    internal static void FijarEjeY()
    {
        cursorPos = GetRataPos();
        AxisY.left = cursorPos.x;
        AxisY.right = cursorPos.x + 1;

        ClipCursor(AxisY);
    }

    internal static void SoltarEje() => UnclipCursor(nint.Zero);  // default
}

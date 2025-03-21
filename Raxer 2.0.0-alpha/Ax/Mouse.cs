using static Raxer_2_alpha.Utilidades.MensajeroApi;

namespace Raxer_2_alpha;

internal static partial class Ax
{
    private static Input[] mouseInput;

    public static void LanzarMouseEvent(MouseN mb, int? mousedata = null)
    {
        mouseInput[0].union.mouse.dwFlags = mb;
        if(mousedata != null)
            mouseInput[0].union.mouse.mouseData = (int)mousedata;

        SendInput(1, mouseInput, GenSize);
    }
}

using static Raxer_2_alpha.Utilidades.MensajeroApi;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    private static IntPtr appBajoCursor;

    static Ax()
    {
        mouseInput = new Input[1];
        mouseInput[0].type = InputEventType.Mouse;

        tecla_V =  new Input[1];
        tecla_V[0].type = InputEventType.Keyboard;

        tecla_A = new Input[1];
        tecla_A[0].type = InputEventType.Keyboard;
        tecla_A[0].union.keyboard.dwFlags = KbFlags.KEYUP;

        teclaEntera = new Input[2];
        teclaEntera[0].type = InputEventType.Keyboard;
        teclaEntera[1].type = InputEventType.Keyboard;
        teclaEntera[1].union.keyboard.dwFlags = KbFlags.KEYUP;

        teclasCombo = new Input[6];
        teclasCombo[0].type = InputEventType.Keyboard;
        teclasCombo[1].type = InputEventType.Keyboard;
        teclasCombo[2].type = InputEventType.Keyboard;
        teclasCombo[3].type = InputEventType.Keyboard;
        teclasCombo[4].type = InputEventType.Keyboard;
        teclasCombo[5].type = InputEventType.Keyboard;
    }
}

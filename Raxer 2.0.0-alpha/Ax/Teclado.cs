using System.Diagnostics;
using System.Threading;
using static Raxer_2_alpha.Utilidades.MensajeroApi;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    private static Input[] tecla_V;
    private static Input[] tecla_A;
    private static Input[] teclaEntera;
    private static Input[] teclasCombo;

    internal static bool IsKeyLaunchedDown = false;     // temp

    internal static void LanzarTeclaDown(KeyN tecla)
    {
        IsKeyLaunchedDown = true;

        tecla_V[0].union.keyboard.wVk = tecla;
        tecla_V[0].union.keyboard.wVk = tecla;

        SendInput(1, tecla_V, GenSize);

        var esperaInicial = Stopwatch.StartNew();
        while(IsKeyLaunchedDown)
        {
            if(esperaInicial.ElapsedMilliseconds > 500)
            {
                SendInput(1, tecla_V, GenSize);
                Thread.Sleep(25);
            }
        }
        esperaInicial.Stop();
    }

    internal static void LanzarTeclaUp()
    {
        IsKeyLaunchedDown = false;

        SendInput(1, tecla_A, GenSize);
    }

    internal static void LanzarTecla(KeyN tecla)
    {
        teclaEntera[0].union.keyboard.wVk = tecla;
        teclaEntera[1].union.keyboard.wVk = tecla;

        SendInput(2, teclaEntera, GenSize);
    }

    internal static void LanzarCombo(params KeyN[] teclas)
    {
        var numTeclas = (uint)teclas.Length;

        for(int i = 0; i < numTeclas; i++)
        {
            teclasCombo[i].union.keyboard.wVk = teclas[i];
        }

        for(int i = 0; i < numTeclas; i++)
        {
            teclasCombo[i + numTeclas].union.keyboard.wVk = teclas[i];
            teclasCombo[i + numTeclas].union.keyboard.dwFlags = KbFlags.KEYUP;
        }

        SendInput(numTeclas * 2, teclasCombo, GenSize);
    }
}

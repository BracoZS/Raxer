using System.Diagnostics;
using Raxer.Infra.Native;
using static Raxer.Infra.Native.Messenger;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    private static bool _isKeyLaunchedDown;

    public static void TeclaDown(KeyArti tecla)
    {
        _isKeyLaunchedDown = true;

        var inputDown = new INPUT
        {
            type = InputEventType.Keyboard,
            union = new MKH_INPUTUNION
            {
                Keyboard = new KeyboardInput { wVk = tecla }
            }
        };

        INPUT[] inputs = [inputDown];
        SendInput(1, inputs, _genSize);

        var esperaInicial = Stopwatch.StartNew();
        while (_isKeyLaunchedDown)
        {
            if (esperaInicial.ElapsedMilliseconds > 500)
            {
                /* importante este orden!!!!! 
                 * es para q pueda detectar el up correctamente y no se haga bucle infinito
                 * mientas espera le da tiempo al up de actuar */
                SendInput(1, inputs, _genSize);
                Thread.Sleep(25);
            }
            else
            {
                Thread.Sleep(10);
            }
        }
        esperaInicial.Stop();
    }

    public static void TeclaUp(KeyArti tecla)
    {
        _isKeyLaunchedDown = false;

        var inputUp = new INPUT
        {
            type = InputEventType.Keyboard,
            union = new MKH_INPUTUNION
            {
                Keyboard = new KeyboardInput
                {
                    wVk = tecla,
                    dwFlags = KbFlags.KEYUP
                }
            }
        };

        INPUT[] inputs = [inputUp];
        SendInput(1, inputs, _genSize);
    }

    public static void LanzarTecla(KeyArti tecla)
    {
        INPUT[] inputs = [
            new INPUT
            {
                type = InputEventType.Keyboard,
                union = new MKH_INPUTUNION
                {
                    Keyboard = new KeyboardInput { wVk = tecla }
                }
            },
            new INPUT
            {
                type = InputEventType.Keyboard,
                union = new MKH_INPUTUNION
                {
                    Keyboard = new KeyboardInput { wVk = tecla, dwFlags = KbFlags.KEYUP }
                }
            }
        ];

        SendInput(2, inputs, _genSize);
    }

    public static void LanzarCombo(params KeyArti[] teclas)
    {
        if (teclas == null || teclas.Length == 0) return;

        int cantTeclas = teclas.Length;
        INPUT[] inputs = new INPUT[cantTeclas * 2];

        // down
        for (int i = 0; i < cantTeclas; i++)
        {
            inputs[i] = new INPUT
            {
                type = InputEventType.Keyboard,
                union = new MKH_INPUTUNION
                {
                    Keyboard = new KeyboardInput { wVk = teclas[i] }
                }
            };
        }

        // up
        for (int i = 0; i < cantTeclas; i++)
        {
            inputs[i + cantTeclas] = new INPUT
            {
                type = InputEventType.Keyboard,
                union = new MKH_INPUTUNION
                {
                    Keyboard = new KeyboardInput
                    {
                        wVk = teclas[cantTeclas - 1 - i],   // reverse order for key release
                        dwFlags = KbFlags.KEYUP
                    }
                }
            };
        }

        SendInput((uint)inputs.Length, inputs, _genSize);
    }
}

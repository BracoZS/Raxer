using LocalSettingsJson;
using Raxer.Infra.Storage;

namespace Raxer.Modules.Loader;

/// <summary>
/// Startup de la app. Carga settings, levanta el hook y abre la ventana.
/// Punto unico de bootstrap para que App.xaml.cs quede pelado.
/// </summary>
public static class Loader
{
    /// <summary>Settings globales cargados al inicio. null si todavia no se llamó Startup.</summary>
    public static AppSettings? Settings { get; private set; }

    /// <summary>Arranque de la app. Llamar desde App.OnStartup.</summary>
    public static void Startup()
    {
        // leer settings config from file json
        Settings = SettingsStorage.Load<AppSettings>();


        // wiring settings events
        Settings.SavingErrorOcurred += (s, e) =>
        {
            Log($"Error al guardar settings: {e.Exception.Message}");
            e.Handled = true;
        };

        Log("Loader: settings cargados");

        // placeholder: el hook todavia no se activa (remapping inactivo hasta que haya mapa)
        // MouseHook.Start();
    }

    /// <summary>Cierre de la app. Llamar desde App.OnExit. Persiste settings.</summary>
    public static void Shutdown()
    {
        if (Settings is not null)
            SettingsStorage.Save(Settings);

        // placeholder: ver Startup()
        // MouseHook.Stop();

        Log("Loader: shutdown");
    }
}

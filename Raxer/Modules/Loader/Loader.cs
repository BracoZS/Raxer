using LocalSettingsJson;
using Raxer.Infra.Lang;
using Raxer.Infra.Storage;

namespace Raxer.Modules.Loader;

/// <summary>
/// Startup de la app. Carga settings, levanta el hook y abre la ventana.
/// Punto unico de bootstrap para que App.xaml.cs quede pelado.
/// </summary>
public static class Loader
{
    /// <summary>Arranque de la app. Llamar desde App.OnStartup.</summary>
    public static void Startup()
    {
        // leer settings config from file json
        App.Settings = SettingsStorage.Load<AppSettings>();


        // wiring settings events
        App.Settings.SavingErrorOcurred += (s, e) =>
        {
            Log($"Error al guardar settings: {e.Exception.Message}");
            e.Handled = true;
        };

        ResxDictionary.SetLanguage("en");


        Log("Loader: settings cargados");

        // placeholder: el hook todavia no se activa (remapping inactivo hasta que haya mapa)
        // MouseHook.Start();
    }

    /// <summary>Cierre de la app. Llamar desde App.OnExit. Persiste settings.</summary>
    public static void Shutdown()
    {
        if (App.Settings is not null)
            SettingsStorage.Save(App.Settings);

        // placeholder: ver Startup()
        // MouseHook.Stop();

        Log("Loader: shutdown");
    }
}

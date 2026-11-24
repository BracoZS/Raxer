using LangRX;
using LocalSettingsJson;
//using Raxer.Infra.Lang;
using Raxer.Modules.Profiles;
using Raxer.Modules.Settings;

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

        //ResxDictionary.SetLanguage("es");
        //LangRXDictionary.Initialize(Raxer.Properties.Resources.ResourceManager);

        Log("Loader: settings cargados");

        App.Config = ConfigStorage.Load(App.Settings.ConfigPath);

        if (string.IsNullOrWhiteSpace(App.Settings.ActiveProfileId) ||
            !App.Config.Profiles.Any(p => string.Equals(p.Id, App.Settings.ActiveProfileId, StringComparison.Ordinal)))
        {
            App.Settings.ActiveProfileId = App.Config.Profiles.FirstOrDefault()?.Id;
        }

        Log($"Loader: config cargada ({App.Config.Profiles.Count} perfiles, {App.Config.Filters.Count} filtros)");

        // placeholder: el hook todavia no se activa (remapping inactivo hasta que haya mapa)
        // MouseHook.Start();
    }

    /// <summary>Cierre de la app. Llamar desde App.OnExit. Persiste settings y config.</summary>
    public static void Shutdown()
    {
        if (App.Settings is not null)
            SettingsStorage.Save(App.Settings);

        if (App.Config is not null)
            ConfigStorage.Save(App.Config, App.Settings?.ConfigPath);

        // placeholder: ver Startup()
        // MouseHook.Stop();

        Log("Loader: shutdown");
    }
}

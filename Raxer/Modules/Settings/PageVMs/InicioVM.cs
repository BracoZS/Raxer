using Raxer.Modules.Profiles;

namespace Raxer.Modules.Settings.PageVMs;

/// <summary>
/// ViewModel de la página de inicio. Expone resumen del perfil activo y configuración general.
/// </summary>
public partial class InicioVM : ObservableObject
{
    [ObservableProperty]
    string perfilActual = "—";

    [ObservableProperty]
    string filtroActual = "—";

    [ObservableProperty]
    string archivoConfig = ConfigStorage.DefaultPath;

    [ObservableProperty]
    string atajoPerfil = "—";

    [ObservableProperty]
    bool notificaciones = true;

    [ObservableProperty]
    double velocidadPuntero = 50;

    [ObservableProperty]
    bool mejoraPrecision = false;

    public InicioVM()
    {
        archivoConfig = ConfigStorage.ResolvePath(App.Settings?.ConfigPath);

        if (App.Config is null)
            return;

        var active = App.Config.FindProfile(App.Settings?.ActiveProfileId);
        var filter = App.Config.FindFilter(active?.FilterId);

        perfilActual = active?.Name ?? "—";
        filtroActual = filter?.Name ?? "—";
        atajoPerfil = string.IsNullOrWhiteSpace(active?.Shortcut) ? "—" : active.Shortcut;
    }
}

using LocalSettingsJson;

namespace Raxer.Modules.Settings;

/// <summary>
/// Settings globales de la app. Se persisten en ~/AppData/Local/Raxer/settings.json
/// via LocalSettingsJson. Crece a partir de aqui.
/// Modelo -> Json file
/// </summary>
public sealed class AppSettings : SettingsBase
{
    private bool _arrancarConWindows = true;
    private string? _activeProfileId;
    private string? _configPath;

    public bool ArrancarConWindows
    {
        get => _arrancarConWindows;
        set => SetProperty(ref _arrancarConWindows, value);
    }

    public string? ActiveProfileId
    {
        get => _activeProfileId;
        set => SetProperty(ref _activeProfileId, value);
    }

    public string? ConfigPath
    {
        get => _configPath;
        set => SetProperty(ref _configPath, value);
    }
}

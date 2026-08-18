using LocalSettingsJson;

namespace Raxer.Modules.Settings;

/// <summary>
/// Settings globales de la app. Se persisten en ~/AppData/Local/Raxer/settings.json
/// via LocalSettingsJson. Crece a partir de aqui.
/// </summary>
public class AppSettings : SettingsBase
{
    private bool _arrancarConWindows = true;

    public bool ArrancarConWindows
    {
        get => _arrancarConWindows;
        set => SetProperty(ref _arrancarConWindows, value);
    }
}

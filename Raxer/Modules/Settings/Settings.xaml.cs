using System.Windows;
using Raxer.Infra.Lang;

namespace Raxer.Modules.Settings;
/// <summary>
/// Lógica de interacción para Settings.xaml
/// </summary>
public partial class Settings : Window
{
    public Settings()
    {
        InitializeComponent();

        IniciarConWindowsCheck.IsChecked = App.Settings!.ArrancarConWindows;
        IniciarConWindowsCheck.Checked += (_, _) => App.Settings!.ArrancarConWindows = true;
        IniciarConWindowsCheck.Unchecked += (_, _) => App.Settings!.ArrancarConWindows = false;

        _ = TestLangChange();
    }

    private async Task TestLangChange()
    {
        await Task.Delay(5_000);
        ResxDictionary.SetLanguage("es");
    }
}

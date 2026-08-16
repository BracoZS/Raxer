using System.Windows;

namespace Raxer.Modules.Settings;
/// <summary>
/// Lógica de interacción para Settings.xaml
/// </summary>
public partial class Settings : Window
{
    public Settings()
    {
        InitializeComponent();

        ArrancarConWindowsCheck.IsChecked = App.Settings?.ArrancarConWindows;
        ArrancarConWindowsCheck.Checked += (_, _) => App.Settings!.ArrancarConWindows = true;
        ArrancarConWindowsCheck.Unchecked += (_, _) => App.Settings!.ArrancarConWindows = false;
    }
}

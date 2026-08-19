using System.Windows;
using System.Windows.Input;

namespace Raxer.Modules.Settings;

public partial class Settings : Window
{
    public Settings()
    {
        InitializeComponent();
    }

    void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    void Minimize_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    void Close_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}

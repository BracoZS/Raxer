using System.Windows.Controls;

namespace Raxer.Modules.Settings.Pages;

public partial class InicioPage : UserControl
{
    public InicioPage()
    {
        InitializeComponent();
    }

    void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        e.Handled = true;
    }
}

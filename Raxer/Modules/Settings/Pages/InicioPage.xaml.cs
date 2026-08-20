using System.Windows.Controls;
using Raxer.Modules.Settings.PageVMs;

namespace Raxer.Modules.Settings.Pages;

public partial class InicioPage : UserControl
{
    public InicioPage()
    {
        InitializeComponent();
        DataContext = new InicioVM();
    }

    void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
    {
        e.Handled = true;
    }
}

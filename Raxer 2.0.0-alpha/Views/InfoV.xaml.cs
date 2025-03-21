using System.Security.Policy;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Raxer_2_alpha.Views;
/// <summary>
/// Lógica de interacción para InfoV.xaml
/// </summary>
public partial class InfoV : UserControl
{
    public InfoV() => InitializeComponent();

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
        e.Handled = true;
    }
}

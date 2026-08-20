using System.Windows.Controls;
using Raxer.Modules.Settings.PageVMs;

namespace Raxer.Modules.Settings.Pages;

public partial class FiltrosPage : UserControl
{
    public FiltrosPage()
    {
        InitializeComponent();
        DataContext = new FiltrosVM();
    }
}

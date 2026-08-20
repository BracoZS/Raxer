using System.Windows.Controls;
using Raxer.Modules.Settings.PageVMs;

namespace Raxer.Modules.Settings.Pages;

public partial class InfoPage : UserControl
{
    public InfoPage()
    {
        InitializeComponent();
        DataContext = new InfoVM();
    }
}

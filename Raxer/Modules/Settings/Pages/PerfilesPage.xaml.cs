using System.Windows.Controls;
using Raxer.Modules.Settings.PageVMs;

namespace Raxer.Modules.Settings.Pages;

public partial class PerfilesPage : UserControl
{
    public PerfilesPage()
    {
        InitializeComponent();
        DataContext = new PerfilesVM();
    }
}

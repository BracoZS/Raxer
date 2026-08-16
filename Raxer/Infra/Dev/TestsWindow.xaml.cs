using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Raxer.Modules.Loader;

namespace Raxer
{
    /// <summary>
    /// Lógica de interacción para TestsWindow.xaml
    /// </summary>
    public partial class TestsWindow : Window
    {
        public TestsWindow()
        {
            InitializeComponent();

            ArrancarConWindowsCheck.IsChecked = App.Settings?.ArrancarConWindows;
            ArrancarConWindowsCheck.Checked += (_, _) => App.Settings!.ArrancarConWindows = true;
            ArrancarConWindowsCheck.Unchecked += (_, _) => App.Settings!.ArrancarConWindows = false;
        }
    }
}

using System.Windows;
using System.Windows.Input;

namespace Raxer.Modules.UI.Controls;

public partial class Dialog : Window
{
    bool _result;

    Dialog()
    {
        InitializeComponent();
    }

    public static bool Show(string message, string title = "Raxer")
    {
        var dialog = new Dialog();
        dialog.TitleText.Text = title;
        dialog.MessageText.Text = message;
        dialog.ShowDialog();

        return dialog._result;
    }

    void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DragMove();
    }

    void OkButton_Click(object sender, RoutedEventArgs e)
    {
        _result = true;
        Close();
    }

    void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        _result = false;
        Close();
    }
}

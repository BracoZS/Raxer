using Raxer_2_alpha.Modelos;
using Raxer_2_alpha.Utilidades;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace Raxer_2_alpha;
/// <summary>
/// Lógica de interacción para SelectDialog.xaml
/// </summary>
public partial class SelectDialog : Window
{
    SelectDialogType tipo;
    public string Titulo { get; set; }
    public string Parrafo { get; set; }
    public ObservableCollection<UIEnum> KeyList { get; set; }
    public KeyN SelectedKey { get; set; } = KeyN.NONE;

    public Argo Argus { get; set; }  = new();


    public SelectDialog(SelectDialogType tipo)
    {
        InitializeComponent();

        DataContext = this;

        this.tipo = tipo;

        switch(tipo)
        {
            case SelectDialogType.getCombo:
                Titulo = "Seleccione una combinación de teclas";
                KeyList = Remaper.GetMap().EnumToObservableCollection<KeyN>();
                ComboSelection.Visibility = Visibility.Visible;
                break;

            case SelectDialogType.getPunteroValueToSet:
                Titulo = "Establecer velocidad del puntero del mouse";
                Parrafo = "Seleccione velocidad del puntero a \bestablecer\b";
                PunteroSelection.Visibility = Visibility.Visible;
                break;

            case SelectDialogType.getPunteroValueToChangue:
                Titulo = "Cambiar velocidad del puntero del mouse";
                Parrafo = "Seleccione un valor para aumentar/disminuir la velocidad del puntero cada vez";
                PunteroSelection.Visibility= Visibility.Visible;
                break;

            case SelectDialogType.getDirWeb:
                Titulo = "Abrir sitio web";
                Parrafo = "Ingrese la dirección web a abrir:";
                AbrirSelection.Visibility = Visibility.Visible;
                break;
        }
    }

    private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => DragMove();

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void ok_Clic(object sender, RoutedEventArgs e)
    {
        switch(tipo)
        {
            case SelectDialogType.getCombo:
                applyComboSelection();
                break;
            case SelectDialogType.getDirWeb:
                if(!String.IsNullOrEmpty(Url.Text))
                    Argus.Text = Url.Text;
                break;
        }

        this.DialogResult = true;

        Close();
    }

    private void Increment_Click(object sender, RoutedEventArgs e)
    {
        int.TryParse(PunteroValueTxt.Text, out int cantidadIngresada); 

        cantidadIngresada++;

        if(CheckRange(cantidadIngresada))
        {
            PunteroValueTxt.Text = $"{cantidadIngresada}";
            Argus.Num = cantidadIngresada;
        }
    }
    private void Decrement_Click(object sender, RoutedEventArgs e)
    {
        int.TryParse(PunteroValueTxt.Text, out int cantidadIngresada);

        cantidadIngresada--;

        if(CheckRange(cantidadIngresada))
        {
            PunteroValueTxt.Text = $"{cantidadIngresada}";
            Argus.Num = cantidadIngresada;
        }
    }
    private bool CheckRange(int n)
    {
        if(n < 1) return false;
        if(n > 20) return false;
        return true;
    }
    private void PunteroSpeedValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);

        Argus.Num = int.Parse(e.Text);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == System.Windows.Input.Key.Escape)
            this.Close();
    }

    private void applyComboSelection()
    {
        var comboList = new List<KeyN>();
        if(control.IsChecked == true)
            comboList.Add(KeyN.CONTROL);
        if(shift.IsChecked == true)
            comboList.Add(KeyN.SHIFT);
        if(alt.IsChecked == true)
            comboList.Add(KeyN.MENU);
        if(windows.IsChecked == true)
            comboList.Add(KeyN.WIN_L);

        if(ComboKeyList.SelectedIndex >= 0)
        {
            comboList.Add(SelectedKey);
        }

        Argus.ComboList = new KeyN[comboList.Count];
        Argus.ComboList = comboList.ToArray();

    }


    public enum SelectDialogType
    {
        getCombo, getPunteroValueToSet, getPunteroValueToChangue, getDirWeb
    }

    public class Argo
    {
        public string Text { get; set; }
        public int Num { get; set; }
        public KeyN Tecla { get; set; }
        public KeyN[] ComboList { get; set; }
    }

}

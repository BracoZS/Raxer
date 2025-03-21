namespace Raxer_2_alpha;
/// <summary>
/// Lógica de interacción para Configuracion.xaml
/// </summary>
public partial class Configuracion : Window
{
    public Configuracion() => InitializeComponent();
    private void Barra_Arrastre(object sender, MouseButtonEventArgs e) => DragMove();
    private void Minimizar(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;
    private void Cerrar(object sender, RoutedEventArgs e) => this.Close();


    private void Button_Click(object sender, RoutedEventArgs e) => this.Close();
}


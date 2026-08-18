using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    public static void IrAWeb(string dirWeb)
    {
        if (string.IsNullOrWhiteSpace(dirWeb)) return;
        if (!Regex.IsMatch(dirWeb, "^(http://|https://)", RegexOptions.IgnoreCase))
        {
            dirWeb = $"https://{dirWeb}";
        }
        try
        {
            Process.Start(new ProcessStartInfo(dirWeb) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error al abrir web: {ex.Message}");
        }
    }

    public static void AbrirRuta(string ruta)
    {
        if (string.IsNullOrWhiteSpace(ruta)) return;
        try
        {
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudo abrir la ruta: {ruta}\n\nDetalle: {ex.Message}",
                "Error de Apertura",
                MessageBoxButton.OK,
                MessageBoxImage.Error
            );
        }
    }
}

namespace Raxer_2_alpha;

internal static partial class Ax
{
    internal static void AbrirWeb(string dirWeb)
    {
        if(!dirWeb.StartsWith("http"))
            dirWeb = "http://" + dirWeb;

        Process.Start(new ProcessStartInfo(dirWeb)
        {
            UseShellExecute = true
        });
    }

    internal static void AbrirRutaLocal(string dirLocal)
    {
        try
        {
            Process.Start(new ProcessStartInfo(dirLocal)
            {
                UseShellExecute = true
            });
        }
        catch(Exception ex)
        {
            MessageBox.Show(
                $"No se pudo abrir la ruta \"{dirLocal}\" \n{ex}",
                "Error message",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}

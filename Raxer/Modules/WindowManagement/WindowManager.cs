using System.Windows;

namespace Raxer.Modules.WindowManager;

/// <summary>
/// Gestión genérica de ventanas: abrir, mostrar y cerrar cualquier Window.
/// No conoce la app ni tipos concretos; el llamador elige qué ventana usar.
/// </summary>
public sealed class WindowManager
{
    private readonly List<Window> _ventanas = [];

    /// <summary>Registra y muestra una ventana. Devuelve la ventana abierta.</summary>
    public Window Open(Window ventana)
    {
        _ventanas.Add(ventana);
        ventana.Closed += (_, _) => _ventanas.Remove(ventana);
        ventana.Show();
        return ventana;
    }

    public TWindow OpenOrCreate<TWindow>() where TWindow : Window, new()
    {
        var ventana = _ventanas.OfType<TWindow>().FirstOrDefault();

        if (ventana is not null)
        {
            Show(ventana);
            return ventana;
        }

        return (TWindow)Open(new TWindow());
    }

    /// <summary>Muestra una ventana existente, restaurándola si está minimizada.</summary>
    public void Show(Window ventana)
    {
        ventana.Show();

        if (ventana.WindowState == WindowState.Minimized)
            ventana.WindowState = WindowState.Normal;

        ventana.Activate();
    }

    /// <summary>Cierra todas las ventanas abiertas (shutdown).</summary>
    public void CloseAll()
    {
        foreach (var ventana in _ventanas.ToArray())
            ventana.Close();
        _ventanas.Clear();
    }
}

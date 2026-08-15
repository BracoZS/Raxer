using System.Drawing;
using System.Windows.Forms;
using App = System.Windows.Application;

namespace Raxer.Modules.Tray;

/// <summary>
/// Icono de bandeja del sistema (NotifyIcon de WinForms). Solo maneja el
/// estado de la app en el ícono: menú Abrir/Salir y doble click.
/// No sabe de ventanas; quién abra la ventana es decisión de App.
/// </summary>
public sealed class TrayIcon : IDisposable
{
    private readonly NotifyIcon _icon;

    /// <summary>Se dispara al hacer click en "Abrir" o doble click en el ícono.</summary>
    public event Action? Abrir;

    /// <summary>Se dispara al hacer click en "Salir".</summary>
    public event Action? Salir;

    public TrayIcon()
    {
        var menu = new ContextMenuStrip();
        menu.Items.Add("Abrir", null, (_, _) => Abrir?.Invoke());
        menu.Items.Add(new ToolStripSeparator());
        menu.Items.Add("Salir", null, (_, _) => Salir?.Invoke());

        _icon = new NotifyIcon
        {
            Icon = CargarIcono(),
            ContextMenuStrip = menu,
            Text = "Raxer",
            Visible = true
        };
        _icon.DoubleClick += (_, _) => Abrir?.Invoke();

        Log("Tray: iniciado");
    }

    public void Dispose()
    {
        _icon.Visible = false;
        _icon.Dispose();
        Log("Tray: detenido");
    }

    private static Icon CargarIcono()
    {
        var uri = new Uri("pack://application:,,,/Assets/Iconos/appIcon.ico");
        using var stream = App.GetResourceStream(uri)?.Stream
            ?? throw new InvalidOperationException("No se encontró appIcon.ico");
        return new Icon(stream);
    }
}

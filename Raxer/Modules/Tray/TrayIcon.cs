using System.Drawing;
using System.Windows.Forms;
using Raxer.Properties;

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
        _icon = new NotifyIcon
        {
            Icon = CargarIcono(),
            ContextMenuStrip = CrearMenu(),
            Text = Resources.app_name,
            Visible = true
        };
        _icon.DoubleClick += (_, _) => Abrir?.Invoke();

        Log("Tray: iniciado");
    }

    private ContextMenuStrip CrearMenu()
    {
        var menu = new ContextMenuStrip();

        // ▸ Abrir — abre la ventana de settings
        var abrir = new ToolStripMenuItem
        {
            Text = Resources.menu_open_settings
        };
        abrir.Click += (_, _) => Abrir?.Invoke();

        // ▸ Iniciar con el sistema — checkbox atado a App.Settings.ArrancarConWindows
        var iniciarConSistema = new ToolStripMenuItem
        {
            Text = Resources.menu_start_with_system,
            CheckOnClick = true,
            Checked = App.Settings?.ArrancarConWindows ?? false
        };
        iniciarConSistema.CheckedChanged += (_, _) => App.Settings!.ArrancarConWindows = iniciarConSistema.Checked;

        // ─── separador ────────────────────────────────────────────
        var separador = new ToolStripSeparator();

        // ▸ Salir — cierra la app
        var salir = new ToolStripMenuItem
        {
            Text = Resources.menu_exit
        };
        salir.Click += (_, _) => Salir?.Invoke();

        menu.Items.AddRange([abrir, iniciarConSistema, separador, salir]);
        return menu;
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

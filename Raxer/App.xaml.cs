using Raxer.Modules.Loader;
using Raxer.Modules.Tray;
using Raxer.Modules.WindowManager;
using System.Windows;

namespace Raxer;

public partial class App : Application
{
    private TrayIcon? _tray;
    private WindowManager? _ventanas;
    private Window? _ventana;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Loader.Startup();

        _tray = new TrayIcon();

        _ventanas = new WindowManager();
        _tray.Abrir += AbrirVentana;
        _tray.Salir += Shutdown;
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _tray?.Dispose();
        Loader.Shutdown();
        base.OnExit(e);
    }

    /// <summary>Abre la ventana de la app, o la muestra si sigue abierta.</summary>
    private void AbrirVentana()
    {
        if (_ventana is null || !_ventana.IsLoaded)
            _ventana = _ventanas.Open(new TestsWindow());
        else
            _ventanas.Show(_ventana);
    }
}

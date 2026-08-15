using Raxer.Modules.Loader;
using Raxer.Modules.Tray;
using System.Windows;

namespace Raxer;

public partial class App : Application
{
    private TrayIcon? _tray;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Loader.Startup();

        _tray = new TrayIcon();
        _tray.Salir += Shutdown;
        // Abrir se wirea cuando exista la MainWindow real
    }

    protected override void OnExit(ExitEventArgs e)
    {
        _tray?.Dispose();
        Loader.Shutdown();

        base.OnExit(e);
    }
}

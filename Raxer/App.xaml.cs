using Raxer.Infra.Storage;
using Raxer.Modules.Loader;
using Raxer.Modules.Tray;
using Raxer.Modules.WindowManager;
using System.Windows;

namespace Raxer;

public partial class App : Application
{
    /// <summary>Settings globales de la app. App es el dueño; Loader las carga y persiste.</summary>
    public static AppSettings? Settings { get; set; }

    private TrayIcon? _tray;
    private WindowManager? _windowManager;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Loader.Startup();

        _tray = new TrayIcon();
        _windowManager = new WindowManager();

        _tray.Abrir += () => _windowManager!.OpenOrCreate<TestsWindow>();
        _tray.Salir += Close;
    }

    /// <summary>
    /// Cierra la app desde cualquier lado (estático).
    /// Dispara el evento Exit
    /// </summary>
    public static void Close() => Current.Shutdown();

    protected override void OnExit(ExitEventArgs e)
    {
        _windowManager?.CloseAll();

        _tray?.Dispose();
        Loader.Shutdown();
        base.OnExit(e);
    }
}

using System.Windows;
using Raxer.Modules.Loader;

namespace Raxer;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        // app loader
        Loader.Startup();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        Loader.Shutdown();
        base.OnExit(e);
    }
}


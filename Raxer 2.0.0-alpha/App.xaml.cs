using Raxer_2_alpha.Utilidades;
using Raxer_2_alpha.Modelos;
using Application = System.Windows.Application;
using TrayIcon = System.Windows.Forms.NotifyIcon;
using Fo = System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Raxer_2_alpha;

public partial class App : Application
{
    private TrayIcon iconoDeNotificacion;
    private CustomMenu menu;
    private ConfigManager config =  new ConfigManager();

    internal void Iniciar(object sender, StartupEventArgs e) => OnStartup(e);

    protected override void OnStartup(StartupEventArgs e)
    {
        using(var @this = Process.GetCurrentProcess()) 
        {
            if(Process.GetProcessesByName(@this.ProcessName).Length <= 1)
            {
                cargar();
            }
            else
            {
                MessageBox.Show(
                    "Ya se encuentra activa una instancia de la aplicación",
                    "Advertencia",
                    MessageBoxButton.OK, 
                    MessageBoxImage.Warning,
                    MessageBoxResult.None);

                Environment.Exit(0);    
            }
        }
    }

    private async void cargar()
    {
        cargarIconoNotificacion();      // 100ms aprox

        config.ShowConfig();

        SafeNativeMethods.Start();
    }

    internal void checkear()
    { 

    }

    private void cargarIconoNotificacion()
    {
        #region Tray Icono
        iconoDeNotificacion = new()
        {
            Icon = new System.Drawing.Icon("imgs/appIcon.ico"),
            Text = "Raxer_2_alpha",
            Visible = true
        };
        iconoDeNotificacion.MouseClick += (s, e) =>
        {
            if(e.Button == Fo.MouseButtons.Left)
            {
                Ax.LanzarMouseEvent(MouseN.rightDown);
                Ax.LanzarMouseEvent(MouseN.rightUp);
            }
        };
        #endregion

        #region Menu
        menu = new("#05EB37", "#15D13E");
        menu.RenderMode = Fo.ToolStripRenderMode.System;
        menu.Items.Add("Abrir Configuración", null, abrirConfiguracion);
        menu.Items.Add("Suspender", null, @switch);
        menu.Items.Add("Salir", null, CerrarApp);
        #endregion

        iconoDeNotificacion.ContextMenuStrip = menu;
    }

    internal void abrirConfiguracion(object sender, EventArgs e) => config.ShowConfig();

    internal void @switch(object sender, EventArgs e)
    {
        if (SafeNativeMethods.IsRemapActive)
        {
            SafeNativeMethods.Stop();

            menu.Items[1].Text = "Activar";
            menu.ChangueColorStatus("#EB1D36", "#D2001A");
        }
        else
        {
            SafeNativeMethods.Start();

            menu.Items[1].Text = "Suspender";
            menu.ChangueColorStatus("#05EB37", "#15D13E");
        }
    }

    internal void CerrarApp(object sender, EventArgs e) => Shutdown();

    protected override void OnExit(ExitEventArgs e)
    {
        iconoDeNotificacion.Dispose();

        SafeNativeMethods.Stop();

        base.OnExit(e);
    }
}

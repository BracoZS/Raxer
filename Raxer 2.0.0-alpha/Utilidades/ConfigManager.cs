namespace Raxer_2_alpha.Utilidades;

internal class ConfigManager
{
    private Configuracion instance;

    public void ShowConfig()
    {
        if(instance == null)
        {
            instance = new Configuracion();
            instance.Closed += Instance_Closed;
        }

        if(!instance.IsVisible)
        {
            instance.Show();
        }
        else
        {
            instance.Activate();
        }
    }
    private void Instance_Closed(object? sender, EventArgs e)
    {
        instance = null;
    }
}




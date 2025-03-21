using Raxer_2_alpha.Properties;

namespace Raxer_2_alpha.Utilidades;

internal static class UIMostrador
{
    internal static string GetLocalIdioma(object o)
    {
        return Resources.ResourceManager.GetString(o.ToString()) ?? o.ToString();
    }
}

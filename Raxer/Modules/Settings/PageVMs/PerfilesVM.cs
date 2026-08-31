using System.Collections.ObjectModel;

namespace Raxer.Modules.Settings.PageVMs;

public partial class PerfilesVM : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<DemoProfile> _perfiles = new()
    {
        new() { Nombre = "General", Filtro = "Ninguno", Activo = true },
        new() { Nombre = "Gaming", Filtro = "Blacklist", Activo = false },
        new() { Nombre = "Edición", Filtro = "Whitelist", Activo = false }
    };

    [ObservableProperty]
    ObservableCollection<string> _lista = new()
    {
        "Administrador",
        "Default",
        "Ninguno",
        "Key",
        "Usuario",
        "Invitado"
    };

    [ObservableProperty]
    DemoProfile? _perfilSeleccionado;
}

public class DemoProfile
{
    public string Nombre { get; set; } = "";
    public string Filtro { get; set; } = "";
    public bool Activo { get; set; }
}

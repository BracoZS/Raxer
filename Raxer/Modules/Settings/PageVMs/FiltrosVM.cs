using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Raxer.Modules.Settings.PageVMs;

public partial class FiltrosVM : ObservableObject
{
    [ObservableProperty]
    ObservableCollection<DemoFilter> _filtros = new()
    {
        new DemoFilter
        {
            Titulo = "Navegadores",
            Tipo = "Whitelist",
            Apps = new() { "Chrome", "Firefox", "Edge" },
            Links = new() { "Perfil general", "Perfil web" }
        },
        new DemoFilter
        {
            Titulo = "Juegos",
            Tipo = "Blacklist",
            Apps = new() { "Steam", "Epic", "GOG" },
            Links = new() { "Perfil gaming" }
        },
        new DemoFilter
        {
            Titulo = "编辑",
            Tipo = "Whitelist",
            Apps = new() { "Photoshop", "Blender" },
            Links = new() { "Perfil edición" }
        }
    };
}

public class DemoFilter
{
    public string Titulo { get; set; } = "";
    public string Tipo { get; set; } = "";
    public ObservableCollection<string> Apps { get; set; } = new();
    public ObservableCollection<string> Links { get; set; } = new();
}

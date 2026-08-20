using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace Raxer.Modules.Settings.PageVMs;

public partial class InfoVM : ObservableObject
{
    [ObservableProperty]
    string version = "2.0";

    [ObservableProperty]
    string copyright = "@BracoZS";

    [ObservableProperty]
    string repositorio = "https://github.com/BracoZS/Raxer";

    [ObservableProperty]
    ObservableCollection<string> componentes = new()
    {
        "Some Library Name v12.",
        "Another Library v3.",
        "Yet Another Component v1."
    };
}

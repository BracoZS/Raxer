using System.Collections.ObjectModel;
using Raxer.Modules.Profiles;

namespace Raxer.Modules.Settings.PageVMs;

/// <summary>
/// ViewModel de la página de perfiles. Carga perfiles y acciones disponibles desde <see cref="App.Config"/>.
/// </summary>
public partial class PerfilesVM : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Profile> _perfiles = [];

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(FiltroDelPerfilTexto))]
    private Profile? _perfilSeleccionado;

    [ObservableProperty]
    private ObservableCollection<string> _lista = new(Enum.GetNames<ActionKind>());

    public string FiltroDelPerfilTexto
    {
        get
        {
            var filter = App.Config?.FindFilter(PerfilSeleccionado?.FilterId);
            return filter is null ? "Filter: —" : $"Filter: {filter.Name} ({filter.Mode})";
        }
    }

    public PerfilesVM()
    {
        if (App.Config is null)
            return;

        _perfiles = new(App.Config.Profiles);
        _perfilSeleccionado = App.Config.FindProfile(App.Settings?.ActiveProfileId);
    }

    partial void OnPerfilSeleccionadoChanged(Profile? value)
    {
        if (App.Settings is not null && value is not null)
            App.Settings.ActiveProfileId = value.Id;
    }
}

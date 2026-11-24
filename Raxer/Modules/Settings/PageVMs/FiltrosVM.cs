using System.Collections.ObjectModel;
using Raxer.Modules.Profiles;

namespace Raxer.Modules.Settings.PageVMs;

/// <summary>
/// ViewModel de la página de filtros. Proyecta los filtros definidos en <see cref="App.Config"/>.
/// </summary>
public partial class FiltrosVM : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<FilterItem> _filtros = [];

    public FiltrosVM()
    {
        if (App.Config is null)
            return;

        foreach (var filter in App.Config.Filters)
        {
            var linkedProfiles = App.Config.Profiles
                .Where(p => string.Equals(p.FilterId, filter.Id, StringComparison.Ordinal))
                .Select(p => p.Name);

            _filtros.Add(new FilterItem
            {
                Id = filter.Id,
                Titulo = filter.Name,
                Tipo = filter.Mode.ToString(),
                Apps = new(filter.Apps),
                Links = new(linkedProfiles)
            });
        }
    }
}

/// <summary>
/// Proyección de lectura de un <see cref="FilterDefinition"/> para la vista de filtros.
/// </summary>
public sealed class FilterItem
{
    public string Id { get; init; } = string.Empty;
    public string Titulo { get; init; } = string.Empty;
    public string Tipo { get; init; } = string.Empty;
    public ObservableCollection<string> Apps { get; init; } = [];
    public ObservableCollection<string> Links { get; init; } = [];
}

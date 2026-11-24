namespace Raxer.Modules.Profiles;

/// <summary>
/// Raíz del archivo de configuración portable (.rxconfig) con perfiles y filtros.
/// </summary>
public sealed class RaxerConfig
{
    public int Version { get; set; } = 1;
    public List<Profile> Profiles { get; set; } = [];
    public List<FilterDefinition> Filters { get; set; } = [];

    /// <summary>Busca un perfil por ID o devuelve el primero disponible si no hay coincidencia.</summary>
    public Profile? FindProfile(string? id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            var match = Profiles.FirstOrDefault(p => string.Equals(p.Id, id, StringComparison.Ordinal));
            if (match is not null)
                return match;
        }

        return Profiles.FirstOrDefault();
    }

    /// <summary>Busca un filtro por ID; devuelve null si el ID está vacío o no existe.</summary>
    public FilterDefinition? FindFilter(string? id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return null;

        return Filters.FirstOrDefault(f => string.Equals(f.Id, id, StringComparison.Ordinal));
    }

    /// <summary>Crea una configuración inicial con un perfil "Default" vacío.</summary>
    public static RaxerConfig CreateDefault() => new()
    {
        Profiles = [new Profile { Name = "Default" }],
        Filters = []
    };
}

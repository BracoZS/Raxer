using Raxer.Modules.Remapping;

namespace Raxer.Modules.Profiles;

/// <summary>
/// Definición persistible de un filtro por aplicación, compartible entre perfiles.
/// </summary>
public sealed class FilterDefinition
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = string.Empty;
    public FilterMode Mode { get; set; } = FilterMode.None;
    public List<string> Apps { get; set; } = [];

    /// <summary>Construye la instancia inmutable usada en runtime por el módulo de remapping.</summary>
    public AppFilter ToAppFilter() => new(Apps, Mode);
}

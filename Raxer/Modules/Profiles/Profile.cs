namespace Raxer.Modules.Profiles;

/// <summary>
/// Perfil de remapeo de usuario con filtro opcional por ID y atajo de cambio.
/// </summary>
public sealed class Profile
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = string.Empty;
    public string? FilterId { get; set; }
    public string? Shortcut { get; set; }
    public List<RemapEntry> Remaps { get; set; } = [];
}

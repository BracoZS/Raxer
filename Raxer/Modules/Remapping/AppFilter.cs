namespace Raxer.Modules.Remapping;

/// <summary>
/// Filtro inmutable de alto rendimiento para el control de aplicaciones mediante (white/black)list.
/// </summary>
public class AppFilter
{
    // hashset para evitar duplicados
    // y string fue definido definitivamente como id de app
    private readonly HashSet<string> _list;
    private readonly FilterMode _mode;

    /// <summary>
    /// Inicializa una nueva instancia de la clase <see cref="AppFilter"/>.
    /// </summary>
    /// <param name="apps">Colección de nombres de aplicaciones a incluir en el filtro.</param>
    /// <param name="mode">Modo de filtrado a aplicar (<see cref="FilterMode"/>).</param>
    public AppFilter(IEnumerable<string>? apps, FilterMode mode)
    {
        apps ??= Enumerable.Empty<string>();

        _list = new HashSet<string>(apps, StringComparer.OrdinalIgnoreCase);
        _mode = mode;
    }

    /// <summary>
    /// Evalúa si una aplicación debe ser bloqueada según las reglas configuradas.
    /// Consumir en un Guard Clause
    /// </summary>
    /// <param name="appName">Nombre del ejecutable o identificador de la aplicación.</param>
    public bool IsBlocked(string appName)
    {
        if (string.IsNullOrWhiteSpace(appName) || _mode == FilterMode.None)
            return false; // Si no hay filtro o está deshabilitado -> nada se bloquea

        return _mode switch
        {
            FilterMode.Whitelist => !_list.Contains(appName), // Bloquea si NO está en la lista
            FilterMode.Blacklist => _list.Contains(appName),  // Bloquea si SÍ está en la lista
            _ => false
        };
    }

    // Null Object Pattern: Instancia predeterminada cuando no hay filtro
    /// <summary>
    /// Obtiene la instancia predeterminada, sin filtro.
    /// </summary>
    public static AppFilter None { get; } = new AppFilter(Enumerable.Empty<string>(), FilterMode.None);
}

using Raxer.Infra.Native;
using Raxer.Modules.Remapping;

namespace Raxer.Modules.Profiles;

/// <summary>
/// Regla de remapeo dentro de un perfil: botón/evento del mouse + modificadores hacia una acción.
/// </summary>
public sealed class RemapEntry
{
    public MouseAccion Trigger { get; set; } = MouseAccion.None;
    public Modificador Modifiers { get; set; } = Modificador.None;
    public ActionKind Action { get; set; } = ActionKind.None;

    /// <summary>Argumento opcional para la acción (URL, ruta, velocidad o parámetro de evento).</summary>
    public string? Arg { get; set; }

    /// <summary>Tecla o secuencia de teclas para <see cref="ActionKind.SendKey"/> y <see cref="ActionKind.SendKeyCombo"/>.</summary>
    public List<KeyArti>? Keys { get; set; }
}

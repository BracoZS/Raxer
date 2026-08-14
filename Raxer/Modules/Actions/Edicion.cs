using Raxer.Infra.Native;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    public static void Copiar() => LanzarCombo(KeyCombos.Copiar);
    public static void Pegar() => LanzarCombo(KeyCombos.Pegar);
    public static void Cortar() => LanzarCombo(KeyCombos.Cortar);
    public static void Deshacer() => LanzarCombo(KeyCombos.Deshacer);
    public static void Rehacer() => LanzarCombo(KeyCombos.Rehacer);
    public static void SeleccionarTodo() => LanzarCombo(KeyCombos.SeleccionarTodo);
    public static void Guardar() => LanzarCombo(KeyCombos.Guardar);
    public static void AbrirArchivo() => LanzarCombo(KeyCombos.AbrirArchivo);
    public static void Nuevo() => LanzarCombo(KeyCombos.Nuevo);
    public static void Buscar() => LanzarCombo(KeyCombos.Buscar);
    public static void Imprimir() => LanzarCombo(KeyCombos.Imprimir);
}

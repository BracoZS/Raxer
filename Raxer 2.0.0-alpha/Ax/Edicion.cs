namespace Raxer_2_alpha;
internal static partial class Ax
{
    internal static void Copiar() => LanzarCombo(KeyN.CONTROL, KeyN.C);
    internal static void Pegar() => LanzarCombo(KeyN.CONTROL, KeyN.V);
    internal static void Cortar() => LanzarCombo(KeyN.CONTROL, KeyN.X); 
    internal static void Deshacer() => LanzarCombo(KeyN.CONTROL, KeyN.Z);
    internal static void Rehacer() => LanzarCombo(KeyN.CONTROL, KeyN.Y);
    internal static void SeleccionarTodo() => LanzarCombo(KeyN.CONTROL, KeyN.E);
    internal static void  Guardar() => LanzarCombo(KeyN.CONTROL, KeyN.S);
    internal static void AbrirArchivo() => LanzarCombo(KeyN.CONTROL, KeyN.O);
    internal static void Nuevo() => LanzarCombo(KeyN.CONTROL, KeyN.N);
    internal static void Buscar() => LanzarCombo(KeyN.CONTROL, KeyN.F);
    internal static void Imprimir() => LanzarCombo(KeyN.CONTROL, KeyN.P);
}

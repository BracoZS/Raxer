using Raxer.Infra.Native;

namespace Raxer.Modules.Actions;

public static class MouseConstants
{
    public static readonly int AxisXMax = WinApi.GetSystemMetrics(SystemMetrics.SM_XVIRTUALSCREEN) + WinApi.GetSystemMetrics(SystemMetrics.SM_CXVIRTUALSCREEN);
    public static readonly int AxisYMax = WinApi.GetSystemMetrics(SystemMetrics.SM_YVIRTUALSCREEN) + WinApi.GetSystemMetrics(SystemMetrics.SM_CYVIRTUALSCREEN);
}

public static class KeyCombos
{
    public static readonly KeyArti[] Copiar = [KeyArti.CONTROL, KeyArti.C];
    public static readonly KeyArti[] Pegar = [KeyArti.CONTROL, KeyArti.V];
    public static readonly KeyArti[] Cortar = [KeyArti.CONTROL, KeyArti.X];
    public static readonly KeyArti[] Deshacer = [KeyArti.CONTROL, KeyArti.Z];
    public static readonly KeyArti[] Rehacer = [KeyArti.CONTROL, KeyArti.Y];
    public static readonly KeyArti[] SeleccionarTodo = [KeyArti.CONTROL, KeyArti.A];
    public static readonly KeyArti[] Guardar = [KeyArti.CONTROL, KeyArti.S];
    public static readonly KeyArti[] AbrirArchivo = [KeyArti.CONTROL, KeyArti.O];
    public static readonly KeyArti[] Nuevo = [KeyArti.CONTROL, KeyArti.N];
    public static readonly KeyArti[] Buscar = [KeyArti.CONTROL, KeyArti.F];
    public static readonly KeyArti[] Imprimir = [KeyArti.CONTROL, KeyArti.P];


    public static readonly KeyArti[] Minimizar = [KeyArti.WIN_L, KeyArti.DOWN];
    public static readonly KeyArti[] Maximizar = [KeyArti.WIN_L, KeyArti.UP];
    public static readonly KeyArti[] MinimizarTodo = [KeyArti.WIN_L, KeyArti.M];
}

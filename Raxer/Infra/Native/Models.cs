using System.Runtime.InteropServices;

namespace Raxer.Infra.Native;

[StructLayout(LayoutKind.Sequential)]
internal struct Punto
{
    public int X, Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct Rectangulo
{
    public int left, top, right, bottom;
}

internal enum Ancestro
{
    GetParent = 1,
    GetRoot = 2,
    GetRootOwner = 3
}

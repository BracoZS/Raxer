using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Raxer.Infra.Native;

[StructLayout(LayoutKind.Sequential)]
internal struct PointApi
{
    public int X;
    public int Y;
}

[StructLayout(LayoutKind.Sequential)]
public struct RectApi
{
    public int left, top, right, bottom;
}

internal enum Ancestro
{
    GetParent = 1,
    GetRoot = 2,
    GetRootOwner = 3
}

using System.Runtime.InteropServices;

namespace Raxer_2_alpha.Utilidades;

internal class MensajeroApi
{
    [DllImport("user32.dll", SetLastError = true)]
    internal static extern uint SendInput(uint numInputs, Input[] inputs, int cbSize);

    internal static readonly int GenSize = Marshal.SizeOf<Input>();   
    
    internal struct Input
    {
        public InputEventType type;
        public MKH_InputUnion union;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MKH_InputUnion
    {
        [FieldOffset(0)]
        public MouseInput mouse;

        [FieldOffset(0)]
        public KeyboardInput keyboard;

        [FieldOffset(0)]
        public HardwareInput hardware;
    }

    internal enum InputEventType : int
    {
        Mouse = 0,
        Keyboard = 1,
        Hardware = 2
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseInput
    {
        internal int dx;
        internal int dy;
        internal int mouseData;
        internal MouseN dwFlags;
        internal uint time;
        internal nint dwExtraInfo;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardInput
    {
        internal KeyN wVk;
        internal ushort wScan;
        internal KbFlags dwFlags;
        internal uint time;
        internal nint dwExtraInfo;
    }
}

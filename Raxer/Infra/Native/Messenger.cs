using System.Runtime.InteropServices;

namespace Raxer.Infra.Native;

internal static partial class Messenger
{
    #region Sendinput
    [LibraryImport("user32.dll", SetLastError = true)]
    internal static partial uint SendInput(uint numInputs, INPUT[] inputs, int cbSize);

    [StructLayout(LayoutKind.Sequential)]
    internal struct INPUT
    {
        public InputEventType type;
        public MKH_INPUTUNION union;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct MKH_INPUTUNION
    {
        [FieldOffset(0)]
        public MouseInput Mouse;

        [FieldOffset(0)]
        public KeyboardInput Keyboard;

        [FieldOffset(0)]
        public HardwareInput Hardware;
    }

    internal enum InputEventType : int
    {
        Mouse,      // 0
        Keyboard,   // 1
        Hardware    // 2
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct HardwareInput
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    }
    #endregion

    #region Mouse
    [StructLayout(LayoutKind.Sequential)]
    internal struct MouseInput
    {
        internal int dX;
        internal int dY;
        internal int mouseData;
        internal MouseArti dwFlags;
        internal uint time;
        internal IntPtr dwExtraInfo;
    }

    [Flags]
    internal enum MouseArti : uint
    {
        Move = 0x0001,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        WheelVertical = 0x0800,
        WheelHorizontal = 0x1000,
        WheelDown = 0x0020,
        WheelUp = 0x0040,
        XDown = 0x0080,
        XUp = 0x0100,
        VirtualDesk = 0x4000,
        Absolute = 0x8000,
    }

    internal enum SideButtons
    {
        atrás = 0x0001,
        adelante = 0x0002
    }
    #endregion

    #region Keyboard
    [StructLayout(LayoutKind.Sequential)]
    internal struct KeyboardInput
    {
        internal KeyArti wVk;        // a virtual-key code
        internal ushort wScan;       // a hardware scan code for the key
        internal KbFlags dwFlags;    // specifies various aspects of a keystroke
        internal uint time;
        internal IntPtr dwExtraInfo;
    }

    [Flags]
    internal enum KbFlags : uint
    {
        /// <summary>
        /// If specified, the key is being pressed. If not specified, the key is being released.
        /// </summary>
        KEYDOWN = 0x0000,

        /// <summary>
        /// If specified, the system synthesizes a VK_PACKET keystroke.
        /// The wVk parameter must be zero. 
        /// This flag can only be combined with the KEYEVENTF_KEYUP flag.
        /// For more information, see the Remarks section. 
        ///KEF_EXTENDEDKEY = 0x0001,
        /// </summary>
        EXTENDEDKEY = 0x0001,

        /// <summary>
        /// If specified, the key is being released. If not specified, the key is being pressed. 
        ///KEF_KEYUP = 0x0002,
        /// </summary>
        KEYUP = 0x0002,

        /// <summary>
        /// If specified, wScan identifies the key and wVk is ignored. 
        /// KEF_SCANCODE = 0x0008,
        /// </summary>
        SCANCODE = 0x0008,

        /// <summary>
        /// If specified, the wScan scan code consists of a sequence of two bytes,
        /// where the first byte has a value of 0xE0. See Extended-Key Flag for more info. 
        /// KEF_UNICODE = 0x0004,
        /// </summary>
        UNICODE = 0x0004,
    }
    #endregion

    #region Utils
    internal static readonly int _genSize = Marshal.SizeOf<INPUT>();
    #endregion
}

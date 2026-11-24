namespace Raxer.Modules.Profiles;

/// <summary>
/// Catálogo de acciones soportadas por un remap en <see cref="Modules.Actions.Accion"/>.
/// </summary>
public enum ActionKind
{
    None = 0,

    // Edición
    Copy,
    Paste,
    Cut,
    Undo,
    Redo,
    SelectAll,
    Save,
    OpenFile,
    NewFile,
    Find,
    Print,

    // Multimedia
    MediaMute,
    MediaVolumeDown,
    MediaVolumeUp,
    MediaPrevTrack,
    MediaPlayPause,
    MediaNextTrack,
    MediaStop,
    MicToggleMute,
    MicVolumeUp,
    MicVolumeDown,

    // Ventanas
    WindowMinimize,
    WindowMaximize,
    WindowClose,
    WindowMinimizeAll,
    WindowKill,
    WindowSmartMinimize,
    WindowSmartMaximize,

    // Mouse y puntero
    MouseEvent,
    SetPointerSpeed,
    ChangePointerSpeed,
    ResetPointerSpeed,
    LockAxisX,
    LockAxisY,
    UnlockAxis,

    // Teclado
    SendKey,
    SendKeyCombo,

    // Abrir
    OpenUrl,
    OpenPath
}

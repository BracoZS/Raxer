namespace Raxer.Modules.Remapping;

public enum MouseAccion
{
    None,
    Move,
    LeftDown,
    LeftUp,
    RightDown,
    RightUp,
    MiddleDown,
    MiddleUp,
    WheelUp,
    WheelDown,
    WheelLeft,
    WheelRight,
    SideButton1Down,
    SideButton1Up,
    SideButton2Down,
    SideButton2Up
}

public enum FilterMode
{
    None = 0,  // Sin filtro (todo pasa)
    Whitelist, // Bloquea todo EXCEPTO lo de la lista
    Blacklist  // Bloquea SOLO lo de la lista
}

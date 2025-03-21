namespace Raxer_2_alpha;
[Flags]    
public enum Modificador
{
    None = 0,
    Alt = 1,
    Control = 2,
    NoRepeat = 0x4000,
    Shift = 4,
    Win = 8,
}

internal enum KbFlags : uint
{

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

public enum KeyN : ushort     
{
    NONE = 0x0,
    ESCAPE = 0x1B,
    BACK = 0x08,
    RETURN = 0x0D,
    TAB = 0x09,
    CAPITAL = 0x14,
    SHIFT = 0x10,
    CONTROL = 0x11,
    WIN_L = 0x5B,
    WIN_R = 0x5C,
    MENU = 0x12,  //alt
    SNAPSHOT = 0x2C,    
    PRINT = 0x2A,
    SCROLL = 0x91,
    PAUSE = 0x13,
    INSERT = 0x2D,
    DELETE = 0x2E,
    HOME = 0x24,
    END = 0x23,
    PRIOR = 0x21,
    NEXT = 0x22,
    LEFT = 0x25,
    UP = 0x26,
    RIGHT = 0x27,
    DOWN = 0x28,
    NUM_0 = 0x30,
    NUM_1 = 0x31,
    NUM_2 = 0x32,
    NUM_3 = 0x33,
    NUM_4 = 0x34,
    NUM_5 = 0x35,
    NUM_6 = 0x36,
    NUM_7 = 0x37,
    NUM_8 = 0x38,
    NUM_9 = 0x39,
    SHIFT_L = 0xA0,
    SHIFT_R = 0xA1,
    CONTROL_L = 0xA2,
    CONTROL_R = 0xA3,
    ALT_L = 0xA4,
    ALT_R = 0xA5,
    SPACE = 0x20,
    A = 0x41,
    B = 0x42,
    C = 0x43,
    D = 0x44,
    E = 0x45,
    F = 0x46,
    G = 0x47,
    H = 0x48,
    I = 0x49,
    J = 0x4A,
    K = 0x4B,
    L = 0x4C,
    M = 0x4D,
    N = 0x4E,
    O = 0x4F,
    P = 0x50,
    Q = 0x51,
    R = 0x52,
    S = 0x53,
    T = 0x54,
    U = 0x55,
    V = 0x56,
    W = 0x57,
    X = 0x58,
    Y = 0x59,
    Z = 0x5A,
    // 0x5E - Reserved.
    NUMLOCK = 0x90,
    NUMPAD_0 = 0x60,
    NUMPAD_1 = 0x61,
    NUMPAD_2 = 0x62,
    NUMPAD_3 = 0x63,
    NUMPAD_4 = 0x64,
    NUMPAD_5 = 0x65,
    NUMPAD_6 = 0x66,
    NUMPAD_7 = 0x67,
    NUMPAD_8 = 0x68,
    NUMPAD_9 = 0x69,
    MULTIPLY = 0x6A,
    ADD = 0x6B,
    SEPARATOR = 0x6C,
    SUBTRACT = 0x6D,
    DECIMAL = 0x6E,
    DIVIDE = 0x6F,
    F1 = 0x70,
    F2 = 0x71,
    F3 = 0x72,
    F4 = 0x73,
    F5 = 0x74,
    F6 = 0x75,
    F7 = 0x76,
    F8 = 0x77,
    F9 = 0x78,
    F10 = 0x79,
    F11 = 0x7A,
    F12 = 0x7B,
    F13 = 0x7C,
    F14 = 0x7D,
    F15 = 0x7E,
    F16 = 0x7F,
    F17 = 0x80,
    F18 = 0x81,
    F19 = 0x82,
    F20 = 0x83,
    F21 = 0x84,
    F22 = 0x85,
    F23 = 0x86,
    F24 = 0x87,
    // 0x88-0X8F - Unassigned.
    KANAMODE = 0x15,
    HANGULMODE = 0x15,
    JUNJAMODE = 0x17,
    FINALMODE = 0x18,
    HANJAMODE = 0x19,
    KANJIMODE = 0x19,
    // 0x1A - Undefined.
    IMECONVERT = 0x1C,
    IMENONCONVERT = 0x1D,
    IMEACCEPT = 0x1E,
    IMEMODECHANGE = 0x1F,
    // 0x92-0x96 - OEM specific.
    // 0x97-0x9F - Unassigned.
    BROWSER_BACK = 0xA6,
    BROWSER_FORWARD = 0xA7,
    BROWSER_REFRESH = 0xA8,
    BROWSER_STOP = 0xA9,
    BROWSER_SEARCH = 0xAA,
    BROWSER_FAVORITES = 0xAB,
    BROWSER_HOME = 0xAC,
    VOLUME_MUTE = 0xAD,
    VOLUME_DOWN = 0xAE,
    VOLUME_UP = 0xAF,
    MEDIA_NEXT_TRACK = 0xB0,
    MEDIA_PREV_TRACK = 0xB1,
    MEDIA_STOP = 0xB2,
    MEDIA_PLAY_PAUSE = 0xB3,
    LAUNCH_MAIL = 0xB4,
    LAUNCH_MEDIA_SELECT = 0xB5,
    LAUNCH_APP1 = 0xB6,
    LAUNCH_APP2 = 0xB7,
    // 0xB8-0xB9 - Reserved.
    OEM_PLUS = 0xBB,
    OEM_COMMA = 0xBC,
    OEM_MINUS = 0xBD,
    OEM_PERIOD = 0xBE,
    // 0xC1-0xD7 - Reserved.
    OEM_1 = 0xBA,
    OEM_2 = 0xBF,
    OEM_3 = 0xC0,
    OEM_4 = 0xDB,
    OEM_5 = 0xDC,
    OEM_6 = 0xDD,
    OEM_7 = 0xDE,
    OEM_8 = 0xDF,
    // 0xD8-0xDA - Unassigned.
    OEM_102 = 0xE2,
    OEM_CLEAR = 0xFE,
    // 0xE0 -  Reserved.
    // 0xE1 - OEM specific.
    // 0xE3-E4 - OEM specific.
    /// </summary>
    PROCESSKEY = 0xE5,
    SLEEP = 0x5F,
    APPS = 0x5D,
    // 0xE6 - OEM specific.
    //PACKET = 0xE7,
    // 0xE8 - Unassigned.
    // 0xE9-F5 - OEM specific.
    CANCEL = 0x03,
    CLEAR = 0x0C,
    SELECT = 0x29,
    EXECUTE = 0x2B,
    HELP = 0x2F,
    ATTN = 0xF6,
    CRSEL = 0xF7,
    EXSEL = 0xF8,
    EREOF = 0xF9,
    PLAY = 0xFA,
    ZOOM = 0xFB,
    NONAME = 0xFC,
    PA1 = 0xFD
}

[Flags]
internal enum MouseN : uint
{
    move = 0x0001,
    leftDown = 0x0002,
    leftUp = 0x0004,
    rightDown = 0x0008,
    rightUp = 0x0010,
    wheelVertical = 0x0800,
    wheelHorizontal = 0x1000,
    wheelDown = 0x0020,
    wheelUp = 0x0040,
    xDown = 0x0080,
    xUp = 0x0100,
    virtualDesk = 0x4000,
    absolute = 0x8000,
}

internal enum SideButtons : int
{
    atrás = 0x0001,
    adelante = 0x0002
}

public enum EstadoBoton
{
    down, up
}

internal enum Axis
{
    none, X, Y
}

internal enum AppComando
{
    //browser
    BROWSER_BACKWARD = 1,
    BROWSER_FORWARD = 2,
    BROWSER_REFRESH = 3,
    BROWSER_STOP = 4,
    BROWSER_SEARCH = 5,
    BROWSER_FAVORITES = 6,
    BROWSER_HOME = 7,
    //media
    VOLUME_MUTE = 8,
    VOLUME_DOWN = 9,
    VOLUME_UP = 10,
    MEDIA_NEXTTRACK = 11,
    MEDIA_PREVIOUSTRACK = 12,
    MEDIA_STOP = 13,
    MEDIA_PLAY_PAUSE = 14,
    MEDIA_PLAY = 46,
    MEDIA_PAUSE = 47,
    MEDIA_RECORD = 48,
    MEDIA_FAST_FORWARD = 49,
    MEDIA_REWIND = 50,
    MEDIA_CHANNEL_UP = 51,
    MEDIA_CHANNEL_DOWN = 52,
    //launch
    LAUNCH_MAIL = 15,
    LAUNCH_MEDIA_SELECT = 16,
    LAUNCH_APP1 = 17,
    LAUNCH_APP2 = 18,
    //bass-bajos
    BASS_DOWN = 19,
    BASS_BOOST = 20,
    BASS_UP = 21,
    //treble-agudos
    TREBLE_DOWN = 22,
    TREBLE_UP = 23,
    //mic
    MICROPHONE_VOLUME_MUTE = 24,     //funciona
    MICROPHONE_VOLUME_DOWN = 25,
    MICROPHONE_VOLUME_UP = 26,
    MIC_ON_OFF_TOGGLE = 44,          //x
    //action
    HELP = 27,
    FIND = 28,
    NEW = 29,
    OPEN = 30,
    CLOSE = 31,      //x
    SAVE = 32,
    PRINT = 33,
    UNDO = 34,       //x
    REDO = 35,
    SPELL_CHECK = 42,
    DICTATE_OR_COMMAND_CONTROL_TOGGLE = 43,
    CORRECTION_LIST = 45,
    //clipboard
    COPY = 36,       //x
    CUT = 37,        //x
    PASTE = 38,      //x
    //mail
    REPLY_TO_MAIL = 39,
    FORWARD_MAIL = 40,
    SEND_MAIL = 41,
}

public enum SPI : uint
{
    GETBEEP = 0x0001,
    SETBEEP = 0x0002,
    GETMOUSE = 0x0003,
    SETMOUSE = 0x0004,
    GETBORDER = 0x0005,
    SETBORDER = 0x0006,
    GETKEYBOARDSPEED = 0x000A,
    SETKEYBOARDSPEED = 0x000B,
    LANGDRIVER = 0x000C,
    ICONHORIZONTALSPACING = 0x000D,
    GETSCREENSAVETIMEOUT = 0x000E,
    SETSCREENSAVETIMEOUT = 0x000F,
    GETSCREENSAVEACTIVE = 0x0010,
    SETSCREENSAVEACTIVE = 0x0011,
    GETGRIDGRANULARITY = 0x0012,
    SETGRIDGRANULARITY = 0x0013,
    SETDESKWALLPAPER = 0x0014,
    SETDESKPATTERN = 0x0015,
    GETKEYBOARDDELAY = 0x0016,
    SETKEYBOARDDELAY = 0x0017,
    ICONVERTICALSPACING = 0x0018,
    GETICONTITLEWRAP = 0x0019,
    SETICONTITLEWRAP = 0x001A,
    GETMENUDROPALIGNMENT = 0x001B,
    SETMENUDROPALIGNMENT = 0x001C,
    SETDOUBLECLKWIDTH = 0x001D,
    SETDOUBLECLKHEIGHT = 0x001E,
    GETICONTITLELOGFONT = 0x001F,
    SETDOUBLECLICKTIME = 0x0020,
    SETMOUSEBUTTONSWAP = 0x0021,
    SETICONTITLELOGFONT = 0x0022,
    GETFASTTASKSWITCH = 0x0023,
    SETFASTTASKSWITCH = 0x0024,
    SETDRAGFULLWINDOWS = 0x0025,
    GETDRAGFULLWINDOWS = 0x0026,
    GETNONCLIENTMETRICS = 0x0029,
    SETNONCLIENTMETRICS = 0x002A,
    GETMINIMIZEDMETRICS = 0x002B,
    SETMINIMIZEDMETRICS = 0x002C,
    GETICONMETRICS = 0x002D,
    SETICONMETRICS = 0x002E,
    SETWORKAREA = 0x002F,
    GETWORKAREA = 0x0030,
    SETPENWINDOWS = 0x0031,
    GETHIGHCONTRAST = 0x0042,
    SETHIGHCONTRAST = 0x0043,
    GETKEYBOARDPREF = 0x0044,
    SETKEYBOARDPREF = 0x0045,
    GETSCREENREADER = 0x0046,
    SETSCREENREADER = 0x0047,
    GETANIMATION = 0x0048,
    SETANIMATION = 0x0049,
    GETFONTSMOOTHING = 0x004A,
    SETFONTSMOOTHING = 0x004B,
    SETDRAGWIDTH = 0x004C,
    SETDRAGHEIGHT = 0x004D,
    SETHANDHELD = 0x004E,
    GETLOWPOWERTIMEOUT = 0x004F,
    GETPOWEROFFTIMEOUT = 0x0050,
    SETLOWPOWERTIMEOUT = 0x0051,
    SETPOWEROFFTIMEOUT = 0x0052,
    GETLOWPOWERACTIVE = 0x0053,
    GETPOWEROFFACTIVE = 0x0054,
    SETLOWPOWERACTIVE = 0x0055,
    SETPOWEROFFACTIVE = 0x0056,
    SETCURSORS = 0x0057,
    SETICONS = 0x0058,
    GETDEFAULTINPUTLANG = 0x0059,
    SETDEFAULTINPUTLANG = 0x005A,
    SETLANGTOGGLE = 0x005B,
    GETWINDOWSEXTENSION = 0x005C,
    SETMOUSETRAILS = 0x005D,
    GETMOUSETRAILS = 0x005E,
    SETSCREENSAVERRUNNING = 0x0061,
    SCREENSAVERRUNNING = SETSCREENSAVERRUNNING,
    GETFILTERKEYS = 0x0032,
    SETFILTERKEYS = 0x0033,
    GETTOGGLEKEYS = 0x0034,
    SETTOGGLEKEYS = 0x0035,
    GETMOUSEKEYS = 0x0036,
    SETMOUSEKEYS = 0x0037,
    GETSHOWSOUNDS = 0x0038,
    SETSHOWSOUNDS = 0x0039,
    GETSTICKYKEYS = 0x003A,
    SETSTICKYKEYS = 0x003B,
    GETACCESSTIMEOUT = 0x003C,
    SETACCESSTIMEOUT = 0x003D,
    GETSERIALKEYS = 0x003E,
    SETSERIALKEYS = 0x003F,
    GETSOUNDSENTRY = 0x0040,
    SETSOUNDSENTRY = 0x0041,
    GETSNAPTODEFBUTTON = 0x005F,
    SETSNAPTODEFBUTTON = 0x0060,
    GETMOUSEHOVERWIDTH = 0x0062,
    SETMOUSEHOVERWIDTH = 0x0063,
    GETMOUSEHOVERHEIGHT = 0x0064,
    SETMOUSEHOVERHEIGHT = 0x0065,
    GETMOUSEHOVERTIME = 0x0066,
    SETMOUSEHOVERTIME = 0x0067,
    GETWHEELSCROLLLINES = 0x0068,
    SETWHEELSCROLLLINES = 0x0069,
    GETMENUSHOWDELAY = 0x006A,
    SETMENUSHOWDELAY = 0x006B,
    GETWHEELSCROLLCHARS = 0x006C,
    SETWHEELSCROLLCHARS = 0x006D,
    GETSHOWIMEUI = 0x006E,
    SETSHOWIMEUI = 0x006F,
    GETMOUSESPEED = 0x0070,
    SETMOUSESPEED = 0x0071,
    GETSCREENSAVERRUNNING = 0x0072,
    GETDESKWALLPAPER = 0x0073,
    GETAUDIODESCRIPTION = 0x0074,
    SETAUDIODESCRIPTION = 0x0075,
    GETSCREENSAVESECURE = 0x0076,
    SETSCREENSAVESECURE = 0x0077,
    GETHUNGAPPTIMEOUT = 0x0078,
    SETHUNGAPPTIMEOUT = 0x0079,
    GETWAITTOKILLTIMEOUT = 0x007A,
    SETWAITTOKILLTIMEOUT = 0x007B,
    GETWAITTOKILLSERVICETIMEOUT = 0x007C,
    SETWAITTOKILLSERVICETIMEOUT = 0x007D,
    GETMOUSEDOCKTHRESHOLD = 0x007E,
    SETMOUSEDOCKTHRESHOLD = 0x007F,
    GETPENDOCKTHRESHOLD = 0x0080,
    SETPENDOCKTHRESHOLD = 0x0081,
    GETWINARRANGING = 0x0082,
    SETWINARRANGING = 0x0083,
    GETMOUSEDRAGOUTTHRESHOLD = 0x0084,
    SETMOUSEDRAGOUTTHRESHOLD = 0x0085,
    GETPENDRAGOUTTHRESHOLD = 0x0086,
    SETPENDRAGOUTTHRESHOLD = 0x0087,
    GETMOUSESIDEMOVETHRESHOLD = 0x0088,
    SETMOUSESIDEMOVETHRESHOLD = 0x0089,
    GETPENSIDEMOVETHRESHOLD = 0x008A,
    SETPENSIDEMOVETHRESHOLD = 0x008B,
    GETDRAGFROMMAXIMIZE = 0x008C,
    SETDRAGFROMMAXIMIZE = 0x008D,
    GETSNAPSIZING = 0x008E,
    SETSNAPSIZING = 0x008F,
    GETDOCKMOVING = 0x0090,
    SETDOCKMOVING = 0x0091,
    GETACTIVEWINDOWTRACKING = 0x1000,
    SETACTIVEWINDOWTRACKING = 0x1001,
    GETMENUANIMATION = 0x1002,
    SETMENUANIMATION = 0x1003,
    GETCOMBOBOXANIMATION = 0x1004,
    SETCOMBOBOXANIMATION = 0x1005,
    GETLISTBOXSMOOTHSCROLLING = 0x1006,
    SETLISTBOXSMOOTHSCROLLING = 0x1007,
    GETGRADIENTCAPTIONS = 0x1008,
    SETGRADIENTCAPTIONS = 0x1009,
    GETKEYBOARDCUES = 0x100A,
    SETKEYBOARDCUES = 0x100B,
    GETMENUUNDERLINES = GETKEYBOARDCUES,
    SETMENUUNDERLINES = SETKEYBOARDCUES,
    GETACTIVEWNDTRKZORDER = 0x100C,
    SETACTIVEWNDTRKZORDER = 0x100D,
    GETHOTTRACKING = 0x100E,
    SETHOTTRACKING = 0x100F,
    GETMENUFADE = 0x1012,
    SETMENUFADE = 0x1013,
    GETSELECTIONFADE = 0x1014,
    SETSELECTIONFADE = 0x1015,
    GETTOOLTIPANIMATION = 0x1016,
    SETTOOLTIPANIMATION = 0x1017,
    GETTOOLTIPFADE = 0x1018,
    SETTOOLTIPFADE = 0x1019,
    GETCURSORSHADOW = 0x101A,
    SETCURSORSHADOW = 0x101B,
    GETMOUSESONAR = 0x101C,
    SETMOUSESONAR = 0x101D,
    GETMOUSECLICKLOCK = 0x101E,
    SETMOUSECLICKLOCK = 0x101F,
    GETMOUSEVANISH = 0x1020,
    SETMOUSEVANISH = 0x1021,
    GETFLATMENU = 0x1022,
    SETFLATMENU = 0x1023,
    GETDROPSHADOW = 0x1024,
    SETDROPSHADOW = 0x1025,
    GETBLOCKSENDINPUTRESETS = 0x1026,
    SETBLOCKSENDINPUTRESETS = 0x1027,
    GETUIEFFECTS = 0x103E,
    SETUIEFFECTS = 0x103F,
    GETDISABLEOVERLAPPEDCONTENT = 0x1040,
    SETDISABLEOVERLAPPEDCONTENT = 0x1041,
    GETCLIENTAREAANIMATION = 0x1042,
    SETCLIENTAREAANIMATION = 0x1043,
    GETCLEARTYPE = 0x1048,
    SETCLEARTYPE = 0x1049,
    GETSPEECHRECOGNITION = 0x104A,
    SETSPEECHRECOGNITION = 0x104B,
    GETFOREGROUNDLOCKTIMEOUT = 0x2000,
    SETFOREGROUNDLOCKTIMEOUT = 0x2001,
    GETACTIVEWNDTRKTIMEOUT = 0x2002,
    SETACTIVEWNDTRKTIMEOUT = 0x2003,
    GETFOREGROUNDFLASHCOUNT = 0x2004,
    SETFOREGROUNDFLASHCOUNT = 0x2005,
    GETCARETWIDTH = 0x2006,
    SETCARETWIDTH = 0x2007,
    GETMOUSECLICKLOCKTIME = 0x2008,
    SETMOUSECLICKLOCKTIME = 0x2009,
    GETFONTSMOOTHINGTYPE = 0x200A,
    SETFONTSMOOTHINGTYPE = 0x200B,
    GETFONTSMOOTHINGCONTRAST = 0x200C,
    SETFONTSMOOTHINGCONTRAST = 0x200D,
    GETFOCUSBORDERWIDTH = 0x200E,
    SETFOCUSBORDERWIDTH = 0x200F,
    GETFOCUSBORDERHEIGHT = 0x2010,
    SETFOCUSBORDERHEIGHT = 0x2011,
    GETFONTSMOOTHINGORIENTATION = 0x2012,
    SETFONTSMOOTHINGORIENTATION = 0x2013,
    GETMINIMUMHITRADIUS = 0x2014,
    SETMINIMUMHITRADIUS = 0x2015,
    GETMESSAGEDURATION = 0x2016,
    SETMESSAGEDURATION = 0x2017,
}

public enum AppPermissionTipo
{
    Habilitar,
    Deshabilitar
}

public enum TipoReasignacion
{
    porDefecto,
    botonMouse,
    tecla,
    comboTeclas,
    edicion,
    multimedia,
    accion,
    puntero,
    abrir,
    inhabilitar,
    experimental
}

public enum Predeterminado
{
    ninguno
}
public enum BotonMouseOpciones
{
    clicIzquierdo,
    clicDerecho,
    clicCentral,
    scrollUp,
    scrollDown,
    scrollRight,
    scrollLeft,
    atras,
    adelante
}
public enum ComboTeclasOpciones
{
    combo,
    seleccionarCombo  
}
public enum EdicionOpciones
{
    copiar,
    pegar,
    cortar,
    deshacer,
    rehacer,
    nuevo,
    guardar,
    abrirArchivo,
    seleccionarTodo,
    buscar,
    imprimir
}
public enum MultimediaOpciones
{
    subirVolumen,
    bajarVolumen,
    pistaAnterior,
    pistaSiguiente,
    playPause,
    stop,
    silenciar,
    switchMic,
    subirVolumenMicrofono,
    bajarVolumenMicrofono,
}
public enum AccionesOpciones
{
    minimizarVentana,
    maximizarVentana,
    cerrarVentana,
    minimizarTodo,
    kill,
    busquedaGoogle,
    busquedaBing,
    busquedaYahoo,
    busquedaDuckduckgo,
    busquedaAsk,
    busquedaWikipedia,
    busquedaYoutube
}
public enum PunteroOpciones
{
    setPunteroSpeed,
    changuePunteroSpeed,
    fijarHorizontal,
    fijarVertical,
}
public enum AbrirOpciones
{
    objetoSeleccionado,
    abrirSitioWeb,
    abrirArchivo,
    abrirFolder,
    abrirAplicacion
}
public enum InhabilitarOpcion
{
    deshabilitar
}

public enum ExperimentalFuns
{
    switchMinimizar,
    switchMaximizar,
    wildDrag,
}


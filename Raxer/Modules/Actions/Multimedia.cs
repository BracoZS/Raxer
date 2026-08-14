using Raxer.Infra.Native;
using Raxer.Infra.Tools;

namespace Raxer.Modules.Actions;

internal static partial class Accion
{
    public static void MediaMute() => LanzarTecla(KeyArti.VOLUME_MUTE);
    public static void MediaBajarVolumen() => LanzarTecla(KeyArti.VOLUME_DOWN);
    public static void MediaSubirVolumen() => LanzarTecla(KeyArti.VOLUME_UP);
    public static void MediaPistaAnterior() => LanzarTecla(KeyArti.MEDIA_PREV_TRACK);
    public static void MediaPlayPause() => LanzarTecla(KeyArti.MEDIA_PLAY_PAUSE);
    public static void MediaPistaSiguiente() => LanzarTecla(KeyArti.MEDIA_NEXT_TRACK);
    public static void MediaStop() => LanzarTecla(KeyArti.MEDIA_STOP);
    public static void SwitchMicrofono() => SystemTools.RunAppCommand(AppCommand.MICROPHONE_VOLUME_MUTE);
    public static void MicrofonoSubirVolumen() => SystemTools.RunAppCommand(AppCommand.MICROPHONE_VOLUME_UP);
    public static void MicrofonoBajarVolumen() => SystemTools.RunAppCommand(AppCommand.MICROPHONE_VOLUME_DOWN);
}

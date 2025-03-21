using static Raxer_2_alpha.Utilidades.Auxiliares;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    internal static void MediaMute() => RunComando(AppComando.VOLUME_MUTE);
    internal static void MediaBajarVolumen() => LanzarTecla(KeyN.VOLUME_DOWN);
    internal static void MediaSubirVolumen() => LanzarTecla(KeyN.VOLUME_UP);
    internal static void MediaPistaAnterior() => LanzarTecla(KeyN.MEDIA_PREV_TRACK);
    internal static void MediaPlayPause() => LanzarTecla(KeyN.MEDIA_PLAY_PAUSE);
    internal static void MediaPistaSiguiente() => LanzarTecla(KeyN.MEDIA_NEXT_TRACK);
    internal static void MediaStop() => LanzarTecla(KeyN.MEDIA_STOP);
    internal static void SwitchMicrofono() => RunComando(AppComando.MICROPHONE_VOLUME_MUTE);
    internal static void SubirVolumenMicrofono() => RunComando(AppComando.MICROPHONE_VOLUME_UP);
    internal static void BajarVolumenMicrofono() => RunComando(AppComando.MICROPHONE_VOLUME_DOWN);
}

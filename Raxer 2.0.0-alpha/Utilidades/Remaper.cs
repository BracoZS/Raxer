using Raxer_2_alpha.Modelos;
using Raxer_2_alpha.ViewModels;
using static Raxer_2_alpha.Ax;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using static Raxer_2_alpha.Utilidades.UIMostrador;
using System.IO;

namespace Raxer_2_alpha.Utilidades;

internal class Remaper
{ 
    private static readonly Lazy<Remaper> instance = new Lazy<Remaper>(() => new Remaper());
    private Remaper() { }
    public static Remaper GetMap()
    {
        return instance.Value;
    }

    internal ObservableCollection<UIEnum> EnumToObservableCollection<T>() where T : Enum    
    {
        ObservableCollection<UIEnum> mappedList = new();
        foreach(Enum item in Enum.GetValues(typeof(T)))
        {
            mappedList.Add(new UIEnum()
            {
                LangValor = UIMostrador.GetLocalIdioma(item),
                Valor = item
            });
        }
        return mappedList;
    }

    internal void UpdateOpciones(BotonVM userboton)
    {
        switch(userboton.TipoSeleccionado)
        {
            case TipoReasignacion.porDefecto:
                userboton.Opciones = EnumToObservableCollection<Predeterminado>();
                userboton.OpcionSelIndex = 0;
                break;

            case TipoReasignacion.botonMouse:
                userboton.Opciones = EnumToObservableCollection<BotonMouseOpciones>();
                break;

            case TipoReasignacion.tecla:
                userboton.Opciones = EnumToObservableCollection<KeyN>();
                break;

            case TipoReasignacion.comboTeclas:
                userboton.Opciones = EnumToObservableCollection<ComboTeclasOpciones>();
                break;

            case TipoReasignacion.edicion:
                userboton.Opciones = EnumToObservableCollection<EdicionOpciones>();
                break;

            case TipoReasignacion.multimedia:
                userboton.Opciones = EnumToObservableCollection<MultimediaOpciones>();
                break;

            case TipoReasignacion.accion:
                userboton.Opciones = EnumToObservableCollection<AccionesOpciones>();
                break;

            case TipoReasignacion.puntero:
                userboton.Opciones = EnumToObservableCollection<PunteroOpciones>();
                break;

            case TipoReasignacion.abrir:
                userboton.Opciones = EnumToObservableCollection<AbrirOpciones>();
                userboton.Opciones.RemoveAt(0); //?

                break;

            case TipoReasignacion.inhabilitar:
                userboton.Opciones = EnumToObservableCollection<InhabilitarOpcion>();
                userboton.OpcionSelIndex = 0;
                break;

            case TipoReasignacion.experimental:
                userboton.Opciones = EnumToObservableCollection<ExperimentalFuns>();
                break;
        }
    }

    internal void MapearOpcionSeleccionada(BotonVM userboton)
    {
        switch(userboton.TipoSeleccionado)
        {
            default:
            case TipoReasignacion.porDefecto:
                userboton.CoreBoton.Resset();
                break;

            case TipoReasignacion.botonMouse:
                userboton.CoreBoton.LowReasignacion(getFunMouse(userboton.OpcionSeleccionada, isDown: true));
                userboton.CoreBoton.LowReasignacion(getFunMouse(userboton.OpcionSeleccionada, isDown: false), EstadoBoton.up);
                break;

            case TipoReasignacion.tecla:
                userboton.CoreBoton.LowReasignacion(() => LanzarTeclaDown((KeyN)userboton.OpcionSeleccionada), EstadoBoton.down);
                userboton.CoreBoton.LowReasignacion(LanzarTeclaUp, EstadoBoton.up);
                break;

            case TipoReasignacion.comboTeclas:
                applyComboOption(userboton);
                break;

            case TipoReasignacion.edicion:  
                userboton.CoreBoton.LowReasignacion(getFunEdicion(userboton.OpcionSeleccionada));
                break;

            case TipoReasignacion.multimedia: 
                userboton.CoreBoton.LowReasignacion(getFunMultimedia(userboton.OpcionSeleccionada), EstadoBoton.down);
                break;

            case TipoReasignacion.accion:
                userboton.CoreBoton.LowReasignacion(getFunAccion(userboton.OpcionSeleccionada));
                break;

            case TipoReasignacion.puntero: 
                applyPunteroOption(userboton);
                break;

            case TipoReasignacion.abrir:
                appplyAbrirOption(userboton);
                break;

            case TipoReasignacion.inhabilitar: 
                userboton.CoreBoton.Deshabilitar();
                break;

            case TipoReasignacion.experimental:
                ApplyFunExperimental(userboton);
                break;
        }
    }

    private void applyComboOption(BotonVM userboton)
    {
        if((ComboTeclasOpciones)userboton.OpcionSeleccionada == ComboTeclasOpciones.seleccionarCombo)
        {
            var sdc = new SelectDialog(SelectDialog.SelectDialogType.getCombo);

            if(sdc.ShowDialog() == true)
            {
                userboton.CoreBoton.LowReasignacion(getFunComboTeclas(sdc.Argus.ComboList));

                var uiKeys = string.Join(" + ", sdc.Argus.ComboList);

                userboton.Opciones.Clear();
                UpdateOpciones(userboton);
                userboton.Opciones.Insert(0, new UIEnum
                {
                    Valor = ComboTeclasOpciones.combo,
                    LangValor = uiKeys
                });

                userboton.OpcionSelIndex = 0;
            }
            else
            {
                userboton.CoreBoton.Resset();

                userboton.OpcionSeleccionada = null;
                UpdateOpciones(userboton);
            }
        }
    }

    private void applyPunteroOption(BotonVM userboton)
    {
        switch(userboton.OpcionSeleccionada)
        {
            case PunteroOpciones.setPunteroSpeed:
                var dsps = new SelectDialog(SelectDialog.SelectDialogType.getPunteroValueToSet);
                if(dsps.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(() => SetPunteroSpeed(dsps.Argus.Num));
                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = PunteroOpciones.setPunteroSpeed,
                        LangValor = UIMostrador.GetLocalIdioma(PunteroOpciones.setPunteroSpeed) + $" a {dsps.Argus.Num}"
                    });
                }
                break;
            case PunteroOpciones.changuePunteroSpeed:
                var dchps = new SelectDialog(SelectDialog.SelectDialogType.getPunteroValueToChangue);
                if(dchps.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(()=>ChanguePunteroSpeed(dchps.Argus.Num));
                 
                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = PunteroOpciones.changuePunteroSpeed,
                        LangValor = UIMostrador.GetLocalIdioma(PunteroOpciones.changuePunteroSpeed) + $" a {dchps.Argus.Num}"
                    });
                }
                break;
            case PunteroOpciones.fijarHorizontal:
                userboton.CoreBoton.LowReasignacion(FijarEjeX);
                userboton.CoreBoton.LowReasignacion(SoltarEje, EstadoBoton.up);
                break;
            case PunteroOpciones.fijarVertical:
                userboton.CoreBoton.LowReasignacion(FijarEjeY);
                userboton.CoreBoton.LowReasignacion(SoltarEje, EstadoBoton.up);
                break;
        }
    }

    private void appplyAbrirOption(BotonVM userboton)
    {
        switch(userboton.OpcionSeleccionada)
        {
            case AbrirOpciones.abrirSitioWeb:
                var sdw = new SelectDialog(SelectDialog.SelectDialogType.getDirWeb);
                if(sdw.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(()=>AbrirWeb(sdw.Argus.Text));

                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = AbrirOpciones.abrirSitioWeb,
                        LangValor = GetLocalIdioma(AbrirOpciones.abrirSitioWeb) + $" \"{sdw.Argus.Text}\""
                    });
                }
                else
                {
                    UpdateOpciones(userboton);
                }
                break;

            case AbrirOpciones.abrirArchivo:
                var ofda = new OpenFileDialog
                {
                    Title = "Selecciona un archivo",
                    Filter = "Todos los archivos (*.*)|*.*",
                };
                if(ofda.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(()=> AbrirRutaLocal(ofda.FileName));

                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = AbrirOpciones.abrirArchivo,
                        LangValor = GetLocalIdioma(AbrirOpciones.abrirArchivo) + $" \"{ofda.FileName}\""
                    });
                }
                else
                {
                    UpdateOpciones(userboton);
                }
                break;

            case AbrirOpciones.abrirFolder:
                var ofdf = new OpenFolderDialog { Title = "Selecciona una Carpeta" };
                if(ofdf.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(() => AbrirRutaLocal(ofdf.FolderName));

                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = AbrirOpciones.abrirFolder,
                        LangValor = GetLocalIdioma(AbrirOpciones.abrirFolder) + $" \"{ofdf.FolderName}\""
                    });
                }
                else
                {
                    UpdateOpciones(userboton);
                }
                break;

            case AbrirOpciones.abrirAplicacion:
                var ofdapp = new OpenFileDialog
                {
                    Title = "Selecciona un archivo ejecutable de aplicación (.exe)",
                    Filter = "Archivos ejecutables (*.exe)|*.exe"
                };
                if (ofdapp.ShowDialog() == true)
                {
                    userboton.CoreBoton.LowReasignacion(()=> AbrirRutaLocal(ofdapp.FileName));

                    userboton.Opciones.Clear();
                    UpdateOpciones(userboton);
                    userboton.Opciones.Insert(0, new UIEnum
                    {
                        Valor = AbrirOpciones.abrirAplicacion,
                        LangValor = GetLocalIdioma(AbrirOpciones.abrirAplicacion) + $" \"{Path.GetFileName(ofdapp.FileName)}\""
                    });
                }
                else
                {
                    UpdateOpciones(userboton);
                }
                break;
        }
    }

    private Action getFunMouse(Enum boton, bool isDown)
    {
        return boton switch
        {
            BotonMouseOpciones.clicIzquierdo when isDown => static () => LanzarMouseEvent(MouseN.leftDown),
            BotonMouseOpciones.clicIzquierdo when !isDown => () => LanzarMouseEvent(MouseN.leftUp),

            BotonMouseOpciones.clicDerecho when isDown => () => LanzarMouseEvent(MouseN.rightDown),
            BotonMouseOpciones.clicDerecho when !isDown => () => LanzarMouseEvent(MouseN.rightUp),

            BotonMouseOpciones.clicCentral when isDown => () => LanzarMouseEvent(MouseN.wheelDown),
            BotonMouseOpciones.clicCentral when !isDown => () => LanzarMouseEvent(MouseN.wheelUp),

            BotonMouseOpciones.scrollUp when isDown => () => LanzarMouseEvent(MouseN.wheelVertical, 120),
            BotonMouseOpciones.scrollDown when isDown => () => LanzarMouseEvent(MouseN.wheelVertical, -120),

            BotonMouseOpciones.scrollRight when isDown => () => LanzarMouseEvent(MouseN.wheelHorizontal, 120),
            BotonMouseOpciones.scrollLeft when isDown => () => LanzarMouseEvent(MouseN.wheelHorizontal, -120),

            BotonMouseOpciones.atras when isDown => () => LanzarMouseEvent(MouseN.xDown, (int)SideButtons.atrás),
            BotonMouseOpciones.atras when !isDown => () => LanzarMouseEvent(MouseN.xUp, (int)SideButtons.atrás),

            BotonMouseOpciones.adelante when isDown => () => LanzarMouseEvent(MouseN.xDown, (int)SideButtons.adelante),
            BotonMouseOpciones.adelante when !isDown => () => LanzarMouseEvent(MouseN.xUp, (int)SideButtons.adelante),
            
            _ => delegate { }
        };
    }

    private Action getFunComboTeclas(KeyN[] combo) => () => LanzarCombo(combo); 

    private Action getFunEdicion(Enum opcion) 
    {
        return opcion switch
        {
            EdicionOpciones.copiar => Copiar,
            EdicionOpciones.pegar => Pegar,
            EdicionOpciones.cortar => Cortar,
            EdicionOpciones.deshacer => Deshacer,
            EdicionOpciones.rehacer => Rehacer,
            EdicionOpciones.seleccionarTodo => SeleccionarTodo,
            EdicionOpciones.guardar => Guardar,
            EdicionOpciones.abrirArchivo => AbrirArchivo,
            EdicionOpciones.nuevo => Nuevo,
            EdicionOpciones.buscar => Buscar,
            EdicionOpciones.imprimir => Imprimir,
            _ => () => { }
        };
    }

    private Action getFunMultimedia(Enum opcion) 
    {
        return opcion switch
        {
            MultimediaOpciones.silenciar => MediaMute,
            MultimediaOpciones.bajarVolumen => MediaBajarVolumen,
            MultimediaOpciones.subirVolumen => MediaSubirVolumen,
            MultimediaOpciones.pistaAnterior => MediaPistaAnterior,
            MultimediaOpciones.pistaSiguiente => MediaPistaSiguiente,
            MultimediaOpciones.playPause => MediaPlayPause,
            MultimediaOpciones.stop => MediaStop,
            MultimediaOpciones.switchMic => SwitchMicrofono,
            MultimediaOpciones.subirVolumenMicrofono => SubirVolumenMicrofono,
            MultimediaOpciones.bajarVolumenMicrofono => BajarVolumenMicrofono,
            _ => delegate { }
        };
    }

    private Action getFunAccion(Enum opcion) 
    {
        return opcion switch
        {
            AccionesOpciones.minimizarVentana => MinimizarVentana,
            AccionesOpciones.maximizarVentana => MaximizarVentana,
            AccionesOpciones.cerrarVentana => CerrarVentana,
            AccionesOpciones.minimizarTodo => MinimizarTodo,
            AccionesOpciones.kill => KillWindow,
            AccionesOpciones.busquedaGoogle => () => BusquedaWeb(Buscadores.google),
            AccionesOpciones.busquedaBing => () => BusquedaWeb(Buscadores.bing),
            AccionesOpciones.busquedaDuckduckgo => () => BusquedaWeb(Buscadores.duckduckgo),
            AccionesOpciones.busquedaYahoo => () => BusquedaWeb(Buscadores.yahoo),
            AccionesOpciones.busquedaAsk => () => BusquedaWeb(Buscadores.ask),
            AccionesOpciones.busquedaWikipedia => () => BusquedaWeb(Buscadores.wikipedia),
            AccionesOpciones.busquedaYoutube => () => BusquedaWeb(Buscadores.youtube),
            _ => delegate { }
        };
    }

    private void ApplyFunExperimental(BotonVM b)
    {
        switch(b.OpcionSeleccionada)
        {
            case ExperimentalFuns.switchMinimizar:
                b.CoreBoton.LowReasignacion(SwitchMinimizar);
                break;
            case ExperimentalFuns.switchMaximizar:
                b.CoreBoton.LowReasignacion(SwitchMaximizar);
                break;
            case ExperimentalFuns.wildDrag:
                b.CoreBoton.LowReasignacion(InicioDragPoint, EstadoBoton.down);
                b.CoreBoton.LowReasignacion(FinDragPoint, EstadoBoton.up);
                break;
        }
    }
}


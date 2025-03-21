using Raxer_2_alpha.Modelos;
using Raxer_2_alpha.Utilidades;
using System.Collections.ObjectModel;

namespace Raxer_2_alpha.ViewModels;
internal class BotonVM : VMBase
{
    private Remaper maper = Remaper.GetMap();

    private  ObservableCollection<UIEnum> _tipos;
    private  TipoReasignacion _tipoSeleccionado;
    private  int _tipoSelIndex = -1;
    private  ObservableCollection<UIEnum> _opciones;
    private  Enum _opcionSeleccionada;
    private  int _opcionSelIndex = -1;

    public Boton CoreBoton { get; set; }

    public ObservableCollection<UIEnum> Tipos
    {
        get
        {
            _tipos = maper.EnumToObservableCollection<TipoReasignacion>();

            TipoSelIndex = 0;

            return _tipos;
        }
    }

    public TipoReasignacion TipoSeleccionado
    {
        get => _tipoSeleccionado;
        set
        {
            _tipoSeleccionado = value;
            propiedadCambiada();

            maper.UpdateOpciones(this);
        }
    }

    public int TipoSelIndex
    {
        get => _tipoSelIndex;
        set
        {
            _tipoSelIndex = value;
            propiedadCambiada();
        }
    }

    public ObservableCollection<UIEnum> Opciones
    {
        get => _opciones;
        set
        {
            _opciones = value;
            propiedadCambiada();    
        }
    }

    public Enum OpcionSeleccionada
    {
        get => _opcionSeleccionada;
        set
        {
            if(value != null && _opcionSeleccionada != value)
            {
                _opcionSeleccionada = value;
                propiedadCambiada();
                maper.MapearOpcionSeleccionada(this);
            }
        }
    }

    public int OpcionSelIndex
    {
        get => _opcionSelIndex;
        set
        {
            _opcionSelIndex = value;
            propiedadCambiada();
        }
    }
}

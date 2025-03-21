using Raxer_2_alpha.Modelos;
using Raxer_2_alpha.Utilidades;

namespace Raxer_2_alpha.ViewModels;
internal class PerfilesVM : VMBase
{
    private static BotonVM _clicIzquierdo =  new() { CoreBoton = MouseMap.Actual.Boton1};
    private static BotonVM _clicDerecho = new() { CoreBoton = MouseMap.Actual.Boton2 };
    private static BotonVM _clicCentral = new BotonVM { CoreBoton = MouseMap.Actual.Boton3 };
    private static BotonVM _atras =  new BotonVM { CoreBoton = MouseMap.Actual.Boton4} ;
    private static BotonVM _adelante = new BotonVM { CoreBoton = MouseMap.Actual.Boton5} ;

    public BotonVM ClicIzquierdo
    {
        get => _clicIzquierdo;
        set
        {
            _clicIzquierdo = value;
        }
    }

    public BotonVM ClicDerecho
    {
        get => _clicDerecho;
        set
        {
            _clicDerecho = value;
        }
    }

    public BotonVM ClicCentral
    {
        get => _clicCentral;
        set
        {
            _clicCentral = value;
        }
    }

    public BotonVM Adelante
    {
        get => _adelante;
        set
        {
            _adelante = value;
        }
    }

    public BotonVM Atras
    {
        get => _atras;
        set
        {
            _atras = value;
        }
    }
}

using System.Text.Json.Serialization;
using Hilo = System.Threading.ThreadPool;
using static Raxer_2_alpha.Utilidades.Auxiliares;

namespace Raxer_2_alpha.Modelos;
internal class Boton
{
    private readonly Dictionary<Modificador, Action> _down = new();
    private readonly Dictionary<Modificador, Action> _up = new();
    private static Action _nuevoAx;
    private EstadoBoton _estado;
    private bool _isDesactivado = false;

    public bool Reasignado { get; set; }
    [JsonIgnore]

    public Action NuevoAx
    {
        get
        {
            _nuevoAx = _estado == EstadoBoton.down ?
                _down[GetPressedModificador()] :
                _up[GetPressedModificador()];

            return _nuevoAx;
        }
    }

    public Boton()
    {
        _down[Modificador.None] = delegate { };
        _up[Modificador.None] = delegate { };
    }

    internal void LowReasignacion(Action nuevaAccion, EstadoBoton estadoBoton = default, Modificador modificador = default)
    {
        if(nuevaAccion is not null)
        {
            switch(estadoBoton)
            {
                case EstadoBoton.down:
                    _down[modificador] = nuevaAccion;
                    break;
                case EstadoBoton.up:
                    _up[modificador] = nuevaAccion;
                    break;
            }

            Reasignado = true;
            _isDesactivado = false;
        }
    }

    internal void Deshabilitar()
    {
        Reasignado = false;
        _isDesactivado = true;
    }

    internal void Resset()
    {
        Reasignado = false;
        _isDesactivado = false;
    }

    private void RunNew(object o)
    {
        if(MouseMap.Actual.FiltroApps?.ShoulApply(GetAppExeName()) == true)
            NuevoAx();
        else
            NuevoAx();
    }

    internal bool VerificarManejo(EstadoBoton estado = default)
    {
        if(Reasignado)
        {
            _estado = estado;
            Hilo.QueueUserWorkItem(RunNew);
            return true;
        }

        if(_isDesactivado)
            return true;

        return false;
    }
}

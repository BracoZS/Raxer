namespace Raxer_2_alpha.Modelos;

internal class Movement
{
    private Action _nuevoAx;

    public bool Reasignado { get; set; }

    public Action NuevoAx
    {
        get => _nuevoAx;
        set
        {
            if(value != null)
            {
                _nuevoAx = value;
                Reasignado = true;
            }
        }
    }

    internal void LowReasignacion(Action accion)
    {
        if(accion != null)
        {
            _nuevoAx = accion;
            Reasignado = true;
        }
    }

    internal void verificarManejo()
    {
        if(Reasignado)
            _nuevoAx?.Invoke();
    }

    public void EndSeg() => Reasignado = false;
}

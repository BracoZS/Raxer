using Raxer_2_alpha.Modelos;
using Raxer_2_alpha.Utilidades;

namespace Raxer_2_alpha.ViewModels;

internal class NavegadorVM : VMBase
{
    private VMBase _paginaActual;
    private InicioVM _inicio;
    private PerfilesVM _perfiles;
    private FiltrosVM _filtros;
    private InfoVM _info;

    public VMBase PaginaActual
    {
        get => _paginaActual;
        set
        {
            if(value != null)
                _paginaActual = value;

            actualizarPaginaActual();

            propiedadCambiada();
        }
    }

    public InicioVM Inicio
    {
        get => _inicio;
        set
        {
            _inicio = value;
            propiedadCambiada();
        }
    }

    public PerfilesVM Perfiles
    {
        get => _perfiles;
        set
        {
            _perfiles = value;
            propiedadCambiada();
        }
    }

    public FiltrosVM Filtros
    {
        get => _filtros;
        set
        {
            _filtros = value;
            propiedadCambiada();
        }
    }

    public InfoVM Info
    {
        get => _info;
        set
        {
            _info = value;
            propiedadCambiada();
        }
    }


    public bool EsVisibleInicio { get; set; }
    public bool EsVisiblePerfiles { get; set; }
    public bool EsVisibleFiltros { get; set; }
    public bool EsVisibleInfo { get; set; }


    public Comando IrInicio { get; set; }
    public Comando IrPerfiles { get; set; }
    public Comando IrFiltros { get; set; }
    public Comando IrInfo { get; set; }

    public NavegadorVM()
    {
        _inicio = new InicioVM();
        _perfiles = new PerfilesVM();
        _filtros = new FiltrosVM();
        _info = new InfoVM();

        IrInicio = new Comando(navegarInicio);
        IrPerfiles = new Comando(navegarPerfiles);
        IrFiltros = new Comando(navegarFiltros);
        IrInfo = new Comando(navegarInfo);

        PaginaActual = _info;
    } 

    void navegarInicio() => PaginaActual = _inicio;
    void navegarPerfiles() => PaginaActual = _perfiles;
    void navegarFiltros() => PaginaActual = _filtros;
    void navegarInfo() => PaginaActual = _info;

    private void actualizarPaginaActual()
    {
        EsVisibleInicio = PaginaActual == _inicio;
        EsVisiblePerfiles = PaginaActual == _perfiles;
        EsVisibleFiltros = PaginaActual == _filtros;
        EsVisibleInfo = PaginaActual == _info;

        propiedadCambiada(nameof(EsVisibleInicio));
        propiedadCambiada(nameof(EsVisiblePerfiles));
        propiedadCambiada(nameof(EsVisibleFiltros));
        propiedadCambiada(nameof(EsVisibleInfo));
    }
}

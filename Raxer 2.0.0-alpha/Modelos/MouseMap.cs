using Raxer_2_alpha.Views;

namespace Raxer_2_alpha.Modelos;

internal class MouseMap
{
    static Boton _boton1 = new Boton();
    static Boton _boton2 = new Boton();
    static Boton _boton3 = new Boton();
    static Boton _ruedaArriba = new Boton();
    static Boton _ruedaAbajo = new Boton();
    static Boton _ruedaIzquierda = new Boton();
    static Boton _ruedaDerecha = new Boton();
    static Boton _atras = new Boton();
    static Boton _adelante = new Boton();
    static Movement _movimiento = new Movement();
    static Filtro _filtro = new Filtro(AppPermissionTipo.Habilitar);

    public Boton Boton1
    {
        get => _boton1;
        set => _boton1 = value;
    }
    public Boton Boton2
    {
        get => _boton2;
        set => _boton2 = value;
    }
    public Boton Boton3
    {
        get => _boton3;
        set => _boton3 = value;
    }
    public Boton RuedaArriba
    {
        get => _ruedaArriba;
        set => _ruedaArriba = value;
    }
    public Boton RuedaAbajo
    {
        get => _ruedaAbajo;
        set => _ruedaAbajo = value;
    }
    public Boton RuedaIzquierda
    {
        get => _ruedaIzquierda;
        set => _ruedaIzquierda = value;
    }
    public Boton RuedaDerecha
    {
        get => _ruedaDerecha;
        set => _ruedaDerecha = value;
    }
    public Boton Boton4
    {
        get => _atras;
        set => _atras = value;
    }
    public Boton Boton5
    {
        get => _adelante;
        set => _adelante = value;
    }
    public Movement Movimiento
    {
        get => _movimiento;
        set => _movimiento = value;
    }
    internal Filtro FiltroApps
    {
        get => _filtro;
        set => _filtro = value;
    }

    private static readonly MouseMap singleInstancia = new MouseMap();
    private MouseMap() { }
    public static MouseMap Actual => singleInstancia;
}

namespace Raxer_2_alpha.Utilidades;

internal class Comando : ICommand
{
    public event EventHandler CanExecuteChanged;
    private readonly Action _accion;

    public Comando(Action accion) => _accion = accion;

    public bool CanExecute(object param) => true;
    public void Execute(object param) => _accion();
}

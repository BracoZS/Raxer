using System.Linq;
namespace Raxer_2_alpha.Modelos;
internal class Filtro
{
    private HashSet<string> _appList;
    private readonly AppPermissionTipo _permiso;

    public HashSet<string> AppList => _appList;
    public AppPermissionTipo TipoPermiso => _permiso;

    public Filtro(AppPermissionTipo permiso)
    {
        _permiso = permiso;
        _appList = new();
    }

    internal bool ShoulApply(string nombreApp)
    {
        return _permiso == AppPermissionTipo.Habilitar ?
            _appList.Contains(nombreApp) :
            !_appList.Contains(nombreApp);
    }

    internal void AñadirApp(params string[] nombresDeApps) => _appList.UnionWith(nombresDeApps);
    internal void RemoverApp(params string[] nombresDeApps) => _appList.ExceptWith(nombresDeApps);
}

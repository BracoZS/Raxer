using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Raxer_2_alpha.Utilidades;
internal class VMBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    
    protected void propiedadCambiada([CallerMemberName] string nombreDePropiedad = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombreDePropiedad));
    }
}

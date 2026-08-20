using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Raxer.Modules.Settings.PageVMs;

public partial class InicioVM : ObservableObject
{
    [ObservableProperty]
    string perfilActual = "Glorius 3X80CR";

    [ObservableProperty]
    string filtroActual = "Office aplications";

    [ObservableProperty]
    string archivoConfig = @"C:\Settings\ConfigFiles.rxconfig";

    [ObservableProperty]
    string atajoPerfil = "Control + R + >";

    [ObservableProperty]
    bool notificaciones = true;

    [ObservableProperty]
    double velocidadPuntero = 50;

    [ObservableProperty]
    bool mejoraPrecision = false;
}

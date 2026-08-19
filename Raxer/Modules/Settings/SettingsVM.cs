using Raxer.Modules.Settings.Pages;

namespace Raxer.Modules.Settings;

public partial class SettingsVM : ObservableObject
{
    [ObservableProperty]
    object? paginaActual;

    [ObservableProperty]
    bool arrancarConWindows;

    public SettingsVM()
    {
        ArrancarConWindows = App.Settings!.ArrancarConWindows;
        PaginaActual = new InicioPage();
    }

    partial void OnArrancarConWindowsChanged(bool value)
    {
        App.Settings!.ArrancarConWindows = value;
    }

    [RelayCommand]
    void IrAInicio() => PaginaActual = new InicioPage();

    [RelayCommand]
    void IrAPerfiles() => PaginaActual = new PerfilesPage();

    [RelayCommand]
    void IrAFiltros() => PaginaActual = new FiltrosPage();

    [RelayCommand]
    void IrAInfo() => PaginaActual = new InfoPage();
}

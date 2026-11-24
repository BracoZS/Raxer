# Stack y convenciones

## Stack

| Layer | Technology | Version | Note |
|---|---|---|---|
| Language | C# | C# 15 (.NET 11) | `Nullable` y `ImplicitUsings` habilitados |
| Runtime / TFM | .NET | `net11.0-windows7.0` | `AllowUnsafeBlocks`, P/Invoke con `[LibraryImport]` |
| UI | WPF + WinForms | built-in | WPF para ventanas; WinForms solo para `TrayIcon` |
| MVVM | `CommunityToolkit.Mvvm` | `8.4.2` | |
| i18n | `LangRX` | `1.0.1` | `.resx` (EN neutral + `Resources.es.resx`) |
| Storage | `LocalSettingsJson` | `1.0.0` | Settings JSON en AppData |
| Errors / Flow | `ResultPattern.Net` | `1.1.0` | |
| Target OS | Windows | 7.0+ | `WinExe` |
| Packaging | TBD | TBD | |
| Auto-update | TBD | TBD | |

## Estructura del repo

- `Raxer/Modules/` — features de la app, cada una es su propia unidad
- `Raxer/Infra/` — infraestructura reusable (native P/Invoke, storage, tools, shared, dev)
- `.agents/` — memoria y contexto del proyecto

## Comandos

| Action | Command |
|---|---|
| Build | `dotnet build` *(solo con permiso del developer)* |
| Run | `dotnet run --project Raxer/Raxer.csproj` *(solo con permiso del developer)* |
| Test | TBD |

## Convenciones

- Code: Código artisan, KISS, estilo vertical slice (`Modules/` + `Infra/`). Módulos usan `Infra` libremente. P/Invoke con `[LibraryImport]` (`[return: MarshalAs(UnmanagedType.Bool)]` en `bool`). Keys `.resx` en kebab-case.
- Git: Conventional Commits (rama actual `rewrite`).
- Tests: TBD

## Evitar

- Dependency injection, interfaces de adorno, clean / hexagonal / CQRS.
- `[DllImport]` (usar `[LibraryImport]`).
- `d:Visibility` en XAML (rompe la resolución de `{DynamicResource}` y tumba el render del diseñador XAML en Visual Studio).

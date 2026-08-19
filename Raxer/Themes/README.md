# Themes/Generic.xaml

WPF convention. When a custom control overrides `DefaultStyleKeyProperty` (like `Icon.cs` does), the framework automatically loads `Themes/Generic.xaml` from the assembly root to find its default style.

This is the only location the WPF designer recognizes for custom control styles. `App.xaml` merged dictionaries work at runtime but the designer ignores them — so icons rendered via custom controls show as invisible without this file.

This is not a project choice. It's how WPF works.

using Raxer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

// namespace Raxer.Infra.Dev.Lang;

// singleton
//public class Lang
//{
//    public static Lang Instance { get; } = new();

//    private Lang() { }

//    public string AppName => Get();
//    public string Description => Get();
//    public string Ok => Get();
//    public string Exit => Get();

//    // ...mas properties de texto UI

//    private string Get([CallerMemberName] string? propName = null)
//    {
//        if(string.IsNullOrEmpty(propName))
//            return $"[not found: {propName}]";

//        return Resources.ResourceManager.GetString(
//            propName,
//            CultureInfo.CurrentUICulture
//        ) ?? $"[not found: {propName}]"; 
//    }
//}


//public string CurrentLanguage { get; private set; } =
//  CultureInfo.CurrentUICulture.Name;
//public event PropertyChangedEventHandler? PropertyChanged;
//
//public void SetLanguage(string cultureName)
//{
//    var culture = CultureInfo.GetCultureInfo(cultureName);

//    CultureInfo.CurrentCulture = culture;
//    CultureInfo.CurrentUICulture = culture;

//     CurrentLanguage = culture.Name;

//     OnPropertyChanged(nameof(CurrentLanguage));
//     OnPropertyChanged(null);
//}

//private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
//{
//    PropertyChanged?.Invoke(
//        this,
//        new PropertyChangedEventArgs(propertyName)
//    );
//}
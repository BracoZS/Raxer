using System.Collections;
using System.Globalization;
using System.Windows;

namespace Raxer.Infra.Lang;

/// <summary>
/// 
/// use with:
/// <!-- UI text from resx -->
/// <ResourceDictionary.MergedDictionaries>
///  <lang:ResxDictionary />
///  </ResourceDictionary.MergedDictionaries>
///  in App.xaml
///  
///  and like Title="{DynamicResource settings}" in controls
/// </summary>

public sealed class ResxDictionary: ResourceDictionary
{
    private static ResxDictionary? _instance;

    public ResxDictionary()
    {
        _instance = this;
        SetCulture(CultureInfo.CurrentUICulture);
    }

    public static void SetLanguage(string cultureCode)
    {
        SetLanguage(new CultureInfo(cultureCode));
    }

    public static void SetLanguage(CultureInfo culture)
    {
        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        Properties.Resources.Culture = culture;

        _instance?.SetCulture(culture);
    }

    private void SetCulture(CultureInfo culture)
    {
        var resourceSet = Properties.Resources.ResourceManager.GetResourceSet(
            culture,
            createIfNotExists: true,
            tryParents: true);

        if (resourceSet == null)
            return;

        foreach (DictionaryEntry entry in resourceSet)
        {
            if (entry.Key is string key && entry.Value is string value)
                this[key] = value;
        }
    }
}
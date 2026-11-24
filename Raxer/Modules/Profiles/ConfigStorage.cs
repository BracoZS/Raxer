using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Raxer.Modules.Profiles;

/// <summary>
/// Persistencia JSON para archivos de configuración portable (.rxconfig).
/// Modelos planos para poder migrar fácilmente a LocalSettingsJson en el futuro.
/// </summary>
public static class ConfigStorage
{
    public static string DefaultPath => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "Raxer",
        "config.rxconfig");

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters = { new JsonStringEnumConverter() }
    };

    /// <summary>Devuelve la ruta personalizada si tiene valor, o la ruta por defecto en LocalAppData.</summary>
    public static string ResolvePath(string? customPath)
        => string.IsNullOrWhiteSpace(customPath) ? DefaultPath : customPath;

    /// <summary>Carga el archivo .rxconfig indicado (o crea uno por defecto si no existe).</summary>
    public static RaxerConfig Load(string? customPath = null)
    {
        var path = ResolvePath(customPath);

        if (!File.Exists(path))
        {
            var initial = RaxerConfig.CreateDefault();
            Save(initial, path);
            return initial;
        }

        try
        {
            var json = File.ReadAllText(path, Encoding.UTF8);
            var config = JsonSerializer.Deserialize<RaxerConfig>(json, JsonOptions);
            if (config is null)
                return RaxerConfig.CreateDefault();

            config.Profiles ??= [];
            config.Filters ??= [];

            if (config.Profiles.Count == 0)
                config.Profiles.Add(new Profile { Name = "Default" });

            return config;
        }
        catch (Exception ex)
        {
            Log($"ConfigStorage: error al cargar '{path}': {ex.Message}");
            return RaxerConfig.CreateDefault();
        }
    }

    /// <summary>Guarda la configuración en formato JSON indentado en la ruta indicada.</summary>
    public static void Save(RaxerConfig config, string? customPath = null)
    {
        ArgumentNullException.ThrowIfNull(config);
        var path = ResolvePath(customPath);

        try
        {
            var dir = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(dir))
                Directory.CreateDirectory(dir);

            var json = JsonSerializer.Serialize(config, JsonOptions);
            File.WriteAllText(path, json, Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Log($"ConfigStorage: error al guardar '{path}': {ex.Message}");
        }
    }
}

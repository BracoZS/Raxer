using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml.Linq;

namespace Raxer.Controls;

public class Icon : Control
{
    static Icon()
    {
        DefaultStyleKeyProperty.OverrideMetadata(
            typeof(Icon),
            new FrameworkPropertyMetadata(typeof(Icon)));
    }

    public static readonly DependencyProperty SourceProperty =
        DependencyProperty.Register(
            nameof(Source), typeof(string), typeof(Icon),
            new PropertyMetadata(null));

    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register(
            nameof(Data), typeof(Geometry), typeof(Icon),
            new PropertyMetadata(null));

    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public Geometry Data
    {
        get => (Geometry)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }

    protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);

        if (e.Property == SourceProperty && Source is string path)
        {
            LoadSvgData(path);
        }
    }

    private void LoadSvgData(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) return;

        try
        {
            string xmlContent = null;
            string cleanPath = path.TrimStart('/');

            // 1. Intento principal: Formato explícito con el nombre del ensamblado (Resuelve en Diseñador y en Runtime)
            try
            {
                string assemblyName = typeof(Icon).Assembly.GetName().Name;
                Uri packUri = new Uri($"pack://application:,,,/{assemblyName};component/{cleanPath}", UriKind.Absolute);

                var streamInfo = Application.GetResourceStream(packUri);
                if (streamInfo != null)
                {
                    using var reader = new StreamReader(streamInfo.Stream);
                    xmlContent = reader.ReadToEnd();
                }
            }
            catch
            {
                // 2. Fallback: Formato estándar de ejecución (Si el icono está en el ejecutable principal y no en el proyecto de la librería)
                try
                {
                    Uri packUri = new Uri($"pack://application:,,,/{cleanPath}", UriKind.Absolute);
                    var streamInfo = Application.GetResourceStream(packUri);
                    if (streamInfo != null)
                    {
                        using var reader = new StreamReader(streamInfo.Stream);
                        xmlContent = reader.ReadToEnd();
                    }
                }
                catch { }
            }

            // 3. Procesar y asignar los datos del SVG
            if (!string.IsNullOrEmpty(xmlContent))
            {
                XDocument doc = XDocument.Parse(xmlContent);

                var pathElements = doc.Descendants()
                                      .Where(e => e.Name.LocalName.Equals("path", StringComparison.OrdinalIgnoreCase))
                                      .Select(p => p.Attribute("d")?.Value)
                                      .Where(d => !string.IsNullOrWhiteSpace(d));

                string combinedData = string.Join(" ", pathElements);

                if (!string.IsNullOrWhiteSpace(combinedData))
                {
                    Data = Geometry.Parse(combinedData);
                }
            }
        }
        catch
        {
            // En caso de error, la propiedad Data mantendrá el fallback del DependencyProperty
        }
    }
}

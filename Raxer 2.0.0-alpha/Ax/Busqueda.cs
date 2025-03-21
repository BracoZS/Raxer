using System.Net;
using System.Threading;
using static System.Diagnostics.Process;
using static System.Windows.Clipboard;

namespace Raxer_2_alpha;
internal static partial class Ax
{
    public enum Buscadores
    {
        google, bing, yahoo, duckduckgo, ask, wikipedia, youtube
    }

    private static readonly Dictionary<Buscadores, string> _searchUrls = new Dictionary<Buscadores, string>
    {
        { Buscadores.google,  "https://www.google.com/search?q=" },
        { Buscadores.bing, "https://www.bing.com/search?q=" },
        { Buscadores.yahoo, "https://search.yahoo.com/search?p=" },
        { Buscadores.duckduckgo, "https://duckduckgo.com/?q=" },
        { Buscadores.ask, "https://www.ask.com/web?q=" },
        { Buscadores.wikipedia, "https://es.wikipedia.org/w/index.php?search=" },
        { Buscadores.youtube, "https://www.youtube.com/results?search_query=" }
    };

    internal static void BusquedaWeb(Buscadores buscador)
    {
        Thread staThread = new Thread(() =>
        {
            Copiar();
            var busqueda = GetText();

            if(string.IsNullOrEmpty(busqueda))
                return;

            if(_searchUrls.TryGetValue(buscador, out string searchUrl))
            {
                string queryEncoded = WebUtility.UrlEncode(busqueda);
                Start(new ProcessStartInfo
                {
                    FileName = searchUrl + queryEncoded,
                    UseShellExecute = true
                });
            }
        });
        staThread.SetApartmentState(ApartmentState.STA);
        staThread.Start();
    }
}


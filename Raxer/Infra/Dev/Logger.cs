using ResultPattern;
using System.Diagnostics;

namespace Raxer.Infra.Dev;

#if DEBUG
public static class Logger
{
    public static void Log(string message)
    {
        Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    }
    public static void Log(object obj)
    {
        Debug.WriteLine($"[{DateTime.Now:HH:mm:ss}] {obj.ToString()}");
    }
}
#endif
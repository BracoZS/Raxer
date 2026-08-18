using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Raxer.Infra.Dev;

public class Timer
{
    public static void LogTime(Stopwatch t)
    {
        t.Stop();
        Log(t.Elapsed);
    }
}

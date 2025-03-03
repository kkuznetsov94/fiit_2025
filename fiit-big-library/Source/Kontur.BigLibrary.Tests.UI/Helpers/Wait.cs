using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Kontur.BigLibrary.Tests.UI.Helpers;

public static class Wait
{
    public static void For([NotNull] Func<bool> waitFunc, int timeout = 5000, int waitTimeout = 500,
        string? timeoutMessage = null)
    {
        var stopWatch = Stopwatch.StartNew();
        try
        {
            while (stopWatch.ElapsedMilliseconds < timeout)
            {
                if (waitFunc())
                {
                    return;
                }

                Thread.Sleep(waitTimeout);
            }
            throw new Exception(timeoutMessage ?? "Timeout exception");
        }
        finally
        {
            stopWatch.Stop();
        }
    }


    public static async Task ForAsync([NotNull] Func<Task<bool>> waitFunc, int timeout = 10000, int waitTimeout = 500,
        string? timeoutMessage = null)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        try
        {
            while (stopWatch.ElapsedMilliseconds < timeout)
            {
                if (await waitFunc().ConfigureAwait(false))
                {
                    return;
                }

                await Task.Delay(waitTimeout).ConfigureAwait(false);
            }

            throw new Exception(timeoutMessage ?? "Timeout exception");
        }
        finally
        {
            stopWatch.Stop();
        }
    }
}
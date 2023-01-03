namespace BookingEksamenWebUI.Models;

public class HeavyWorkloadObject
{
    public string HeavyWorkloadResult { get; }
    public TimeSpan StopWatchElapsed { get; }

    public HeavyWorkloadObject(string heavyWorkloadResult, TimeSpan stopWatchElapsed)
    {
        HeavyWorkloadResult = heavyWorkloadResult;
        StopWatchElapsed = stopWatchElapsed;
    }
}
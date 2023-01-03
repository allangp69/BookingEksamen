namespace BookingEksamenWebUI.Helpers;

public interface IHeavyWorkloadAPIHelper
{
    Task<string> DoHeavyWorkloadAsync();
    string DoHeavyWorkload();
    Task<string> DoNormalWorkloadAsync();
    string DoNormalWorkload();
}
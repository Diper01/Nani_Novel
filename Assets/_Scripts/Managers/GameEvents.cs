using System.Threading.Tasks;

public static class GameEvents
{
  private static TaskCompletionSource<bool> miniGameTcs;

  public static Task OnMiniGameComplete
  {
    get
    {
      if (miniGameTcs == null || miniGameTcs.Task.IsCompleted)
        miniGameTcs = new TaskCompletionSource<bool>();
      return miniGameTcs.Task;
    }
  }

  public static void RaiseMiniGameComplete()
  {
    if (miniGameTcs != null && !miniGameTcs.Task.IsCompleted)
      miniGameTcs.SetResult(true);
  }
}
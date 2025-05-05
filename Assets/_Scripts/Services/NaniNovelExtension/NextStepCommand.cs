using Naninovel;
using UnityEngine;
using UniTask = Naninovel.UniTask;
using UniTaskCompletionSource = Cysharp.Threading.Tasks.UniTaskCompletionSource;

[CommandAlias("startMiniGame")]
public class NextStepCommand : Command {
  public override async UniTask ExecuteAsync (AsyncToken token = default) {
    await SceneLoader.LoadSceneAsync("MiniGame");

    UniTaskCompletionSource tcs = new UniTaskCompletionSource();

    void OnComplete() {
      GameController_MiniGame.OnGameComplete -= OnComplete;
      tcs.TrySetResult();
    }

    GameController_MiniGame.OnGameComplete += OnComplete;
    await tcs.Task;
    await SceneLoader.LoadSceneAsync("MainScene");
    var dest = GameObject.Find("MiniGame")?.transform;
    var playerTransform = GameObject.Find("Player")?.transform;

    if (playerTransform != null && dest != null)
      playerTransform.position = dest.position;
  }
}
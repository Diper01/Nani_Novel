using System;
using UnityEngine;
using Naninovel;
using UniTask = Naninovel.UniTask;


[CreateAssetMenu(menuName = "Dialogue Sequence/Actions/Run Mini Game")]
public class RunMiniGameAction : SequenceAction {
  [Tooltip("SceneName")]
  public string sceneName;

  public RunMiniGameAction (string sceneName) {
    this.sceneName = sceneName;
  }

  public override async UniTask ExecuteAsync() {
    /*await SceneLoader.LoadSceneAsync(sceneName);

    UniTaskCompletionSource tcs = new UniTaskCompletionSource();
    Action onComplete = null;

    onComplete = () => {
      GameController_MiniGame.OnGameComplete -= onComplete;
      tcs.TrySetResult();
    };

    GameController_MiniGame.OnGameComplete += onComplete;

    await tcs.Task;*/
  }
}
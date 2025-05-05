using UnityEngine;
using UniTask = Naninovel.UniTask;

[CreateAssetMenu(menuName = "Dialogue Sequence/Actions/ChangeScene")]
public class SceneChangeAction : SequenceAction {
  [Tooltip("scene Name")]
  public string sceneName;

  public override UniTask ExecuteAsync() {
    return SceneLoader.LoadSceneAsync(sceneName);
  }
}
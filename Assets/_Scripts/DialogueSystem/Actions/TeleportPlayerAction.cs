using UnityEngine;
using UniTask = Naninovel.UniTask;

[CreateAssetMenu(menuName = "Dialogue Sequence/Actions/TeleportPlayer")]
public class TeleportPlayerAction : SequenceAction {

  public override UniTask ExecuteAsync() {
    return UniTask.CompletedTask;
  }
}
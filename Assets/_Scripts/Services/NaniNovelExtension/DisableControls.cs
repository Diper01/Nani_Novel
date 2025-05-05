using Naninovel;
using UnityEngine;

[CommandAlias("disableControls")]
public class DisableControls : Command {

  public override UniTask ExecuteAsync (AsyncToken asyncToken = default) {
    var toggle = Object.FindObjectOfType<NaniNovelMovementToggle>();
    
    toggle.SetMovementEnabled(false);
    
    Debug.Log ("disableControls");
    return UniTask.CompletedTask;
  }
}

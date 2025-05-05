using UnityEngine;
using Naninovel;
using UniTask = Naninovel.UniTask;

[CommandAlias("enableControls")]
public class EnableControls : Command
{
  public override UniTask ExecuteAsync (AsyncToken asyncToken = default)
  {
    var toggle = Object.FindObjectOfType<NaniNovelMovementToggle>();
    toggle.SetMovementEnabled(true);
    
    Debug.Log ("enableControls");
    return UniTask.CompletedTask;
  }
}
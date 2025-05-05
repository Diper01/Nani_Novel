using UnityEngine;
using Naninovel;
using UniTask = Naninovel.UniTask;

[CreateAssetMenu(menuName = "Dialogue Sequence/Actions/Play Script")]
public class PlayScriptAction : SequenceAction {
  [Tooltip(".nani")]
  public string scriptName;
  [Tooltip("Label in the script to start from")]
  public string labelName = "Start";

  public override async UniTask ExecuteAsync() {
    IScriptPlayer iScriptPlayer = Engine.GetService<IScriptPlayer>();
    await iScriptPlayer.PreloadAndPlayAsync(scriptName, label: labelName);
    await UniTask.WaitWhile(() => iScriptPlayer.Playing);

  }
}
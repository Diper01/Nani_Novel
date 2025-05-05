using UnityEngine;
using Naninovel;

public class DialogueManager : MonoBehaviour {
  private IScriptPlayer _scriptPlayer;

  private void Awake() {
    _scriptPlayer = Engine.GetService<IScriptPlayer>();
  }

  public void StartDialogue (string scriptName) {
    _ = _scriptPlayer.PreloadAndPlayAsync(scriptName);
  }

  public void StopDialogue() {
    _scriptPlayer.Stop();
  }

}
using System.Collections;
using UnityEngine;
using Naninovel;

public class NaniNovelMovementToggle : MonoBehaviour {
  private MovementHandler _move;
  private PlayerMouseLook _mouseLook;
  private CameraSwitcher _cameraSwitch;
  private IScriptPlayer _scriptPlayer;
  private InputService _inputService;

  private IEnumerator Start() {
    _move = FindObjectOfType<MovementHandler>();
    _mouseLook = FindObjectOfType<PlayerMouseLook>();
    _inputService = FindObjectOfType<InputService>();

    _scriptPlayer = Engine.GetService<IScriptPlayer>();

    _scriptPlayer.OnPlay += OnScriptPlay;
    _scriptPlayer.OnStop += OnScriptStop;
    yield return null;
    _cameraSwitch = FindObjectOfType<CameraSwitcher>();
    SetMovementEnabled(false);
  }

  private void OnDestroy() {
    if (_scriptPlayer is not null) {
      _scriptPlayer.OnPlay -= OnScriptPlay;
      _scriptPlayer.OnStop -= OnScriptStop;
    }
  }

  private void OnScriptPlay (Script script)
    => SetMovementEnabled(false);

  private void OnScriptStop (Script script)
    => SetMovementEnabled(true);

  public void SetMovementEnabled (bool enabled) {
    _inputService.enabled = enabled;
    _move.enabled = enabled;
    _mouseLook.enabled = enabled;
    _cameraSwitch.enabled = enabled;
  }
}
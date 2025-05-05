using UnityEngine;
using Unity.Cinemachine;

[RequireComponent(typeof(CinemachineBrain))]
public class CameraSwitcher : MonoBehaviour {
  [Header("Cameras")]
  private CinemachineVirtualCameraBase _normalCam;
  private CinemachineVirtualCameraBase _freeLookCam;

  [Header("Priorities")]
  [SerializeField]
  private int _normalPriority = 10;
  [SerializeField]
  private int _freeLookPriority = 20;

  [Header("References")]
  [SerializeField]
  private Transform _playerTransform;

  private IInputService _input;
  private bool _prevFreeLook;

  private void Awake() {
    _input = FindObjectOfType<InputService>();

    _prevFreeLook = false;
  }

  private void Start() {
    _normalCam = GameObject.Find("Follow Camera").GetComponent<CinemachineVirtualCameraBase>();
    _freeLookCam = GameObject.Find("FreeLook Camera").GetComponent<CinemachineVirtualCameraBase>();
    _normalCam.Priority = _freeLookPriority;
    _freeLookCam.Priority = _normalPriority;
    _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
  }

  private void Update() {
    bool curr = _input.FreeLook;

    if (curr && !_prevFreeLook) {
      Vector3 fwd = Camera.main.transform.forward;
      fwd.y = 0;

      if (fwd.sqrMagnitude > 0.001f)
        _playerTransform.rotation = Quaternion.LookRotation(fwd.normalized);
    }

    if (curr) {
      _freeLookCam.Priority = _freeLookPriority;
      _normalCam.Priority = _normalPriority;
    } else {
      _freeLookCam.Priority = _normalPriority;
      _normalCam.Priority = _freeLookPriority;
    }

    _prevFreeLook = curr;
  }
}
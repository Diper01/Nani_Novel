using UnityEngine;

[RequireComponent(typeof(Transform))]
public class PlayerMouseLook : MonoBehaviour {
  [SerializeField]
  private float _sensitivity = 200f;

  private IInputService _input;

  private void Awake() {
    _input = FindObjectOfType<InputService>();
  }

  private void Update() {
    if (_input.FreeLook)
      return;

    float mx = _input.Look.x;

    if (Mathf.Abs(mx) > 0.01f) {
      transform.Rotate(Vector3.up, mx * _sensitivity * Time.deltaTime);
    }
  }
}
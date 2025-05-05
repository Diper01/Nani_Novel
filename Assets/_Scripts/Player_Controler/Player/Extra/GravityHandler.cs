using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class GravityHandler : MonoBehaviour {

  private float _gravity = -9.81f;
  private float _verticalVel;
  private CharacterController _cc;

  private void Awake()
    => _cc = GetComponent<CharacterController>();

  public void ApplyGravity() {
    if (_cc.isGrounded && _verticalVel < 0)
      _verticalVel = -2f;

    _verticalVel += _gravity * Time.deltaTime;
    _cc.Move(new Vector3(0, _verticalVel, 0) * Time.deltaTime);
  }

  public void Jump (float jumpHeight) {
    _verticalVel = Mathf.Sqrt(-2f * _gravity * jumpHeight);
  }
}
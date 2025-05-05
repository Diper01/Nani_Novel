using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputService), typeof(MovementHandler), typeof(GravityHandler))]
[RequireComponent(typeof(AnimationHandler), typeof(PlayerMouseLook))]
public class PlayerController : MonoBehaviour {
  private IInputService _input;
  private MovementHandler _move;
  private GravityHandler _gravity;
  private AnimationHandler _anim;


  private Camera _mainCam;
  [SerializeField]
  private float _jumpHeight = 2f;

  private IEnumerator Start() {
    _input = GetComponent<InputService>() as IInputService;
    _move = GetComponent<MovementHandler>();
    _gravity = GetComponent<GravityHandler>();
    _anim = GetComponent<AnimationHandler>();
    yield return new WaitForSeconds(2);
    _mainCam = Camera.main;
  }

  private void Update() {
    Vector2 moveInput = _input.Move;
    bool sprint = _input.Sprint;

    if (_mainCam == null) {
      _mainCam = Camera.main;

      if (_mainCam == null)
        return;
    }

    Vector3 forward = _input.FreeLook ? transform.forward : Camera.main.transform.forward;
    Vector3 right = _input.FreeLook ? transform.right : Camera.main.transform.right;

    _move.Move(moveInput, sprint, forward, right);
    _anim.UpdateMovement(moveInput, sprint);

    _gravity.ApplyGravity();

    if (_input.Jump) {
      bool jumpForward = moveInput.y > 0.1f;
      _gravity.Jump(_jumpHeight);
      _anim.PlayJump(jumpForward);
      _input.ConsumeJump();
    }

    if (_input.Attack) {
      _anim.PlayAttack();
      _input.ConsumeAttack();
    }
  }
}
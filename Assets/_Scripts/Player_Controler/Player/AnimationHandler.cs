using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationHandler : MonoBehaviour {
  Animator _anim;
  readonly int _moveXHash = Animator.StringToHash("MoveX");
  readonly int _moveYHash = Animator.StringToHash("MoveY");

  private void Awake()
    => _anim = GetComponent<Animator>();

  public void UpdateMovement (Vector2 input, bool sprint) {
    _anim.SetFloat(_moveXHash, input.x);
    _anim.SetFloat(_moveYHash, input.y * (sprint ? 2f : 1f));
  }

  public void PlayJump (bool spin) {
    _anim.SetTrigger(spin ? "JumpSpin" : "JumpNormal");
  }

  public void PlayAttack() {
    _anim.SetTrigger("Attack");
  }
}
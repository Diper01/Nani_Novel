using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour {
  [SerializeField]
  private float _moveSpeed = 3f;
  [SerializeField]
  private float _sprintMultiplier = 1.5f;

  private CharacterController _cc;

  private void Awake() {
    _cc = GetComponent<CharacterController>();
  }

  public void Move (Vector2 input, bool sprint, Vector3 forward, Vector3 right) {
    if (input.sqrMagnitude < 0.01f)
      return;

    Vector2 pure = input;

    if (Mathf.Abs(input.x) > 0.1f && Mathf.Abs(input.y) > 0.1f)
      pure = Mathf.Abs(input.x) > Mathf.Abs(input.y) ? new Vector2(input.x, 0f) : new Vector2(0f, input.y);

    Vector2 norm = pure.sqrMagnitude > 1f ? pure.normalized : pure;

    forward.y = 0;
    forward.Normalize();
    right.y = 0;
    right.Normalize();

    Vector3 dir = (forward * norm.y + right * norm.x).normalized;
    float speed = _moveSpeed * (sprint ? _sprintMultiplier : 1f);
    _cc.Move(dir * (speed * Time.deltaTime));
  }
}
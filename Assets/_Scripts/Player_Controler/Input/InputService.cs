// Scripts/Input/InputService.cs
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class InputService : MonoBehaviour, IInputService {
  private PlayerControls _controls;

  public Vector2 Move { get; private set; }
  public Vector2 Look { get; private set; }
  public bool FreeLook { get; private set; }
  public bool Jump { get; private set; }
  public bool Attack { get; private set; }
  public bool Sprint { get; private set; }

  public bool ExitPressed { get; private set; }
  private void Awake() {
    _controls = new PlayerControls();

    _controls.Movement.Move.performed += ctx => Move = ctx.ReadValue<Vector2>();
    _controls.Movement.Move.canceled += _ => Move = Vector2.zero;

    _controls.Movement.Look.performed += ctx => Look = ctx.ReadValue<Vector2>();
    _controls.Movement.Look.canceled += ctx => Look = Vector2.zero;
    
    _controls.Movement.FreeLook.started += _ => FreeLook = true;
    _controls.Movement.FreeLook.canceled += _ => FreeLook = false;
    
    _controls.Movement.Jump.performed += _ => Jump = true;
    _controls.Movement.Attack.performed += _ => Attack = true;
    _controls.Movement.Sprint.started += _ => Sprint = true;
    _controls.Movement.Sprint.canceled += _ => Sprint = false;
    
    _controls.Movement.Exit.performed += _ => ExitPressed = true;

  }

  void OnEnable()
    => _controls.Enable();

  void OnDisable()
    => _controls.Disable();

  public void ConsumeJump()
    => Jump = false;

  public void ConsumeAttack()
    => Attack = false;
  
  public void ConsumeExit()
    => ExitPressed = false;
}
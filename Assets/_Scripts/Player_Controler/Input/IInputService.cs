// Scripts/Input/IInputService.cs
using UnityEngine;

public interface IInputService {
  Vector2 Move { get; }
  Vector2 Look { get; }
  bool FreeLook { get; }
  bool Jump { get; }
  bool Attack { get; }
  bool Sprint { get; }

  void ConsumeJump();

  void ConsumeAttack();
}
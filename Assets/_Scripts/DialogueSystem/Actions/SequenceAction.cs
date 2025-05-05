using UniTask = Naninovel.UniTask;
using UnityEngine;

public abstract class SequenceAction : ScriptableObject {
  public abstract UniTask ExecuteAsync();
}
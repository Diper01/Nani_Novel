using UnityEngine;
using UniTask = Naninovel.UniTask;

[CreateAssetMenu(menuName = "Dialogue Sequence/Actions/GirlToCamp")]
public class TeleportSm2Sw : SequenceAction {

  [SerializeField]
  private string target;
  [SerializeField]
  private string place;
  [SerializeField]
  private int time;

  public override UniTask ExecuteAsync() {
    var obj1 = GameObject.Find(target);
    var obj2 = GameObject.Find(place);

    obj1.transform.position = obj2.transform.position;
    Debug.Log($"Target: {obj1.name} -> {obj2.name}");
    return UniTask.CompletedTask;
  }
}
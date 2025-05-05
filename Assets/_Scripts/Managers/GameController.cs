using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
  [SerializeField]
  private DialogueManager dialogueManager;
  [SerializeField]
  private DialogueSequenceController sequenceController;
  [SerializeField]
  private Transform pointA,
    pointB;
  
  
  

#region exemple for SO_Extansion
  private void Start() {
    /*List<DialoguePoint> points = new() {
      new DialoguePoint {
        location = pointA, //transform point
        actions = new List<SequenceAction> {
          ScriptableObject.CreateInstance<PlayScriptAction>().With(p => p.scriptName = "Prologue"),
          ScriptableObject.CreateInstance<PlayScriptAction>().With(p => p.scriptName = "Prologue2")
        }
      },
      new DialoguePoint {
        location = pointB, //transform point
        actions = new() {
          ScriptableObject.CreateInstance<PlayScriptAction>().With(p => p.scriptName = "QuestStart")
        }
      },
    };

    sequenceController.ConfigurePoints(points, loopSequence: false, triggerRadius: 2f);*/
  }
#endregion
}
using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class DialoguePoint {
  [Tooltip("Point for a spinning marker")]
  public Transform location;

  [HideInInspector]
  public Vector3 savedLocation;

  [Tooltip("Set of commands performed when activated")]
  public List<SequenceAction> actions = new List<SequenceAction>();

  public void CacheLocation() {
    if (location != null)
      savedLocation = location.position;
  }
}
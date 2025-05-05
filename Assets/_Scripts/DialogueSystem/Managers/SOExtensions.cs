using UnityEngine;

public static class SOExtensions // allow do all work from code
{
  public static T With<T> (this T so, System.Action<T> init) where T : ScriptableObject {
    init(so);
    return so;
  }
}
using Naninovel;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
  public static  UniTask  LoadSceneAsync(string sceneName)
  {
    AsyncOperation op = SceneManager.LoadSceneAsync(sceneName);
    return op.ToUniTask();
  }
}
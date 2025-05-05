using UnityEngine;

namespace Naninovel
{
  [ActorResources(typeof(Texture2D), true)]
  public class CenteredBackgroundActor : SpriteBackground
  {
    public CenteredBackgroundActor (string id, BackgroundMetadata metadata) 
      : base(id, metadata) { }

    public override async UniTask ChangeVisibilityAsync (bool visible, float duration, EasingType easingType = default, AsyncToken asyncToken = default)
    {
      if (visible && Camera.main != null)
      {
        var cam = Camera.main;
        var spawnDistance = 5f;
        var spawnPos = cam.transform.position + cam.transform.forward * spawnDistance;
        var spawnRot = Quaternion.LookRotation(-cam.transform.forward);

        await ChangePositionAsync(spawnPos, 0);
        await ChangeRotationAsync(spawnRot, 0);
      }

      await base.ChangeVisibilityAsync(visible, duration, easingType, asyncToken);
    }
    
  }
}
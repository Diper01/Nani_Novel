using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class Card : MonoBehaviour {
  [SerializeField]
  private MeshRenderer frontRenderer;
  [SerializeField]
  private MeshRenderer backRenderer;

  public int Id { get; private set; }
  public bool IsRevealed { get; private set; }
  public event Action<Card> OnSelected;

  public void Initialize (int id, Texture frontTexture) {
    Id = id;
    frontRenderer.material.mainTexture = frontTexture;
    HideImmediate();
  }

  private void OnMouseDown() {
    if (!IsRevealed)
      OnSelected?.Invoke(this);
  }

  public void Reveal() {
    IsRevealed = true;
    frontRenderer.enabled = true;
    backRenderer.enabled = false;
  }

  public void Hide() {
    IsRevealed = false;
    frontRenderer.enabled = false;
    backRenderer.enabled = true;
  }

  private void HideImmediate() {
    frontRenderer.enabled = false;
    backRenderer.enabled = true;
  }
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card2D : MonoBehaviour, IPointerClickHandler {
  [HideInInspector]
  public int Id;
  [SerializeField]
  private Image frontImage,
    backImage;
  private GameController_MiniGame controllerMiniGame;
  public bool IsRevealed { get; private set; }

  public void Init (int id, Sprite sprite, GameController_MiniGame ctrl) {
    Id = id;
    controllerMiniGame = ctrl;
    frontImage.sprite = sprite;
    frontImage.enabled = false;
    backImage.enabled = true;
    IsRevealed = false;
  }

  public void OnPointerClick (PointerEventData e) {
    if (!IsRevealed)
      controllerMiniGame.OnCardClicked(this);
  }

  public void Reveal() {
    IsRevealed = true;
    frontImage.enabled = true;
    backImage.enabled = false;
  }

  public void Hide() {
    IsRevealed = false;
    frontImage.enabled = false;
    backImage.enabled = true;
  }
}
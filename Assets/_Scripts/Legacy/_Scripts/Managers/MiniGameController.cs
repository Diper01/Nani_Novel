using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(BoardManager))]
public class MiniGameController : MonoBehaviour {

  private BoardManager board;
  private List<Card> selected = new List<Card>();

  private void Awake() {
    board = GetComponent<BoardManager>();
    board.OnBoardCreated += SubscribeCards;
  }

  private void SubscribeCards (List<Card> allCards) {
    foreach (var c in allCards)
      c.OnSelected += OnCardSelected;
  }

  private void OnCardSelected (Card card) {
    if (selected.Contains(card) || selected.Count >= 2)
      return;

    card.Reveal();
    selected.Add(card);

    if (selected.Count == 2)
      StartCoroutine(CheckMatch());
  }

  private IEnumerator CheckMatch() {
    var a = selected[0];
    var b = selected[1];

    if (a.Id != b.Id) {
      yield return new WaitForSeconds(1.5f);
      a.Hide();
      b.Hide();
    }

    selected.Clear();

    if (AllMatched())
      Debug.Log("Гра завершена!");
  }

  private bool AllMatched() {
    foreach (var c in board.GetComponentsInChildren<Card>())
      if (!c.IsRevealed)
        return false;

    return true;
  }
}
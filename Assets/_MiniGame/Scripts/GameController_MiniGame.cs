using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

public class GameController_MiniGame : MonoBehaviour {
  public static event Action OnGameComplete;

  [Header("Settings")]
  public GameObject cardPrefab;
  public Transform boardParent;
  public List<Sprite> cardSprites;
  public int pairCount = 8;
  public float flipBackDelay = 1.5f;

  private readonly List<Card2D> selected = new List<Card2D>();
  private readonly List<Card2D> allCards = new List<Card2D>();


  private void Start() {
    CreateBoard();
  }

  private void CreateBoard() {
    int total = pairCount * 2;
    List<int> ids = new List<int>();

    for (int i = 0; i < pairCount; i++) {
      ids.Add(i);
      ids.Add(i);
    }

    for (int i = 0; i < ids.Count; i++) {
      int rnd = Random.Range(i, ids.Count);
      (ids[i], ids[rnd]) = (ids[rnd], ids[i]);
    }

    for (int i = 0; i < total; i++) {
      var go = Instantiate(cardPrefab, boardParent);
      var card = go.GetComponent<Card2D>();
      card.Init(ids[i], cardSprites[ids[i]], this);
      allCards.Add(card);
    }
  }

  public void OnCardClicked (Card2D card) {
    if (selected.Contains(card) || selected.Count >= 2)
      return;

    card.Reveal();
    selected.Add(card);

    if (selected.Count == 2)
      StartCoroutine(CheckMatch());
  }

  private IEnumerator CheckMatch() {
    Card2D a = selected[0];
    Card2D b = selected[1];

    if (a.Id != b.Id) {
      yield return new WaitForSeconds(flipBackDelay);
      a.Hide();
      b.Hide();
    }

    selected.Clear();

    if (IsGameComplete()) {
      Debug.Log("Game Ovewr");
      OnGameComplete?.Invoke();
    }
  }

  private bool IsGameComplete() {
    return allCards.All(c => c.IsRevealed);
  }
}
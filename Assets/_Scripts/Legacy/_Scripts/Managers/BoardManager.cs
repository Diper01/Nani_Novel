using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(CardFactory))]
public class BoardManager : MonoBehaviour {
  [SerializeField]
  private int pairCount = 8;
  [SerializeField]
  private float spacing = 1.1f;

  private CardFactory factory;
  private List<Card> cards = new List<Card>();
  public event Action<List<Card>> OnBoardCreated;

  private void Awake() {
    factory = GetComponent<CardFactory>();
  }

  private void Start() {
    CreateBoard();
  }

  private void CreateBoard() {
    int total = pairCount * 2;
    int cols = Mathf.CeilToInt(Mathf.Sqrt(total));
    int rows = Mathf.CeilToInt(total / (float)cols);
    Vector3 origin = transform.position - new Vector3((cols - 1) * spacing, 0, (rows - 1) * spacing) * 0.5f;

    var ids = new List<int>();

    for (int i = 0; i < pairCount; i++) {
      ids.Add(i);
      ids.Add(i);
    }

    for (int i = 0; i < ids.Count; i++) {
      int j = UnityEngine.Random.Range(i, ids.Count);
      (ids[i], ids[j]) = (ids[j], ids[i]);
    }

    int idx = 0;

    for (int r = 0; r < rows; r++) {
      for (int c = 0; c < cols; c++) {
        if (idx >= total)
          break;

        Vector3 pos = origin + new Vector3(c * spacing, 0, r * spacing);
        var card = factory.Create(ids[idx], pos);
        cards.Add(card);
        idx++;
      }
    }

    OnBoardCreated?.Invoke(cards);
  }
}
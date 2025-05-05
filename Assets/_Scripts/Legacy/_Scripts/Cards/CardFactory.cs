using UnityEngine;

public class CardFactory : MonoBehaviour {
  [SerializeField]
  private GameObject cardPrefab;
  [SerializeField]
  private Texture [] textures;

  public Card Create (int id, Vector3 position) {
    var go = Instantiate(cardPrefab, position, Quaternion.identity, transform);
    go.transform.rotation = Quaternion.Euler(90, 0f, 0f);
    var card = go.GetComponent<Card>();
    card.Initialize(id, textures[id]);
    return card;
  }
}
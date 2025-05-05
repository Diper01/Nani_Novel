using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class DialogueSequenceController : Singleton<DialogueSequenceController> {
  [SerializeField]
  private List<DialoguePoint> steps;
  [SerializeField]
  private GameObject markerPrefab;
  [SerializeField]
  private float triggerRadius = 1f;
  [SerializeField]
  private bool loop = true;

  private Transform playerTransform;

  private int currentIndex = -1;
  private GameObject currentMarker;
  public object PlayerTransform {
    get;
    set;
  }

  protected override void Awake() {
    base.Awake();
    DontDestroyOnLoad(gameObject);

    SceneManager.sceneLoaded += OnSceneLoaded;

    foreach (var step in steps)
      step.CacheLocation();

    LocatePlayer();
  }

  private void OnDestroy() {
    SceneManager.sceneLoaded -= OnSceneLoaded;
  }

  private void OnSceneLoaded (Scene scene, LoadSceneMode mode) {
    LocatePlayer();

    if (currentMarker != null) {
      Destroy(currentMarker);
      var next = steps[currentIndex];
      currentMarker = Instantiate(markerPrefab, next.savedLocation, Quaternion.identity, transform);
    }
  }

  private void LocatePlayer() {
    var go = GameObject.FindGameObjectWithTag("Player");

    if (go != null)
      playerTransform = go.transform;
    else if (Camera.main != null)
      playerTransform = Camera.main.transform;
  }

  private void Start() {
    NextStep();
  }

  private void Update() {
    if (currentMarker == null)
      return;

    if (playerTransform == null)
      return;

    if (Vector3.Distance(playerTransform.position, currentMarker.transform.position) > triggerRadius)
      return;

    Destroy(currentMarker);
    currentMarker = null;
    RunStep().Forget();
  }

  private async UniTaskVoid RunStep() {
    var step = steps[currentIndex];

    foreach (var action in step.actions)
      await action.ExecuteAsync();

    NextStep();
  }

  private void NextStep() {
    currentIndex++;

    if (currentIndex >= steps.Count) {
      if (loop)
        currentIndex = 0;
      else
        return;
    }

    DialoguePoint next = steps[currentIndex];
    currentMarker = Instantiate(markerPrefab, next.savedLocation, Quaternion.identity, transform);
  }

  public void ConfigurePoints (List<DialoguePoint> customSteps, bool loopSequence = true, float triggerRadius = 1f) {
    steps = customSteps;
    loop = loopSequence;
    this.triggerRadius = triggerRadius;
    currentIndex = -1;

    foreach (var step in steps)
      step.CacheLocation();

    NextStep();
  }
}
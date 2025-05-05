using UnityEngine;
using UnityEngine.UI;

public class ExitController : MonoBehaviour {

  private InputService _inputService;
  [SerializeField]
  private GameObject _exitPanel;
  [SerializeField]
  private Button _exitButton;
  [SerializeField]
  private Button _continueButton;

  private void Start() {
    _exitPanel.SetActive(false);
    _inputService = FindObjectOfType<InputService>();
    _exitButton.onClick.AddListener(QuitGame);
    _continueButton.onClick.AddListener(HideExitPanel);
  }

  private void Update() {
    if (_inputService.ExitPressed) {
      Debug.Log("escape");
      ShowExitPanel();
      _inputService.ConsumeExit();
    }
  }

  private void ShowExitPanel()
    => _exitPanel.SetActive(true);


  private void HideExitPanel()
    => _exitPanel.SetActive(false);


  private void QuitGame() {
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
  }
}
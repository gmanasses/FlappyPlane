using UnityEngine;
using UnityEngine.UI;

public class InactivePlayerCanvasController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _background;
    [SerializeField] private Text _scoreToReviveText;
    private Canvas _canvas;


    // --- Core Functions ---
    private void Awake() {
        _canvas = this.GetComponent<Canvas>();
    }


    // --- Functions ---
    public void ShowCanvas(Camera camera) {
        _background.SetActive(true);
        _canvas.worldCamera = camera;
    }

    public void HideCanvas() {
        _background.SetActive(false);
    }

    public void UpdateText(int scoreToRevive) {
        _scoreToReviveText.text = scoreToRevive.ToString();
    }

}

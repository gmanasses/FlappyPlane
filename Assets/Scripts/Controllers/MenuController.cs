using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private Button _singlePlayerButton, _coopButton, _settingsButton;
    [SerializeField] private GameObject _mainScreen, _loadingScreen;
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private Text _loadingProgressText;


    // --- Core Functions ---
    private void Start() {
        //Vector3 buttonPosition = Camera.main.ScreenToWorldPoint(_settingsButton.transform.position);
    }


    // --- Functions ---
    public void LoadLevel(int SceneIndex) {
        StartCoroutine(LoadAsyncScene(SceneIndex));

    }

    public IEnumerator LoadAsyncScene(int SceneIndex) {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(SceneIndex);

        ShowLoadingScreen();

        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            _loadingSlider.value = progress;

            _loadingProgressText.text = progress * 100f + "%";

            yield return null;
        }
    }

    private void ShowLoadingScreen() {
        _mainScreen.SetActive(false);
        _loadingScreen.SetActive(true);
    }

}

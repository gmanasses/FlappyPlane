using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _mainScreen, _loadingScreen, _settingsScreen;
    [SerializeField] private Slider _loadingSlider, _masterVolume, _musicVolume, _effectsVolume;
    [SerializeField] private Text _loadingProgressText;
    [SerializeField] private GameObject _arrow;


    // --- Functions ---
    public void LoadLevel(int SceneIndex) {
        StartCoroutine(LoadAsyncScene(SceneIndex));
    }

    public IEnumerator LoadAsyncScene(int SceneIndex) {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);

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

    public void ShowSettingsScreen() {
        _mainScreen.SetActive(false);
        _settingsScreen.SetActive(true);
    }

    public void BackToMainScreen() {
        _settingsScreen.SetActive(false);
        _mainScreen.SetActive(true);
    }


    public void PutPlaneOnButton(Button button) {
        Vector3 planePosition = Vector3.zero;
        planePosition.x = _arrow.transform.position.x;
        planePosition.y = button.gameObject.transform.position.y;

        _arrow.transform.SetPositionAndRotation(planePosition, Quaternion.identity);
    }

}

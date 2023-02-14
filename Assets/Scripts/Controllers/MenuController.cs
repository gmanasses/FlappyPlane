using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _mainScreen, _loadingScreen;
    [SerializeField] private Slider _loadingSlider;
    [SerializeField] private Text _loadingProgressText;
    [SerializeField] private GameObject _plane;


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

    public void PutPlaneOnButton(Button button) {

        Vector3 planePosition = Vector3.zero;
        planePosition.x = _plane.transform.position.x;
        planePosition.y = button.gameObject.transform.position.y;
        print(planePosition);

        _plane.transform.SetPositionAndRotation(planePosition, Quaternion.identity);
    }

}

using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Text _scoreValue, _recordValue;


    // --- Functions ---
    public void ShowGameOverScreen(bool active) {
        _gameOverScreen.SetActive(active);
    }

    public void UpdateScore(int score) {
        _scoreValue.text = score.ToString();
    }

    public void UpdateGameOverScreen() {
        int record = PlayerPrefs.GetInt("record");
        _recordValue.text = record.ToString();
    }

}

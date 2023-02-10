using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private Image _medal;
    [SerializeField] private Sprite _bronzeMedal, _silverMedal, _goldMedal;
    [SerializeField] private Text _gameplayScoreValue, _gameoverScoreValue, _gameoverRecordValue;
    private ScoreController _scoreController;
    private int _recordScore;


    // --- Core Functions ---
    private void Start() {
        _scoreController = GameObject.FindObjectOfType<ScoreController>();
    }


    // --- Functions ---
    public void ShowGameOverScreen(bool active) {
        _gameplayScoreValue.gameObject.SetActive(!active);
        _gameOverScreen.SetActive(active);
    }

    public void UpdateScore(int score) {
        _gameplayScoreValue.text = score.ToString();
    }

    public void UpdateGameOverScreen() {
        _recordScore = PlayerPrefs.GetInt("record");
        _gameoverRecordValue.text = _recordScore.ToString();
        _gameoverScoreValue.text = _scoreController.Score.ToString();

        VerifyMedalColor();
    }

    private void VerifyMedalColor() {
        if(_scoreController.Score > _recordScore + 1) { //gold medal
            _medal.sprite = _goldMedal;

        } else if(_scoreController.Score >= _recordScore / 2) { //silver medal
            _medal.sprite = _silverMedal;

        } else { //bronze medal
            _medal.sprite = _bronzeMedal;
        }
    }

}

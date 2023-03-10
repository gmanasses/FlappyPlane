using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    // --- Public Declarations ---
    public int Score { get; private set; }

    // --- Private Declarations ---
    [SerializeField] private Text _scoreText;
    [SerializeField] private UnityEvent _whenScoring;
    private InterfaceController _interfaceController;


    // --- Core Functions ---
    private void Awake() {
        Score = 0;
    }

    private void Start() {
        _interfaceController = GameObject.FindObjectOfType<InterfaceController>();
    }


    // --- Functions ---
    public void AddScore() {
        Score++;

        SoundManager.Instance.PlayEffect("Score");

        _interfaceController.UpdateScore(Score);

        _whenScoring.Invoke();
    }

    public void RestartScore() {
        Score = 0;
        _interfaceController.UpdateScore(Score);
    }

    public void SaveRecordScore() {
        int oldRecord = PlayerPrefs.GetInt("record");
        if (oldRecord < Score) {
            PlayerPrefs.SetInt("record", Score);
        }
    }

}

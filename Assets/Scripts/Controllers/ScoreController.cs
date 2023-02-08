using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private Text _scoreText;
    private AudioSource _scoreSound;
    private InterfaceController _interfaceController;
    private int _score;


    // --- Core Functions ---
    private void Awake() {
        _scoreSound = this.GetComponent<AudioSource>();
        _score = 0;
    }

    private void Start() {
        _interfaceController = GameObject.FindObjectOfType<InterfaceController>();
    }


    // --- Functions ---
    public void AddScore() {
        _scoreSound.Play();
        _score++;
        _interfaceController.UpdateScore(_score);
    }

    public void RestartScore() {
        _score = 0;
        _interfaceController.UpdateScore(_score);
    }

    public void SaveRecordScore() {
        int oldRecord = PlayerPrefs.GetInt("record");
        if (oldRecord < _score) {
            PlayerPrefs.SetInt("record", _score);
        }
    }

}

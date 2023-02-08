using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private Text _scoreText;
    private AudioSource _scoreSound;
    private int _score;


    // --- Core Functions ---
    private void Awake() {
        _scoreSound = this.GetComponent<AudioSource>();
        _score = 0;
    }


    // --- Functions ---
    public void AddScore() {
        _scoreSound.Play();
        _score++;
        UpdateUI();
    }

    public void RestartScore() {
        _score = 0;
        UpdateUI();
    }

    private void UpdateUI() {
        _scoreText.text = _score.ToString();
    }

}

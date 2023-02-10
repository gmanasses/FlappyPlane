using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    // --- Public Declarations ---
    public float Difficulty { get; private set; }

    // --- Private Declarations ---
    [SerializeField] private float _timeToMaxDifficulty;
    private float _elapsedTime;


    // --- Core Functions ---
    private void Update() {
        _elapsedTime += Time.deltaTime;

        Difficulty = _elapsedTime / _timeToMaxDifficulty;
        Difficulty = Mathf.Min(1, Difficulty);
    }

    public void RestartDifficulty() {
        _elapsedTime = 0;
    }

}

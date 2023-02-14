using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _generationTimeEasy;
    [SerializeField] private float _generationTimeHard;
    [SerializeField] private GameObject _obstaclePrefab;
    private DifficultyManager _difficultyManager;
    private bool _isStopped;
    private float _chronometer;

    // --- Core Functions ---
    private void Awake() {
        _chronometer = _generationTimeEasy;
    }

    private void Start() {
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }

    private void Update() {
        if(_isStopped) return;

        _chronometer -= Time.deltaTime;
        if(_chronometer < 0) {
            GameObject.Instantiate(_obstaclePrefab, this.transform.position, Quaternion.identity);
            _chronometer = Mathf.Lerp(_generationTimeEasy, _generationTimeHard, _difficultyManager.Difficulty);
        }
    }


    // --- Functions ---
    public void StopGeneration() {
        _isStopped = true;
    }

    public void RestartGeneration() {
        _isStopped = false;
    }

}

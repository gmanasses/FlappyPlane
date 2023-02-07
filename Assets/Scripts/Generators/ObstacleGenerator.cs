using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _generationTime;
    [SerializeField] private GameObject _obstaclePrefab;
    private float _chronometer;


    // --- Core Functions ---
    private void Awake() {
        _chronometer = _generationTime;
    }

    private void Update() {        
        _chronometer -= Time.deltaTime;
        if(_chronometer < 0) {
            GameObject.Instantiate(_obstaclePrefab, this.transform.position, Quaternion.identity);
            _chronometer = _generationTime;
        }
    }

}

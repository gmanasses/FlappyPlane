using UnityEngine;

public class ObstacleGenerator : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _generationTime;
    [SerializeField] private GameObject _obstaclePrefab;
    private float _chronometer;


    // --- Core Functions ---
    private void Awake() {
        this._chronometer = this._generationTime;
    }

    private void Update() {        
        this._chronometer -= Time.deltaTime;
        if(this._chronometer < 0) {
            GameObject.Instantiate(_obstaclePrefab, this.transform.position, Quaternion.identity);
            this._chronometer = this._generationTime;
        }
    }

}

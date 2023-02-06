using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private int _speed = 5;
    [SerializeField] private float _yPositionVariation;


    // --- Core Functions ---
    private void Awake() {
        this.transform.Translate(Vector3.up * Random.Range(-_yPositionVariation, _yPositionVariation));
    }

    private void Update() {
        this.transform.Translate(Vector3.left * this._speed * Time.deltaTime);
    }

}

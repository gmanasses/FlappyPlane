using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private SharedVariablesFloat _speed;
    [SerializeField] private float _yPositionVariation;


    // --- Core Functions ---
    private void Awake() {
        this.transform.Translate(Vector3.up * Random.Range(-_yPositionVariation, _yPositionVariation));
    }

    private void Update() {
        this.transform.Translate(Vector3.left * _speed.value * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyObstacle();
    }


    // --- Functions ---
    public void DestroyObstacle() {
        Destroy(this.gameObject);
    }

}

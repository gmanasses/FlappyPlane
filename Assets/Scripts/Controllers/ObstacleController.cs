using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private SharedVariablesFloat _speed;
    [SerializeField] private float _yPositionVariation;
    private ScoreController _scoreController;
    private Vector3 _planePosition;
    private bool _scored;


    // --- Core Functions ---
    private void Awake() {
        this.transform.Translate(Vector3.up * Random.Range(-_yPositionVariation, _yPositionVariation));
        _scored = false;
    }
    
    private void Start() {
        _planePosition = GameObject.FindObjectOfType<PlaneController>().transform.position;
        _scoreController = GameObject.FindObjectOfType<ScoreController>();
    }

    private void Update() {
        this.transform.Translate(Vector3.left * _speed.value * Time.deltaTime);

        checksIfScored();        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DestroyObstacle();
    }


    // --- Functions ---
    public void DestroyObstacle() {
        Destroy(this.gameObject);
    }

    private void checksIfScored() {
        if(!_scored && this.transform.position.x < _planePosition.x) {
            _scored = true;
            _scoreController.AddScore();
        }
    }

}

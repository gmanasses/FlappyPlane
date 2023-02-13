using UnityEngine;

public class PlaneController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _forceMultiplier;
    private Animator _planeAnimator;
    private Rigidbody2D _physics;
    private SceneManager _sceneManager;
    private Vector3 _initialPosition;
    private bool _shouldAscend;


    // --- Core Functions ---
    private void Awake() {
        _initialPosition = transform.position;
        _physics = this.GetComponent<Rigidbody2D>();
        _planeAnimator = this.GetComponent<Animator>();
    }

    private void Start() {
        _sceneManager = GameObject.FindObjectOfType<SceneManager>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            _shouldAscend = true;
        }

        _planeAnimator.SetFloat("PlaneVelocityY", _physics.velocity.y);
    }

    private void FixedUpdate() {
        if(_shouldAscend) {
            Ascend();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        _physics.simulated = false;
        _sceneManager.GameOver();
    }


    // --- Functions ---
    private void Ascend() {
        _physics.velocity = Vector2.zero;
        _physics.AddForce(Vector2.up * _forceMultiplier, ForceMode2D.Impulse);
        _shouldAscend = false;
    }

    public void RestartPosition() {
        _physics.simulated = true;
        transform.rotation = Quaternion.identity;
        transform.position = _initialPosition;
    }

}

using UnityEngine;
using UnityEngine.Events;

public class PlaneController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private UnityEvent _whenPlaneCollides, _whenPlaneScores;
    [SerializeField] private float _forceMultiplier;
    private Animator _planeAnimator;
    private Rigidbody2D _physics;
    private Vector3 _initialPosition;
    private bool _shouldAscend;


    // --- Core Functions ---
    private void Awake() {
        _initialPosition = transform.position;
        _physics = this.GetComponent<Rigidbody2D>();
        _planeAnimator = this.GetComponent<Animator>();
    }

    private void Update() {
        _planeAnimator.SetFloat("PlaneVelocityY", _physics.velocity.y);
    }

    private void FixedUpdate() {
        if(_shouldAscend) {
            Ascend();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        _physics.simulated = false;
        _whenPlaneCollides.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        _whenPlaneScores.Invoke();
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


    public void BoostPlane() {
        _shouldAscend = true;
    }

}

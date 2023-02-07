using UnityEngine;

public class PlaneController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private float _forceMultiplier;
    private SceneManager _sceneManager;
    private Rigidbody2D _physics;


    // --- Core Functions ---
    private void Awake() {
        this._physics = this.GetComponent<Rigidbody2D>();
        this._sceneManager = GameObject.FindObjectOfType<SceneManager>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            this.Ascend();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        this._physics.simulated = false;
        this._sceneManager.GameOver();
    }


    // --- Functions ---
    private void Ascend() {
        this._physics.velocity = Vector2.zero;
        this._physics.AddForce(Vector2.up * _forceMultiplier, ForceMode2D.Impulse);
    }

}

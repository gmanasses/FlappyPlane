using UnityEngine;

public class PlaneController : MonoBehaviour {

    // --- private declarations ---
    [SerializeField] private float _forceMultiplier = 6.75f;
    private Rigidbody2D _physics;


    // --- Core Functions ---
    private void Awake() {
        this._physics = this.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            this.Ascend();
        }
    }


    // --- Functions ---
    private void Ascend() {
        this._physics.AddForce(Vector2.up * _forceMultiplier, ForceMode2D.Impulse);
    }

}

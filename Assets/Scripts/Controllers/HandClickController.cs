using UnityEngine;

public class HandClickController : MonoBehaviour {

    // --- Private Declarations ---
    private SpriteRenderer _spriteRenderer;


    // --- Core Functions ---
    private void Awake() {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        if(Input.GetButtonDown("Fire1")) {
            DisableSpriteRenderer();
        }
    }


    // --- Functions ---
    private void DisableSpriteRenderer() {
        _spriteRenderer.enabled = false;
    }

}

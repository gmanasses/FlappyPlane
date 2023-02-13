using UnityEngine;

public class InputController : MonoBehaviour {
    
    // --- Private Declarations ---
    [SerializeField] private KeyCode _key;
    private PlaneController _planeController;


    // --- Core Functions ---
    private void Start() {
        _planeController = this.GetComponent<PlaneController>();
    }

    private void Update() {
        if(Input.GetKeyDown(_key)) {
            _planeController.BoostPlane();
        }
    }

}

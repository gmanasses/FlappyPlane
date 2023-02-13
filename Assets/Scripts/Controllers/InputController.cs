using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour {
    
    // --- Private Declarations ---
    [SerializeField] private KeyCode _key;
    [SerializeField] private UnityEvent _whenPressingKey;


    // --- Core Functions ---
    private void Update() {
        if(Input.GetKeyDown(_key)) {
            _whenPressingKey.Invoke();
        }
    }

}

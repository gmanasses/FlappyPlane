using UnityEngine;
using UnityEngine.Events;

public class CoopStartGameController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private UnityEvent _whenAnimationOver;


    // --- Functions ---
    public void ActivatePlayer() {
        _whenAnimationOver.Invoke();
    }

}

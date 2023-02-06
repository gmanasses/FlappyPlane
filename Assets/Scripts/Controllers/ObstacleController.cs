using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // --- private declarations ---
    [SerializeField] private int _speedReduction = 125;


    // --- Core Functions ---
    private void Update() {
        this.transform.Translate(Vector3.left / _speedReduction);
    }

}
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private int _speed = 5;


    // --- Core Functions ---
    private void Update() {
        this.transform.Translate(Vector3.left * this._speed * Time.deltaTime);
    }

}

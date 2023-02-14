using System.Collections;
using UnityEngine;

public class Player2Manager : MonoBehaviour {

    // --- Private Declarations
    private PlaneController _planeController;


    // --- Core Functions ---
    private void Start() {
        _planeController = this.GetComponent<PlaneController>();
        StartCoroutine(Boost());
    }


    // --- Functions ---
    private IEnumerator Boost() {
        while (true) { 
            yield return new WaitForSeconds(0.8f);
            _planeController.BoostPlane();
        }
    }

}

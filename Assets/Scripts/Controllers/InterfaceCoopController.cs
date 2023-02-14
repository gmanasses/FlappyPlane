using UnityEngine;

public class InterfaceCoopController : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _line, _background;


    // --- Functions ---
    public void ShowAndHideScoreBackground(bool show) {
        _background.SetActive(show);
        _line.SetActive(show);
    }

}

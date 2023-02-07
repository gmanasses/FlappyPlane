using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private Image _gameOverImage;


    // --- Functions ---
    public void GameOver() {
        //freeze game
        Time.timeScale = 0;

        //show game over image
        this._gameOverImage.gameObject.SetActive(true);
    }
    
}

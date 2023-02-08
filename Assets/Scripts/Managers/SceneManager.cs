using UnityEngine;

public class SceneManager : MonoBehaviour {

    // --- Private Declarations ---
    [SerializeField] private GameObject _gameOverScreen;
    private PlaneController _planeController;
    private ScoreController _scoreController;


    // --- Core Functions ---
    private void Start() {
        _planeController = GameObject.FindObjectOfType<PlaneController>();
        _scoreController = GameObject.FindObjectOfType<ScoreController>();
    }


    // --- Functions ---
    public void GameOver() {
        //freeze game
        Time.timeScale = 0;

        //show game over image
        _gameOverScreen.SetActive(true);
    }

    public void RestartGame() {
        //hide game over image
        _gameOverScreen.SetActive(false);

        //unfreeze game
        Time.timeScale = 1;

        //restart plane position
        _planeController.RestartPosition();

        //restart score
        _scoreController.RestartScore();

        //destroy remaining obstacles
        DestroyAllObstacles();
    }
    
    private void DestroyAllObstacles() {
        ObstacleController[] obstacles = GameObject.FindObjectsOfType<ObstacleController>();
        foreach (ObstacleController obstacle in obstacles) {
            obstacle.DestroyObstacle();
        }
    }

}

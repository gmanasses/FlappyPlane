using UnityEngine;

public class SinglePlayerManager : MonoBehaviour {

    // --- Private Declarations ---    
    private InterfaceController _interfaceController;
    private DifficultyManager _difficultyManager;
    private PlaneController _planeController;
    private ScoreController _scoreController;


    // --- Core Functions ---
    protected virtual void Start() {
        _interfaceController = GameObject.FindObjectOfType<InterfaceController>();
        _difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
        _planeController = GameObject.FindObjectOfType<PlaneController>();
        _scoreController = GameObject.FindObjectOfType<ScoreController>();
    }


    // --- Functions ---
    public void GameOver() {
        //freeze game
        Time.timeScale = 0;

        //save scores
        _scoreController.SaveRecordScore();

        //update interface
        _interfaceController.UpdateGameOverScreen();

        //show game over image
        _interfaceController.ShowGameOverScreen(true);
    }

    public void RestartGame() {
        //hide game over image
        _interfaceController.ShowGameOverScreen(false);

        //unfreeze game
        Time.timeScale = 1;

        //restart plane position
        _planeController.RestartPosition();

        //restart score
        _scoreController.RestartScore();

        //restart difficulty
        _difficultyManager.RestartDifficulty();

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

// smoke particle <a href="https://www.flaticon.com/free-icons/cloud" title="cloud icons">Cloud icons created by Akalidz - Flaticon</a>
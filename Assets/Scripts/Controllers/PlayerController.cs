using UnityEngine;

public class PlayerController : MonoBehaviour {

    // --- Private Declarations ---
    private CarouselController[] _scenario;
    private ObstacleGenerator _obstacleGenerator;
    private PlaneController _planeController;
    private bool _myPlanePassedAway;


    // --- Core Functions ---
    private void Start() {
        _scenario = this.GetComponentsInChildren<CarouselController>();
        _obstacleGenerator = this.GetComponentInChildren<ObstacleGenerator>();
        _planeController = this.GetComponentInChildren<PlaneController>();
    }


    // --- Functions ---
    public void DisablePlayer() {
        _myPlanePassedAway = true;

        _obstacleGenerator.StopGeneration();

        foreach(var Carousel in _scenario) {
            Carousel.enabled = false;
        }
    }

    public void EnablePlayer() {
        if(_myPlanePassedAway) {
            _obstacleGenerator.RestartGeneration();

            _planeController.RestartPosition();

            foreach (var Carousel in _scenario) {
                Carousel.enabled = true;
            }

            _myPlanePassedAway = false;
        }
    }

}

using UnityEngine;

public class CoopManager : SinglePlayerManager {

    // --- Private Declarations ---
    [SerializeField] private int _scoreToRevive;
    private InactivePlayerCanvasController _inactivePlayerCanvasController;
    private InterfaceCoopController _interfaceCoopController;
    private PlayerController[] _players;
    private bool _anyDeadPlayer;
    private int _scoresMadeSinceDeath;


    // --- Core Functions ---
    protected override void Start() {
        base.Start();
        _players = GameObject.FindObjectsOfType<PlayerController>();
        _interfaceCoopController = GameObject.FindObjectOfType<InterfaceCoopController>();
        _inactivePlayerCanvasController = GameObject.FindObjectOfType<InactivePlayerCanvasController>();
    }


    // --- Functions ---
    public override void RestartGame() {
        base.RestartGame();

        _interfaceCoopController.ShowAndHideScoreBackground(true);

        RevivePlayers();
    }

    public void TryToRevivePlayer() {
        if(_anyDeadPlayer) {
            _scoresMadeSinceDeath++;

            _inactivePlayerCanvasController.UpdateText(_scoreToRevive - _scoresMadeSinceDeath);

            if(_scoresMadeSinceDeath >= _scoreToRevive) {
                RevivePlayers();
                _inactivePlayerCanvasController.HideCanvas();
            }
        }
    }

    private void RevivePlayers() {
        foreach(var player in _players) {
            player.EnablePlayer();
        }

        _anyDeadPlayer = false;
    }

    public void SomePlayerDied(Camera camera) {
        if(_anyDeadPlayer) {
            _inactivePlayerCanvasController.HideCanvas();
            _interfaceCoopController.ShowAndHideScoreBackground(false);
            GameOver();

        } else {
            _anyDeadPlayer = true;
            _scoresMadeSinceDeath = 0;
            _inactivePlayerCanvasController.UpdateText(_scoreToRevive);
            _inactivePlayerCanvasController.ShowCanvas(camera);
        }
    }

}

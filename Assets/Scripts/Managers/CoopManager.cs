using UnityEngine;

public class CoopManager : SinglePlayerManager {

    // --- Private Declarations ---
    [SerializeField] private int _scoreToRevive;
    private PlayerController[] _players;
    private bool _anyDeadPlayer;
    private int _scoresMadeSinceDeath;


    // --- Core Functions ---
    protected override void Start() {
        base.Start();
        _players = GameObject.FindObjectsOfType<PlayerController>();
    }


    // --- Functions ---
    public void TryToRevivePlayer() {
        if(_anyDeadPlayer) {
            _scoresMadeSinceDeath++;

            if(_scoresMadeSinceDeath >= _scoreToRevive) {
                RevivePlayers();
            }
        }
    }

    private void RevivePlayers() {
        foreach(var player in _players) {
            player.EnablePlayer();
        }

        _anyDeadPlayer = false;
    }

    public void SomePlayerDied() {
        _anyDeadPlayer = true;
        _scoresMadeSinceDeath = 0;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopHandler : MonoBehaviour
{
    [SerializeField] private ColliderExplosionHandler _colliderExplosionHandler;
    [SerializeField] private QuestsHandler _questHandler;

    [SerializeField] private Movement _playerMovement;
    [SerializeField] private TimeMachineIntaraction _timeMachine;

    private void Start()
    {
        ResetGame();
    }

    public void RestartOnSpotted()
    {
        _playerMovement.enabled = true;
        _timeMachine.RestartReplays();

        _colliderExplosionHandler.ResetTimeMachineBarier();
        _questHandler.RestartQuests();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ResetGame()
    {
        _colliderExplosionHandler.ResetTimeMachineBarier();
        _questHandler.DisableQuests();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelHandler : MonoBehaviour
{
    [SerializeField] private Transform[] _playerSpawnPoints;
    [SerializeField] private QuestsHandler _questsHandler;

    [SerializeField] private Player _player;
    [SerializeField] private NPC _npc;

    private Recorder _playerRecorder;
    private Recorder _npcRecorder;

    private Vector3 _npcPositionAfterTimeTravel = new Vector3(-123.6f, 0f, -187.7f);

    public void OnTimeTravel()
    {
        PlayClonesRecordings();
        SetNpcPositions();
        SetPlayerPosition();
        _questsHandler.RestartQuests();
    }

    public void RestartClonesRecordings()
    {
        _npcRecorder.RestartReplay();
        _playerRecorder.RestartReplay();

        SetNpcPositions();
        SetPlayerPosition();
    }

    private void PlayClonesRecordings()
    {
        _playerRecorder = _player.GetComponent<Recorder>();
        _playerRecorder?.StartPlayingReplay();

        _npcRecorder = _npc.Recorder;
        _npcRecorder?.StartPlayingReplay();
    }

    private void SetNpcPositions()
    {
        _npc.transform.position = _npcPositionAfterTimeTravel;
    }

    private void SetPlayerPosition()
    {
        int random = Random.Range(0, _playerSpawnPoints.Length);

        _player.transform.SetPositionAndRotation(_playerSpawnPoints[random].position, _playerSpawnPoints[random].rotation);
    }
}

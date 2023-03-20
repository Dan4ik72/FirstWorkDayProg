using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[RequireComponent(typeof(Transform))]
public class Recorder : MonoBehaviour
{
    [SerializeField] private ReplayObject _replayObjectPrefab;
    [SerializeField] private Player _player;
    [SerializeField] private GameEndingHandler _gameEndingHandler;
    
    private Queue<ReplayData> _recordQueue;
    private bool _isReplaying = false;
    private bool _isRecording = true;
    private Record _record;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    private void Awake()
    {
        _recordQueue = new Queue<ReplayData>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;        
    }

    private void Update()
    {
        if (_isReplaying == false)
            return;

        bool hasMoreFrames = _record.TryPlayNextFrame();

        if (hasMoreFrames == false)
        {
            _gameEndingHandler.TryToEndGame();

            _isReplaying = false;
        }
    }

    private void LateUpdate()
    {
        if (_isRecording == false)
            return;

        RecordReplayFrame();
    }

    public void StopRecording()
    {
        _isRecording = false;
    }

    public void RestartReplay()
    {
        _isReplaying = true;
        _record.RestartFromBegining();
    }

    public void StartPlayingReplay()
    {
        StartCoroutine(PlayReplay());
    }

    private void RecordReplayFrame()
    {
        ReplayData data = new ReplayData(transform.position, transform.rotation, Input.GetAxisRaw("Vertical"), Input.GetAxisRaw("Horizontal"));
        
        _recordQueue.Enqueue(data);
    }

    private IEnumerator PlayReplay()
    {
        _record = new Record(_recordQueue, _startPosition, _startRotation);
        _recordQueue.Clear();

        _record.InstantiateReplayObject(_replayObjectPrefab, _player);
        _isRecording = false;

        yield return new WaitForSeconds(2f);

        _isReplaying = true;
    }
}

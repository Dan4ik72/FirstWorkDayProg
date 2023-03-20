using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record
{
    private Queue<ReplayData> _originalReplayData;
    private Queue<ReplayData> _replayReplayData;

    private Vector3 _startPosition;
    private Quaternion _startRotation;

    public ReplayObject ReplayObject { get; private set; }

    public Record(Queue<ReplayData> recordingQueue, Vector3 startPosition, Quaternion startRotation)
    {
        _originalReplayData = new Queue<ReplayData>(recordingQueue);
        _replayReplayData = new Queue<ReplayData>(recordingQueue);

        _startPosition = startPosition;
        _startRotation = startRotation;
    }

    public void RestartFromBegining()
    {
        _replayReplayData = new Queue<ReplayData>(_originalReplayData);
        ReplayObject.transform.SetPositionAndRotation(_startPosition, _startRotation);
    }

    public bool TryPlayNextFrame()
    {
        if (ReplayObject == null)
            Debug.LogError("No replay object!");

        bool hasMoreFrames;

        if (_replayReplayData.Count == 0)
        {
            hasMoreFrames = false;
            return hasMoreFrames;
        }

        ReplayData data = _replayReplayData.Dequeue();
        ReplayObject.SetDataForFrame(data);
        hasMoreFrames = true;

        return hasMoreFrames;
    }

    public void InstantiateReplayObject(ReplayObject replayObjectPrafab, Player player)
    {   
        if (_replayReplayData.Count == 0)
            return;

        ReplayObject = Object.Instantiate(replayObjectPrafab, _startPosition, Quaternion.identity);

        player.Radar.AddTarget(ReplayObject.transform);
    }

    public void DestroyReplayObjectIfExists()
    {
        if (ReplayObject == null)
            return;

        Object.Destroy(ReplayObject.gameObject);
    }
}

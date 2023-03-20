using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField] private RadarPointer _radarPointerPrefab;
    [SerializeField] private Canvas _uiCanvas;
    [SerializeField] private Sprite _radarIcon;
    [SerializeField] private List<Transform> _targets;

    private List<RadarPointer> _radarPointers;

    public Transform TargetsTransform => _targets[0];

    private void Start()
    {
        if (_radarPointers != null)
            return;

        _radarPointers = new List<RadarPointer>();

        AddRadarPointer();
    }

    public void AddRadarPointer()
    {
        var newRadarPointer = Instantiate(_radarPointerPrefab);
        _radarPointers.Add(newRadarPointer);        

        newRadarPointer.transform.SetParent(_uiCanvas.transform);
        newRadarPointer.Init(_targets[_radarPointers.Count - 1], transform, _radarIcon);

    }

    public void AddTarget(Transform target)
    {
        _targets.Add(target);
        AddRadarPointer();
    }

    public void DeletePointersAndClearTargets()
    {
        foreach (var radarPointer in _radarPointers)
            Destroy(radarPointer.gameObject);

        _radarPointers.Clear();
        _targets.Clear();
    }
}
